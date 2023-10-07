using System.ComponentModel.DataAnnotations;

namespace OperacoesAlunoTurma.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage="Insira um nome.")]
        [MaxLength(255)]
        public string? Nome { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insira um usuário.")]
        [MaxLength(45)]
        public string? Usuario { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Insira uma senha.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$#&*{},=().+;'/!%^?\:|<>]).{12,60}+$", ErrorMessage = "Senha fraca. Use uma combinação de 12 a 60 caracteres com letras maiúsculas, minúsculas, números e caracteres especiais.")]
        public string? Senha { get; set; }
    }
}
