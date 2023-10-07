using System.ComponentModel.DataAnnotations;

namespace OperacoesAlunoTurma.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insira um ID de curso.")]
        public int CursoId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insira uma turma.")]
        [MaxLength(45)]
        public string? Turma { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insira um ano.")]
        [MaxLength(4)]
        public int Ano { get; set; }
    }
}
