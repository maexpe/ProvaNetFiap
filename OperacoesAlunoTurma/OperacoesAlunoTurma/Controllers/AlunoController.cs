using Microsoft.AspNetCore.Mvc;
using OperacoesAlunoTurma.Models;
using OperacoesAlunoTurma.Repositories;

namespace OperacoesAlunoTurma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly AlunoRepository _alunoRepository;

        public AlunoController(AlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_alunoRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlunoModel aluno)
        {
            _alunoRepository.Add(aluno);
            return CreatedAtAction(nameof(Get), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlunoModel aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }

            _alunoRepository.Update(aluno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _alunoRepository.Delete(id);
            return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
