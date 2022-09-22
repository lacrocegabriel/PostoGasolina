using PostoGasolina.Business.Interfaces;
using PostoGasolina.Business.Models;
using PostoGasolina.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento, 1,25).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado");
                return;
            }

            await _clienteRepository.Adicionar(cliente);
        }

        public Task Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           _clienteRepository?.Dispose();
        }
    }
}
