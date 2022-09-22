using PostoGasolina.Business.Interfaces;
using PostoGasolina.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Services
{
    public class VeiculoService : BaseService, IVeiculoService
    {
        public VeiculoService(INotificador notificador) : base(notificador)
        {
        }

        public Task Adicionar(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
