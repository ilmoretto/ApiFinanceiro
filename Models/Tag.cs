using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiFinanceiro.Models
{
    [Table("Tags"), PrimaryKey(nameof(Id))]
    public class Tag
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public required string Nome { get; set; }


        public ICollection<Despesa>? Despesas { get; set; }
    }
}
