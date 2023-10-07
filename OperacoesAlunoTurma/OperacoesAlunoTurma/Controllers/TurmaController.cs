using Microsoft.AspNetCore.Mvc;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private readonly TurmaRepository _turmaRepository;

        public TurmaController(TurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var turmas = _turmaRepository.GetAll();
            return View(turmas);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(TurmaModel turma)
        {
            if (ModelState.IsValid)
            {
                _turmaRepository.Add(turma);
                return RedirectToAction(nameof(Index));
            }

            return View(turma);
        }

        [HttpGet("{id}/edit")]
        public IActionResult Edit(int id)
        {
            var turma = _turmaRepository.GetById(id);
            if (turma == null)
                return NotFound();

            return View(turma);
        }

        [HttpPut("{id}/edit")]
        public IActionResult Edit(int id, TurmaModel turma)
        {
            if (id != turma.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _turmaRepository.Update(turma);
                return RedirectToAction(nameof(Index));
            }

            return View(turma);
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            _turmaRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
