using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

//listar todos os professores
app.MapGet("/professores", () =>
{
    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=teste;";
     conexao.Open();

    MySqlCommand sql = new MySqlCommand("SELECT * FROM prof", conexao);
    DataTable dadosProf = new DataTable();
    dadosProf.Load(sql.ExecuteReader());
     conexao.Close();

    return Results.Ok(JsonDocument.Parse(JsonConvert.SerializeObject(dadosProf)));
})
.WithName("professores");

//liste nome do curso, nome do professor (será necessário fazer um select com as 3 tabelas cursos, professores_cursos e professores)
app.MapGet("/cursos/professores", () =>
{
    MySqlConnection conexao = new MySqlConnection();
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=teste;";
    conexao.Open();

    MySqlCommand sql = new MySqlCommand("SELECT * FROM profcurso", conexao);
    DataTable dadosCursoProf = new DataTable();
    dadosCursoProf.Load(sql.ExecuteReader());
    conexao.Close();

    return Results.Ok(JsonDocument.Parse(JsonConvert.SerializeObject(dadosCursoProf)));
})
.WithName("cursosprofessores");



app.Run();
