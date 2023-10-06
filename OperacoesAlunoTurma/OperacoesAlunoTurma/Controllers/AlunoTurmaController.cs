using Microsoft.AspNetCore.Mvc;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : Controller
    {
        private readonly AlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaController(AlunoTurmaRepository alunoTurmaRepository)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        [HttpPost]
        public IActionResult Associate([FromBody] AlunoTurmaModel alunoTurma)
        {
            if (_alunoTurmaRepository.AssociacaoExiste(alunoTurma.AlunoId, alunoTurma.TurmaId))
            {
                return BadRequest("Associação já existe.");
            }

            _alunoTurmaRepository.AddAssociacao(alunoTurma.AlunoId, alunoTurma.TurmaId);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Disassociate(int alunoId, int turmaId)
        {
            _alunoTurmaRepository.DeleteAssociacao(alunoId, turmaId);
            return NoContent();
        }

        [HttpGet("Alunos/{alunoId}/Turmas")]
        public IActionResult GetTurmasByAluno(int alunoId)
        {
            return Ok(_alunoTurmaRepository.GetTurmasByAluno(alunoId));
        }

        [HttpGet("Turmas/{turmaId}/Alunos")]
        public IActionResult GetAlunosByTurma(int turmaId)
        {
            return Ok(_alunoTurmaRepository.GetAlunosByTurma(turmaId));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
