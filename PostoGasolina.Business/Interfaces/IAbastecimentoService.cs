using PostoGasolina.Business.Models;
using System;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Interfaces
{
    public interface IAbastecimentoService : IDisposable
    {
        Task Adicionar(Abastecimento abastecimento);
        Task Atualizar(Abastecimento abastecimento);
        Task Remover(Guid id);
    }
}
