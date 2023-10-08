using Microsoft.AspNetCore.Identity;
using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Interfaces.Services;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;
using System.Text.RegularExpressions;

namespace OperacoesAlunoTurma.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly PasswordHasher<AlunoModel> _passwordHasher;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
            _passwordHasher = new PasswordHasher<AlunoModel>();
        }

        public IEnumerable<AlunoModel> GetAll()
        {
            return _alunoRepository.GetAll();
        }

        public AlunoModel? GetById(int id)
        {
            return _alunoRepository.GetById(id);
        }

        public void Add(AlunoModel aluno)
        {
            HashSenha(aluno);

            _alunoRepository.Add(aluno);
        }

        public void Update(AlunoModel aluno)
        {
            HashSenha(aluno);

            _alunoRepository.Update(aluno);
        }

        public void Delete(int id)
        {
            _alunoRepository.Delete(id);
        }

        private void HashSenha(AlunoModel aluno)
        {
            aluno.Senha = _passwordHasher.HashPassword(aluno, aluno.Senha);
        }
    }
}
