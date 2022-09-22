using PostoGasolina.Business.Models;
using PostoGasolina.Business.Interfaces;
using PostoGasolina.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PostoGasolina.Infra.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PostoDbContext db) : base(db)
        {
        }

        public async Task<Cliente> ObterClienteAbastecimentos(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Veiculos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterClienteVeiculos(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Veiculos)
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Cliente> ObterClienteVeiculosAbastecimentos(Guid id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Veiculos)
                .Include(c => c.Abastecimentos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> TotalRegistrosPorFiltro(string query)
        {
            var total = await Db.Clientes.CountAsync(c => c.Nome.Contains(query));

            return total;
        }
    }
}
