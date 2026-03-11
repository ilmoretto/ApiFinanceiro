using System.ComponentModel.DataAnnotations;

namespace ApiFinanceiro.Dtos
{
    public class ReceitaDto
    {
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório mínimo de 5 caracteres")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public required decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo DataPrevisão é obrigatório")]
        public required DateOnly DataPrevisao { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório mínimo de 5 caracteres")]
        public required string Categoria { get; set; }

        public DateTime DataRecebimento { get; set; }
        public required string Observacao { get; set; }
        public required string Situacao { get; set; }


    }
}
