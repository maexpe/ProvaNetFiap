using Microsoft.AspNetCore.Mvc;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunoTurmaController : Controller
    {
        private readonly AlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaController(AlunoTurmaRepository alunoTurmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public IActionResult Index()
        {
            var associacoes = _alunoTurmaRepository.GetAllAssociacoes();
            return View(associacoes);
        }

        [HttpGet("associate")]
        public IActionResult Associate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Associate(AlunoTurmaModel alunoTurma)
        {
            if (_alunoTurmaRepository.AssociacaoExiste(alunoTurma.AlunoId, alunoTurma.TurmaId))
            {
                ModelState.AddModelError("", "Associação já existe.");
                return View();
            }

            _alunoTurmaRepository.AddAssociacao(alunoTurma.AlunoId, alunoTurma.TurmaId);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Disassociate(int alunoId, int turmaId)
        {
            _alunoTurmaRepository.DeleteAssociacao(alunoId, turmaId);
            return RedirectToAction("Index");
        }

        [HttpGet("alunos/{alunoId}/turmas")]
        public IActionResult GetTurmasByAluno(int alunoId)
        {
            var turmas = _alunoTurmaRepository.GetTurmasByAluno(alunoId);
            return View(turmas);
        }

        [HttpGet("turmas/{turmaId}/alunos")]
        public IActionResult GetAlunosByTurma(int turmaId)
        {
            var alunos = _alunoTurmaRepository.GetAlunosByTurma(turmaId);
            return View(alunos);
        }
    }
}
