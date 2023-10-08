using OperacoesAlunoTurma.Models;

namespace OperacoesAlunoTurma.Interfaces.Services
{
    public interface ITurmaService
    {
        bool TurmaNomeUnique(string turmaNome);
        IEnumerable<TurmaModel> GetAll();
        TurmaModel? GetById(int id);
        void Add(TurmaModel turma);
        void Update(TurmaModel turma);
        void Delete(int id);
        TurmaModel? GetByNome(string nome);
    }
}
