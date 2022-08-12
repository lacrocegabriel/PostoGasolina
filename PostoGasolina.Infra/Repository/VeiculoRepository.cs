using PostoGasolina.Business.Models;
using PostoGasolina.Business.Models.Interfaces;
using PostoGasolina.Infra.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostoGasolina.Infra.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(PostoDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculosPorCliente(Guid clienteId)
        {
            return await Buscar(v => v.ClienteId == clienteId);
        }
    }
}
