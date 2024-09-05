using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/listar", () =>
{
    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=teste;";
    conexao.Open();

    MySqlCommand sql = new MySqlCommand("SELECT * FROM cursos",conexao);

    DataTable dados = new DataTable();
    dados.Load(sql.ExecuteReader());

    conexao.Close();

    return Results.Ok(JsonDocument.Parse(JsonConvert.SerializeObject(dados)));
})
.WithName("ListarCursos");

app.MapPost("/incluir", ([FromBody] JsonObject dados) =>
{
    if(string.IsNullOrEmpty((string)dados["curso"]) || string.IsNullOrEmpty((string)dados["vagas"]) || string.IsNullOrEmpty((string)dados["periodo"]))
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }

    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=teste;";
    conexao.Open();

    MySqlCommand sql = new MySqlCommand("INSERT INTO cursos(curso,vagas,periodo) " +
        "VALUES(@c,@v,@p)", conexao);
    sql.Parameters.AddWithValue("@c", dados["curso"]);
    sql.Parameters.AddWithValue("@v", dados["vagas"]);
    sql.Parameters.AddWithValue("@p", dados["periodo"]);

    var retorno = sql.ExecuteNonQuery();

    conexao.Close();

    if(retorno == 1)
    {
        return Results.Ok();
    }
    else
    {
        return Results.Problem();
    }
    
})
.WithName("IncluirCursos");


app.MapPost("/alterar/{cod}", ([FromBody] JsonObject dados, string cod) =>
{
    if (string.IsNullOrEmpty((string)dados["curso"]) || string.IsNullOrEmpty((string)dados["vagas"]) || string.IsNullOrEmpty((string)dados["periodo"]))
    {
        return Results.BadRequest(new { erro = "Campos em branco" });
    }

    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=teste;";
    conexao.Open();

    MySqlCommand sql = new MySqlCommand("UPDATE cursos SET curso = @c, vagas = @v, periodo = @p " +
        "WHERE cod = @cod", conexao);
    sql.Parameters.AddWithValue("@c", dados["curso"]);
    sql.Parameters.AddWithValue("@v", dados["vagas"]);
    sql.Parameters.AddWithValue("@p", dados["periodo"]);
    sql.Parameters.AddWithValue("@cod", cod);

    var retorno = sql.ExecuteNonQuery();

    conexao.Close();

    if (retorno == 1)
    {
        return Results.Ok();
    }
    else
    {
        return Results.Problem();
    }

})
.WithName("AlterarCursos");


app.MapDelete("/excluir/{cod}", ([FromBody] JsonObject dados, string cod) =>
{
    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=teste;";
    conexao.Open();

    MySqlCommand sql = new MySqlCommand("DELETE FROM cursos WHERE cod = @cod", conexao);
    sql.Parameters.AddWithValue("@cod", cod);

    var retorno = sql.ExecuteNonQuery();

    conexao.Close();

    if (retorno == 1)
    {
        return Results.Ok();
    }
    else
    {
        return Results.Problem();
    }

})
.WithName("ExcluirCursos");

app.Run();
