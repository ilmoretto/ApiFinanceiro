using System.ComponentModel.DataAnnotations;

namespace ApiFinanceiro.Dtos
{
    public class LoginDto
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        [MinLength(5)]
        public required string Password { get; set; }
    }
}
