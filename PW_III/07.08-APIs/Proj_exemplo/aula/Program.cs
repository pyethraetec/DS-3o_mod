using MySql.Data;

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

app.Run();
