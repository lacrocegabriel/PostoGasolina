using PostoGasolina.Business.Models;
using System;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Interfaces
{
    public interface IVeiculoService : IDisposable
    {
        Task Adicionar(Veiculo veiculo);
        Task Atualizar(Veiculo veiculo);
        Task Remover(Guid id);
    }
}
