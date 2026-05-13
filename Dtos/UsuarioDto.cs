using System.ComponentModel.DataAnnotations;

namespace ApiFinanceiro.Dtos
{
    public class UsuarioDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(5)]
        public required string Senha { get; set; }
    }
}
