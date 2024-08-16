using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/ola", () =>
{
    return Results.Ok(new { sucesso = "sim"});
})
.WithName("ola")
.WithOpenApi();

app.MapGet("/sair", () =>
{
    return Results.Ok(new { sucesso = "sair" });
})
.WithName("sair")
.WithOpenApi();

app.MapPost("/dados", ([FromBody] JsonObject dados) =>
{
    if ((string)dados["cidade"] == "bauru")
    {
        return Results.Ok(new { sucesso = "sim"});
    }
    else
    {
        return Results.Ok(new { sucesso = "nao" });
    }
})
.WithName("dados")
.WithOpenApi();

app.Run();
