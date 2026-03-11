using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceiro.Controllers
{
    [Route("receitas/")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private static List<Receita> listaReceitas = new()
        {
            new Receita
            {
                Descricao = "Salário",
                Valor = 5000,
                Categoria = "Trabalho",
                DataPrevisao = new DateOnly(2026, 03, 01),
                DataRecebimento = new DateTime(2026, 03, 01),
                Observacao = "",
                Situacao = "Recebida"
            },
            new Receita
            {
                Descricao = "Freelance",
                Valor = 1500,
                Categoria = "Trabalho",
                DataPrevisao = new DateOnly(2026, 03, 10),
                DataRecebimento = new DateTime(2026, 03, 10),
                Observacao = "",
                Situacao = "Recebida"
            }       
        };

        [HttpGet()]
        public ActionResult FindAll()
        {
            return Ok(listaReceitas);
        }

        [HttpPost()]
        public ActionResult Create([FromBody] ReceitaDto novaReceita)
        {
            var receita = new Receita
            {
                Descricao = novaReceita.Descricao,
                Valor = novaReceita.Valor,
                Categoria = novaReceita.Categoria,
                DataPrevisao = novaReceita.DataPrevisao,
                DataRecebimento = null,
                Observacao = "",
                Situacao = "Pendente"
            };
            listaReceitas.Add(receita);
            return CreatedAtAction(nameof(FindAll), receita);

        }

        [HttpGet("{id}")]
        public ActionResult FindById(Guid id)
        {
            var receita = listaReceitas.FirstOrDefault(r => r.Id == id);
            if (receita is null) {
                return NotFound(new { mensagem = $"Receita #{id} não encontrada" });
            }
            return Ok(receita);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] ReceitaDto receitaDto)
        {
            var receita = listaReceitas.FirstOrDefault(d => d.Id == id);

            if (receita is null)
            {
                return NotFound(new { mensagem = $"Receita #{id} não encontrada" });
            }

            var dataRecebimento = new DateTime(receitaDto.DataRecebimento.Year, receitaDto.DataRecebimento.Month, receitaDto.DataRecebimento.Day);

            receita.Categoria = receitaDto.Categoria;
            receita.Descricao = receitaDto.Descricao;
            receita.Observacao = receitaDto.Observacao;
            receita.Valor = receitaDto.Valor;
            receita.DataPrevisao = receitaDto.DataPrevisao;
            receita.DataRecebimento = dataRecebimento;

            return Ok(receita);

        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var receita = listaReceitas.FirstOrDefault(d => d.Id == id);

            if (receita is null)
            {
                return NotFound(new { mensagem = $"Receita #{id} não encontrada" });
            }

            listaReceitas.Remove(receita);

            return NoContent();
        }


    }
}
