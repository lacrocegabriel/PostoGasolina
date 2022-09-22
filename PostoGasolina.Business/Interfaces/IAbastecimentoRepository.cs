using PostoGasolina.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Interfaces
{
    public interface IAbastecimentoRepository : IRepository<Abastecimento>
    {
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorVeiculo(Guid veiculoId, int start, int limit);
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosPorCliente(Guid clienteid, int start, int limit);
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosCliente();
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosVeiculo();
        Task<IEnumerable<Abastecimento>> ObterAbastecimentosVeiculoCliente(int start, int limit);

    }
}
