using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Interfaces
{
    public interface IAlunoRepository
    {
        AlunoModel? GetById(int id);
        IEnumerable<AlunoModel> GetAll();
        void Add(AlunoModel aluno);
        void Update(AlunoModel aluno);
        void Delete(int id);
    }
}
