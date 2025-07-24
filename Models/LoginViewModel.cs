using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuário é obrigatório")]
        [Display(Name = "Usuário")]
        public string? User { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }
    }
}