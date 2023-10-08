using Dapper;
using Microsoft.Data.SqlClient;
using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly string _connectionString;

        public AlunoTurmaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<AlunoTurmaModel> GetAllAssociacoes()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<AlunoTurmaModel>("select * from aluno_turma");
        }

        public IEnumerable<AlunoModel> GetAllAlunos()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<AlunoModel>("select * from aluno");
        }

        public IEnumerable<TurmaModel> GetAllTurmas()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<TurmaModel>("select * from turma");
        }

        public IEnumerable<AlunoModel> GetAlunosByTurma(int turmaId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = @"select a.* from aluno a inner join aluno_turma at on a.id = at.aluno_id where at.turma_id = @TurmaId";
            return connection.Query<AlunoModel>(query, new { TurmaId = turmaId });
        }

        public IEnumerable<TurmaModel> GetTurmasByAluno(int alunoId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = @"select t.* from turma t inner join aluno_turma at on t.id = at.turma_id where at.aluno_id = @AlunoId";
            return connection.Query<TurmaModel>(query, new { AlunoId = alunoId });
        }

        public void AddAssociacao(int alunoId, int turmaId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "insert into aluno_turma (aluno_id, turma_id) values (@AlunoId, @TurmaId)";
            connection.Execute(query, new { AlunoId = alunoId, TurmaId = turmaId });
        }

        public void DeleteAssociacao(int alunoId, int turmaId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "delete from aluno_turma where aluno_id = @AlunoId and turma_id = @TurmaId";
            connection.Execute(query, new { AlunoId = alunoId, TurmaId = turmaId });
        }

        public bool AssociacaoExiste(int alunoId, int turmaId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "select count(*) from aluno_turma where aluno_id = @AlunoId and turma_id = @TurmaId";
            var count = connection.ExecuteScalar<int>(query, new { AlunoId = alunoId, TurmaId = turmaId });
            return count > 0;
        }
    }
}
