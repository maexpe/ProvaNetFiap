using Microsoft.AspNetCore.Mvc;
using OperacoesAlunoTurma.Interfaces.Services;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;
using OperacoesAlunoTurma.Services;

namespace OperacoesAlunoTurma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var turmas = _turmaService.GetAll();
            return View(turmas);
        }

        //[HttpGet("create")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Create([FromForm] TurmaModel turma)
        {
            if (!ModelState.IsValid)
            {
                return View(turma);
            }

            _turmaService.Add(turma);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/edit")]
        public IActionResult Edit([FromForm] int id)
        {
            var turma = _turmaService.GetById(id);
            if (turma == null)
                return NotFound();

            return View(turma);
        }

        [HttpPut("{id}/edit")]
        public IActionResult Edit(int id, [FromForm] TurmaModel turma)
        {
            if (id != turma.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _turmaService.Update(turma);
                return Json(new { message = "Atualização bem sucedida." });
            }

            return View(turma);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _turmaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
