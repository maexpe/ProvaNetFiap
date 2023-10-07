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
        [MaxLength(60)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$#&*{},=().+;'/!%^?\:|<>]).{12,}+$", ErrorMessage = @"Senha inválida. \nSenha deve possuir pelo menos: \n- 12 caracteres \n- uma letra minúscula \n- uma letra maiúscula \n-um número \n- um caractere especial")]
        public string? Senha { get; set; }
    }
}
