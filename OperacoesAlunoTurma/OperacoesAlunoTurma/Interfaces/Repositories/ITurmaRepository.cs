using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Interfaces
{
    public interface ITurmaRepository
    {
        TurmaModel? GetById(int id);
        IEnumerable<TurmaModel> GetAll();
        void Add(TurmaModel turma);
        void Update(TurmaModel turma);
        void Delete(int id);
        TurmaModel? GetByNome(string nome);
    }
}
