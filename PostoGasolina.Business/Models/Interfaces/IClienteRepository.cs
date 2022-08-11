using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Models.Interfaces
{
    public interface IClienteRepository<TEntity> : IRepository<Cliente>
    {
        Task<Cliente> ObterClienteVeiculos(Guid id);
        Task<Cliente> ObterClienteAbastecimentos(Guid id);
        Task<Cliente> ObterClienteVeiculosAbastecimentos(Guid id);
        
    }
}
