using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Models.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteVeiculos(Guid id);
        Task<int> TotalRegistrosPorFiltro(string query);
        Task<Cliente> ObterClienteAbastecimentos(Guid id);
        Task<Cliente> ObterClienteVeiculosAbastecimentos(Guid id);
        
    }
}
