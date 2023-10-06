using Microsoft.AspNetCore.Mvc;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private readonly TurmaRepository _turmaRepository;

        public TurmaController(TurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_turmaRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TurmaModel turma)
        {
            _turmaRepository.Add(turma);
            return CreatedAtAction(nameof(Get), new { id = turma.Id }, turma);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TurmaModel turma)
        {
            if (id != turma.Id)
            {
                return BadRequest();
            }

            _turmaRepository.Update(turma);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _turmaRepository.Delete(id);
            return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
