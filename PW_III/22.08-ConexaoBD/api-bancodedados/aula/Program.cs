using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/cursos", () =>
{
    //criei uma conexão com o banco
    MySqlConnection conexao = new MySqlConnection();
    //configurei o endereco e parametros de conexao
    conexao.ConnectionString = "server=localhost;password=aluno.etec;User Id=aluno;database=teste;";
    //abri a conexao
    conexao.Open();

    //criei um comando sql para consultar o banco
    MySqlCommand sql = new MySqlCommand("SELECT * FROM cursos",conexao);
    
    DataTable dados = new DataTable();

    //carreguei essa tabela com a leitura do SQL
    dados.Load(sql.ExecuteReader());

    //fechei a conexao pra não ficar aberta atoa
    conexao.Close();

    //criei um retorno, converti a tabela em objeto e de objeto pra json
    return Results.Ok(JsonDocument.Parse(JsonConvert.SerializeObject(dados)));
})
.WithName("cursos");

app.Run();
