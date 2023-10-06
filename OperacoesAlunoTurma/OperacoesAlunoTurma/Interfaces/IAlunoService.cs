using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Interfaces
{
    public interface IAlunoService
    {
        bool SenhaForte(string senha);
        IEnumerable<AlunoModel> GetAll();
        void Add(AlunoModel aluno);
        void Update(AlunoModel aluno);
        void Delete(int id);
    }
}
