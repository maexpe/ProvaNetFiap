using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Interfaces.Services
{
    public interface IAlunoService
    {
        IEnumerable<AlunoModel> GetAll();
        AlunoModel GetById(int id);
        void Add(AlunoModel aluno);
        void Update(AlunoModel aluno);
        void Delete(int id);
    }
}
