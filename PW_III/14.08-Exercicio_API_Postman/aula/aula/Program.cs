using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.MapPost("/dados", ([FromBody] JsonObject dados) =>
{
    int total;
    total = (int)dados["n1"] + (int)dados["n2"];
    return Results.Ok(new { total });
})
.WithName("dados")
.WithOpenApi();

app.Run();
