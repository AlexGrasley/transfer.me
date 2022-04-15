using Microsoft.Azure.Cosmos;
using Server;

var builder = WebApplication.CreateBuilder(args); //this line enumerates the secrets.json file stored in appdata

var CosmosDBAPIKey = builder.Configuration["CosmosDb:Key"]; 
var CosmosConnectionString = builder.Configuration["CosmosDb:AccountEndpoint"];


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Adding this service fixed the error of Dependency Injection error
builder.Services.AddTransient<ICosmosDbService, CosmosDbService>();
builder.Services.AddTransient<IDownloadService, DownloadService>();
builder.Services.AddTransient<Server.Logger.ILogger, Server.Logger.Logger>();
builder.Services.AddSingleton<CosmosClient>(ServiceProvider =>
{
    return new CosmosClient($"AccountEndpoint={CosmosConnectionString};AccountKey={CosmosDBAPIKey}");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("DevCorsPolicy");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
