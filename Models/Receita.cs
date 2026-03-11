namespace ApiFinanceiro.Models
{
    public class Receita
    {
        // Dados: Id, Descrição, Valor, Data Previsão, Data Recebimento, Categoria, Observação, Situação (pendente/recebido)
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Descricao { get; set; }
        public required decimal Valor { get; set; }
        public required DateOnly DataPrevisao { get; set; }
        public DateTime? DataRecebimento { get; set; }
        public required string Categoria { get; set; }
        public required string Observacao { get; set; }
        public required string Situacao { get; set; }

    }
}
