using PostoGasolina.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteVeiculos(Guid id);
        Task<int> TotalRegistrosPorFiltro(string query);
        Task<Cliente> ObterClienteAbastecimentos(Guid id);
        Task<Cliente> ObterClienteVeiculosAbastecimentos(Guid id);
        Task<List<Cliente>> ObterPorFiltro(int start, int limit, string query);

    }
}
