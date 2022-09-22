using PostoGasolina.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {

        Task<IEnumerable<Veiculo>> ObterVeiculosCliente(int start, int limit);
        Task<IEnumerable<Veiculo>> ObterVeiculosPorCliente(Guid clienteId, int start, int limit);
        
        
    }
}
