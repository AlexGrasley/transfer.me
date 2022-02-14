using Microsoft.Azure.Cosmos;
using Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CosmosClient>(ServiceProvider =>
{
    return new CosmosClient("AccountEndpoint=https://transfermecosmosdb.documents.azure.com:443/;AccountKey=FC2gRrrJWZyQBRphDknknQAaN1tBo1LjGp4cDTDaN0Kz1FEhIhCoCpAEN0DAOzyot1T78YvssvGRZorxfvyf2w==");
});
//Adding this service fixed the error of Dependency Injection error
builder.Services.AddTransient<ICosmosDbService, CosmosDbService>();
var app = builder.Build();

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
