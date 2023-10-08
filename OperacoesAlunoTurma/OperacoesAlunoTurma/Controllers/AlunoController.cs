using Microsoft.AspNetCore.Mvc;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly AlunoRepository _alunoRepository;

        public AlunoController(AlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var alunos = _alunoRepository.GetAll();
            return View(alunos);
        }

        //[HttpGet("create")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Create([FromForm] AlunoModel aluno)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno);
            }

            _alunoRepository.Add(aluno);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/edit")]
        public IActionResult Edit(int id)
        {
            var aluno = _alunoRepository.GetById(id);
            if (aluno == null)
                return NotFound();

            return View(aluno);
        }

        [HttpPut("{id}/edit")]
        public IActionResult Edit(int id, AlunoModel aluno)
        {
            if (id != aluno.Id || aluno == null | aluno.Id <= 0)
                return BadRequest(new { message = "Dados de aluno inválidos." });

            _alunoRepository.Update(aluno);
            return Json(new { message = "Atualização bem sucedida." });
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            _alunoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
