using Microsoft.EntityFrameworkCore;
using PostoGasolina.Business.Models;
using PostoGasolina.Business.Interfaces;
using PostoGasolina.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostoGasolina.Infra.Repository
{
    public class AbastecimentoRepository : Repository<Abastecimento>, IAbastecimentoRepository
    {
        public AbastecimentoRepository(PostoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Abastecimento>> ObterAbastecimentosCliente()
        {
            return await Db.Abastecimentos.AsNoTracking()
                .Include(a => a.Cliente)
                .OrderBy(a => a.DataAbastecimento)
                .ToListAsync();
        }

        public async Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorCliente(Guid clienteid, int start, int limit)
        {
            return await Buscar(a => a.ClienteId == clienteid, start, limit);
        }

        public async Task<IEnumerable<Abastecimento>> ObterAbastecimentosVeiculo()
        {
            return await Db.Abastecimentos.AsNoTracking()
                .Include(a => a.Veiculo)
                .OrderBy(a => a.DataAbastecimento)
                .ToListAsync();
        }

        public async Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorVeiculo(Guid veiculoId, int start, int limit)
        {
            return await Buscar(a => a.VeiculoId == veiculoId, start, limit);
        }

        public async Task<IEnumerable<Abastecimento>> ObterAbastecimentosVeiculoCliente(int start, int limit)
        {
            return await Db.Abastecimentos.AsNoTracking()
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .Include(a => a.TipoCombustivel)
                .OrderBy(a => a.DataAbastecimento)
                .Skip(start)
                .Take(limit)
                .ToListAsync();
        }
    }
}
