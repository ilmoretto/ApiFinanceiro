using ApiFinanceiro.DataContexts;
using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiFinanceiro.Exceptions;

namespace ApiFinanceiro.Services
{
    public class DespesaServices
    {
        private readonly AppDbContext _context;

        public DespesaServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Despesa>> FindAll()
        {
            try
            {
                return await _context.Despesas.ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Despesa> FindById(int id)
        {
            try
            {
                var despesa = await _context.Despesas.FirstOrDefaultAsync(x => x.Id == id);
                if (despesa is null)
                {
                    throw new NotFoundException($"Despesa #{id} não encontrada");
                }

                return despesa;

            }
            catch (Exception e)
            {
                throw;

            }

        }
        public async Task<Despesa> Create(DespesaDto novaDespesa)
        {
            try
            {
                var despesa = new Despesa
                {
                    Descricao = novaDespesa.Descricao,
                    Valor = novaDespesa.Valor,
                    Categoria = novaDespesa.Categoria,
                    DataVencimento = novaDespesa.DataVencimento,
                    Situacao = "Pendente"
                };
                await _context.Despesas.AddAsync(despesa);
                await _context.SaveChangesAsync();

                return despesa;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<Despesa> Update(int id, DespesaUpdateDto despesaDto)
        {
            try
            {
                var despesa = await FindById(id);

                var dataPagamento = new DateTime(despesaDto.DataPagamento.Year, despesaDto.DataPagamento.Month, despesaDto.DataPagamento.Day);

                despesa.Descricao = despesaDto.Descricao;
                despesa.Valor = despesaDto.Valor;
                despesa.DataVencimento = despesaDto.DataVencimento;
                despesa.Categoria = despesaDto.Categoria;
                despesa.Situacao = despesaDto.Situacao;
                despesa.DataPagamento = dataPagamento;

                _context.Despesas.Update(despesa);
                await _context.SaveChangesAsync();

                return despesa;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Despesa> Remove(int id)
        {
            try
            {
                var despesa = await FindById(id);
                _context.Despesas.Remove(despesa);
                await _context.SaveChangesAsync();
                return despesa;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
