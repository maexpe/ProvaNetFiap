using Dapper;
using Microsoft.Data.SqlClient;
using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _connectionString;

        public AlunoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AlunoModel? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QuerySingleOrDefault<AlunoModel>("select * from aluno where id = @id", new { Id = id });
        }

        public IEnumerable<AlunoModel> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<AlunoModel>("select * from aluno");
        }

        public void Add(AlunoModel aluno)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "insert into aluno(nome, usuario, senha) values (@nome, @usuario, @senha)";
            connection.Execute(query, aluno);
        }

        public void Update(AlunoModel aluno)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "update aluno set nome = @nome, usuario = @usuario, senha = @senha where id = @id";
            connection.Execute(query, aluno);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "delete from aluno where id = @id";
            connection.Execute(query, new { Id = id });
        }
    }
}
