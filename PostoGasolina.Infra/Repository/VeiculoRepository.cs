using Microsoft.EntityFrameworkCore;
using PostoGasolina.Business.Models;
using PostoGasolina.Business.Models.Interfaces;
using PostoGasolina.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostoGasolina.Infra.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(PostoDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculosCliente(int start, int limit)
        {
            return await Db.Veiculos.AsNoTracking()
                .Include(v => v.Cliente)
                .Include(v => v.TipoCombustivel)
                .OrderBy(v => v.Cliente.Nome)
                .Skip(start)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculosPorCliente(Guid clienteId)
        {
            return await Buscar(v => v.ClienteId == clienteId);
        }
    }
}
