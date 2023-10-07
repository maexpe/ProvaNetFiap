using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly TurmaRepository _turmaRepository;

        public TurmaService(TurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public bool TurmaNomeUnique(string turmaNome)
        {
            var existeTurma = _turmaRepository.GetByNome(turmaNome);
            return existeTurma == null;
        }

        public IEnumerable<TurmaModel> GetAll()
        {
            return _turmaRepository.GetAll();
        }

        public void Add(TurmaModel turma)
        {
            NomeUniqueEAnoValido(turma);

            _turmaRepository.Add(turma);
        }

        public void Update(TurmaModel turma)
        {
            NomeUniqueEAnoValido(turma);

            _turmaRepository.Add(turma);
        }

        public void Delete(int id)
        {
            _turmaRepository.Delete(id);
        }

        public TurmaModel? GetByNome(string nome)
        {
            return _turmaRepository.GetByNome(nome);
        }

        private void NomeUniqueEAnoValido(TurmaModel turma)
        {
            if (!TurmaNomeUnique(turma.Turma))
                throw new InvalidOperationException("Nome da turma deve ser único.");

            if (turma.Ano < DateTime.Now.Year)
                throw new InvalidOperationException("Ano da turma não pode ser anterior ao atual");
        }
    }
}
