using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinanceiro.Models
{
    [Table("categorias")]
    public class Categoria
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("Descricao")]
        public required string Descricao { get; set; }

        public ICollection<Despesa>? Despesas { get; set; }
    }
}
