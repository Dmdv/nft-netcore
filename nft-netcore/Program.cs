using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Net.Http.Headers;
using Nft.Constraints;
using Nft.Mappers;
using Nft.Serialization;
using Nft.Swagger;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// All  controllers names should be lowercased
builder.Services.AddRouting(o => o.LowercaseUrls = true);
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });

    // opt.AddDefaultPolicy(
    //     policy =>
    //     {
    //         policy.WithOrigins("http://localhost", "localhost", "http://localhost/*", "localhost/*");
    //         policy.SetIsOriginAllowed(o => o.Contains("localhost", StringComparison.InvariantCultureIgnoreCase));
    //         policy.WithMethods("GET", "PUT", "POST", "HEAD", "OPTIONS");
    //     });
});

// Add services to the container

builder.Services.AddLogging();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddStackExchangeRedisCache(c =>
{
    var host = Environment.GetEnvironmentVariable("REDIS_HOST");
    var port = Environment.GetEnvironmentVariable("REDIS_PORT");
    var pass = Environment.GetEnvironmentVariable("REDIS_PASSWORD");
    var cname = Environment.GetEnvironmentVariable("REDIS_CLIENT_NAME");
    var iname = Environment.GetEnvironmentVariable("REDIS_INSTANCE_NAME");

    var url = $"redis://{pass}@{host}:{port}";
    
    c.Configuration = url;
    c.InstanceName = iname;

    var opts = new ConfigurationOptions
    {
        EndPoints = { $"{host}:{port}" },
        AbortOnConnectFail = false,
        Password = pass,
        ClientName = cname
    };
    
    c.ConfigurationOptions = opts;
});
builder.Services.AddHttpClient("opensea", c =>
{
    c.BaseAddress = new Uri("https://api.opensea.io/");
    c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    c.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "opensea");
    c.DefaultRequestHeaders.Add("X-API-KEY", Environment.GetEnvironmentVariable("OPENSEA_API_KEY"));
});
builder.Services.AddHttpClient("blockdaemon", c =>
{
    c.BaseAddress = new Uri($"{Environment.GetEnvironmentVariable("BLOCKDAEMON_NFT_URL")}");
    c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    c.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "blockdaemon");
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",$"{Environment.GetEnvironmentVariable("BLOCKDAEMON_API_KEY")}");
});
builder.Services.AddScoped<IGraphQLClient>(_ =>
{
    var endPoint = builder.Configuration["GraphQLUri"];
    if (string.IsNullOrEmpty(endPoint))
    {
        throw new ArgumentException("GraphQLUri is not configured");
    }
    
    return new GraphQLHttpClient(endPoint, new SystemTextJsonSerializer());
});

builder.Services.AddControllers().AddJsonOptions(c =>
{
    // All enums convert to strings
    c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    // Ignore when value is NULL
    c.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

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
    // If you want swagger controllers lowercased
    o.DocumentFilter<LowerCaseDocumentFilter>();
});

builder.Services.Configure<RouteOptions>(o => { o.ConstraintMap.Add("OrderBy", typeof(OrderByConstraint)); });

// Mapping
builder.Services.AddAutoMapper(c => { c.AddProfile<MappingProfile>(); });

// Health

builder.Services
    .AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy(), tags: new[] { "service" })
    .AddRedis(_ =>
        {
            var host = Environment.GetEnvironmentVariable("REDIS_HOST");
            var port = Environment.GetEnvironmentVariable("REDIS_PORT");
            var pass = Environment.GetEnvironmentVariable("REDIS_PASSWORD");
            return $"{host}:{port},password={pass}";
        },
        tags: new[] { "redis" })
    ;

var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(() =>
{
    app.Logger.LogInformation("Application has started on {Now} UTC", DateTime.UtcNow);
});

app.UseCors();

// Health check for service

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    Predicate = reg => reg.Tags.Contains("service"),
    AllowCachingResponses = false,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

// Health check for redis

app.MapHealthChecks("/healthz/redis", new HealthCheckOptions
{
    Predicate = reg => reg.Tags.Contains("redis"),
    AllowCachingResponses = false,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

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

app.MapGet("/", (IDistributedCache cache) =>
{
    var cstZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
    var hkTime = TimeZoneInfo.ConvertTimeFromUtc(ThisAssembly.GitCommitDate.ToUniversalTime(), cstZone);

    var commitDate = $"GitCommitDate: {ThisAssembly.GitCommitDate.ToLongDateString()}  {ThisAssembly.GitCommitDate.ToLongTimeString()} (Hong Kong/China: {hkTime.ToLongTimeString()})";

    var startDate = cache.GetString("start-date");
    if (startDate == null)
    {
        var now = DateTime.UtcNow;
        var startDateHk = TimeZoneInfo.ConvertTimeFromUtc(now, cstZone);
        startDate = $"{now.ToLongDateString()}  {now.ToLongTimeString()} (Hong Kong/China: {startDateHk.ToLongTimeString()})";
        cache.SetString("start-date", startDate);
    }

    var sb =
            new StringBuilder("This is the root of nft service")
                .AppendLine()
                .Append("AssemblyName: ").AppendLine(ThisAssembly.AssemblyName)
                .Append("AssemblyTitle: ").AppendLine(ThisAssembly.AssemblyTitle)
                .Append("AssemblyVersion: ").AppendLine(ThisAssembly.AssemblyVersion)
                .Append("AssemblyInformationalVersion: ").AppendLine(ThisAssembly.AssemblyInformationalVersion)
                .Append("AssemblyConfiguration: ").AppendLine(ThisAssembly.AssemblyConfiguration)
                .Append("IsPrerelease: ").AppendLine(ThisAssembly.IsPrerelease.ToString())
                .Append("IsPublicRelease: ").AppendLine(ThisAssembly.IsPublicRelease.ToString())
                .AppendLine(commitDate).Append("GitCommitId: ")
                .AppendLine(ThisAssembly.GitCommitId)
                .AppendLine($"Distributed cache started since: {startDate}")
        ;

    return sb.ToString();
});

app.Run();