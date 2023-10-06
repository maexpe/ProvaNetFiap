using Microsoft.AspNetCore.Identity;
using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;
using System.Text.RegularExpressions;

namespace OperacoesAlunoTurma.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AlunoRepository _alunoRepository;
        private readonly PasswordHasher<AlunoModel> _passwordHasher;

        public AlunoService(AlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
            _passwordHasher = new PasswordHasher<AlunoModel>();
        }

        public bool SenhaForte(string senha)
        {
            if (senha.Length < 12 ||
                !Regex.IsMatch(senha, "[A-Z]") ||
                !Regex.IsMatch(senha, "[a-z]") ||
                !Regex.IsMatch(senha, @"\d") ||
                !Regex.IsMatch(senha, @"[@$#&*{},=().+;'/!%^?\:|<>]"))
                return false;

            return true;
        }

        public IEnumerable<AlunoModel> GetAll()
        {
            return _alunoRepository.GetAll();
        }

        public void Add(AlunoModel aluno)
        {
            ValidarEHashSenha(aluno);

            _alunoRepository.Add(aluno);
        }

        public void Update(AlunoModel aluno)
        {
            ValidarEHashSenha(aluno);

            _alunoRepository.Update(aluno);
        }

        public void Delete(int id)
        {
            _alunoRepository.Delete(id);
        }

        private void ValidarEHashSenha(AlunoModel aluno)
        {
            if (!SenhaForte(aluno.Senha))
                throw new InvalidOperationException("Senha muito fraca.");

            aluno.Senha = _passwordHasher.HashPassword(aluno, aluno.Senha);
        }
    }
}
