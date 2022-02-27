using Microsoft.Azure.Cosmos;
using Server;

var builder = WebApplication.CreateBuilder(args); //this file enumerates the secrets.json file stored in appdata

var CosmosDBAPIKey = builder.Configuration["CosmosDb:Key"];
var CosmosConnectionString = builder.Configuration["CosmosDb:Account"];


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Adding this service fixed the error of Dependency Injection error
builder.Services.AddTransient<ICosmosDbService, CosmosDbService>();
builder.Services.AddSingleton<CosmosClient>(ServiceProvider =>
{
    return new CosmosClient(
        CosmosConnectionString,
        CosmosDBAPIKey
    );
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
