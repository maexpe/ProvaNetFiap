using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Interfaces
{
    public interface IAlunoTurmaRepository
    {
        IEnumerable<AlunoTurmaModel> GetAllAssociacoes();
        IEnumerable<AlunoModel> GetAllAlunos();
        IEnumerable<TurmaModel> GetAllTurmas();
        IEnumerable<AlunoModel> GetAlunosByTurma(int turmaId);
        IEnumerable<TurmaModel> GetTurmasByAluno(int alunoId);
        void AddAssociacao(int alunoId, int turmaId);
        void DeleteAssociacao(int alunoId, int turmaId);
        bool AssociacaoExiste(int alunoId, int turmaId);
    }
}
