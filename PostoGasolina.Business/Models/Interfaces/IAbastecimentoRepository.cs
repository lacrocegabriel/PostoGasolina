using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Models.Interfaces
{
    public interface IAbastecimentoRepository<TEntity> : IRepository<Abastecimento>
    {
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorVeiculo(Guid veiculoId);
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorCliente(Guid clienteid);
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosClienteVeiculo();

    }
}
