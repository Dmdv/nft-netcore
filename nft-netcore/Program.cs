using System.Text.Json;
using System.Text.Json.Serialization;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Net.Http.Headers;
using Nft.Helpers;
using Nft.Mappers;
using Nft.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddLogging();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient("opensea", c =>
{
    c.BaseAddress = new Uri("https://api.opensea.io/");
    c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    c.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "centralex");
    c.DefaultRequestHeaders.Add("X-API-KEY", Environment.GetEnvironmentVariable("OPENSEA_API_KEY"));
});
builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(builder.Configuration["GraphQLUri"], new SystemTextJsonSerializer()));
builder.Services.AddControllers().AddJsonOptions(c =>
{
    // All enums convert to strings
    c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    
    // if required snake policy
    // c.JsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();
    c.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    c.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    c.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString; // double and decimals
    // Serialization context for all source models generated at compile time
    c.JsonSerializerOptions.AddContext<CommonSerializationContext>();
    
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    // swagger schema with snake filter
    // o.SchemaFilter<SnakeCaseSchemaFilter>();
    // Different schema ID for same type name
    o.CustomSchemaIds(type => type.ToString());
    // All enum convert to strings
    o.SchemaFilter<EnumSchemaFilter>();
});

// builder.Services.Configure<RouteOptions>(o =>
// {
//     o.ConstraintMap.Add("OrderBy", typeof(OrderByConstraint));
// });

// Mapping
builder.Services.AddAutoMapper(c =>
{
    c.AddProfile<MappingProfile>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpLogging();
// HTTPS enabling
// app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    // required when hid behind reverse proxy
    ForwardedHeaders = 
        ForwardedHeaders.XForwardedFor | 
        ForwardedHeaders.XForwardedHost | 
        ForwardedHeaders.XForwardedProto
});

// app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "This is the root of nft service");

app.Run();