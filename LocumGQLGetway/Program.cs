using LocumGQLGateway.Data;
using LocumGQLGateway.Extensions;
using LocumGQLGateway.GraphQL.Mutations;
using LocumGQLGateway.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure EF Core with MySQL
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 33)),
        mysql => mysql.EnableRetryOnFailure()
    );
});
// 1. Register DbContext with IServiceCollection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Register Services
builder.Services.AddLocumServices();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Configure GraphQL
builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    //.AddQueryType(d => d.Name("Query"))
    .AddType<Query>()
    //.AddMutationType(d => d.Name("Mutation"))
    .AddType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();
// Simple test endpoint
app.MapGet("/", () => "GraphQL API is running. Visit /graphql");
app.MapGraphQL();

app.Run();