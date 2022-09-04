using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Models.Interfaces
{
    public interface IAbastecimentoRepository : IRepository<Abastecimento>
    {
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorVeiculo(Guid veiculoId);
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorCliente(Guid clienteid);
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosCliente();
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosVeiculo();
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosVeiculoCliente(int start, int limit);

    }
}
