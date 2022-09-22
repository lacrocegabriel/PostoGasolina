using PostoGasolina.Business.Interfaces;
using PostoGasolina.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Services
{
    public class AbastecimentoService : BaseService, IAbastecimentoService
    {
        public AbastecimentoService(INotificador notificador) : base(notificador)
        {
        }

        public Task Adicionar(Abastecimento abastecimento)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Abastecimento abastecimento)
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
