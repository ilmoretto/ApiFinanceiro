using ApiFinanceiro.DataContexts;
using ApiFinanceiro.Dtos;
using ApiFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiFinanceiro.Exceptions;
using AutoMapper;

namespace ApiFinanceiro.Services
{
    public class DespesaServices
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public DespesaServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                    throw new ErrorServiceExcepion($"Despesa #{id} não encontrada",
                        c => c.NotFound(new { message = $"Despesa não encontrada" }));
                }

                return despesa;

            }
            catch (Exception e)
            {
                throw;

            }

        }
        public async Task<Despesa> Create(DespesaDto data)
        {
            try
            {
                var despesa = _mapper.Map<Despesa>(data); // Mapear o DTO para a entidade Despesa

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

                var dataVencimento = new DateTime(despesa.DataVencimento.Year, despesa.DataVencimento.Month, despesa.DataVencimento.Day);
                var dataPagamento = new DateTime(despesaDto.DataPagamento.Year, despesaDto.DataPagamento.Month, despesaDto.DataPagamento.Day);

                _mapper.Map(despesaDto, despesa);

                //TODO: adicionar data de emissão
                //if (dataPagamento < dataVencimento)
                //{
                //    throw new ErrorServiceExcepion($"É possível realizar o pagamento apenas no dia do vencimento.",
                //        c => c.Conflict(new { message = $"É possível realizar o pagamento apenas no dia do vencimento." }));
                //}

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
