using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly AlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaService(AlunoTurmaRepository alunoTurmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public IEnumerable<AlunoModel> GetAllAlunos()
        {
            return _alunoTurmaRepository.GetAllAlunos();
        }

        public IEnumerable<TurmaModel> GetAllTurmas()
        {
            return _alunoTurmaRepository.GetAllTurmas();
        }

        public IEnumerable<AlunoModel> GetAlunosByTurma(int turmaId)
        {
            return _alunoTurmaRepository.GetAlunosByTurma(turmaId);
        }

        public IEnumerable<TurmaModel> GetTurmasByAluno(int alunoId)
        {
            return _alunoTurmaRepository.GetTurmasByAluno(alunoId);
        }

        public void AddAssociacao(int alunoId, int turmaId)
        {
            if (_alunoTurmaRepository.AssociacaoExiste(alunoId, turmaId))
                throw new InvalidOperationException("Relação entre aluno e turma já existe.");

            _alunoTurmaRepository.AddAssociacao(alunoId, turmaId);
        }
        public void DeleteAssociacao(int alunoId, int turmaId)
        {
            _alunoTurmaRepository.DeleteAssociacao(alunoId, turmaId);
        }

        public bool AssociacaoExiste(int alunoId, int turmaId)
        {
            return _alunoTurmaRepository.AssociacaoExiste(alunoId, turmaId);
        }
    }
}
