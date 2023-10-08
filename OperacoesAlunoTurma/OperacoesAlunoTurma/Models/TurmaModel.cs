using System.ComponentModel.DataAnnotations;

namespace OperacoesAlunoTurma.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string? Turma { get; set; }
        public int Ano { get; set; }
    }
}
