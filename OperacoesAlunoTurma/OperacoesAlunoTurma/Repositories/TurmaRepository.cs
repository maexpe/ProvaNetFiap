using Dapper;
using Microsoft.Data.SqlClient;
using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string _connectionString;

        public TurmaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TurmaModel? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QuerySingleOrDefault<TurmaModel>("select * from turma where id = @id", new { Id = id });
        }

        public IEnumerable<TurmaModel> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<TurmaModel>("select * from turma");
        }

        public void Add(TurmaModel turma)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "insert into turma(cursoid, turma, ano) values (@cursoid, @turma, @ano)";
            connection.Execute(query, turma);
        }

        public void Update(TurmaModel turma)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "update turma set cursoid = @cursoid, turma = @turma, ano = @ano where id = @id";
            connection.Execute(query, turma);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "delete from turma where id = @id";
            connection.Execute(query, new { Id = id });
        }

        public TurmaModel? GetByNome(string nome)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<TurmaModel>("select * from turma where turma = @Nome", new { Nome = nome }).FirstOrDefault();
        }
    }
}
