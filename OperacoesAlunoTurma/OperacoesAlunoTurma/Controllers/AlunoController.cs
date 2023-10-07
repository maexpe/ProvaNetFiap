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

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(AlunoModel aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoRepository.Add(aluno);
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
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
            if (id != aluno.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _alunoRepository.Update(aluno);
                return RedirectToAction(nameof(Index));
            }
            
            return View(aluno);
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            _alunoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
