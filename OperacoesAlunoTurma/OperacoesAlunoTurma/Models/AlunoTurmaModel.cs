namespace OperacoesAlunoTurma.Models
{
    public class AlunoTurmaModel
    {
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }

        // Propriedades de navegação

        public AlunoModel Aluno { get; set; }
        public TurmaModel Turma { get; set; } 
    }
}
