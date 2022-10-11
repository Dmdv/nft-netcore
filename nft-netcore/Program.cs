using System.Text.Json;
using System.Text.Json.Serialization;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Net.Http.Headers;
using Nft.Helpers;
using Nft.Mappers;

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
    // if required snake policy
    // c.JsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy();
    c.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    c.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    c.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    c.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString; // double and decimals
    c.JsonSerializerOptions.AddContext<SerializationContext>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    // swagger schema with snake filter
    // o.SchemaFilter<SnakeCaseSchemaFilter>();
    // Different schema ID for same type name
    o.CustomSchemaIds(type => type.ToString());
});

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
app.UseHttpsRedirection();
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