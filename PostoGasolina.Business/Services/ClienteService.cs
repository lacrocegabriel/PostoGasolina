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
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IAbastecimentoRepository _abastecimentoRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              IVeiculoRepository veiculoRepository,
                              IAbastecimentoRepository abastecimentoRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _veiculoRepository = veiculoRepository;
            _abastecimentoRepository = abastecimentoRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {

            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            cliente.DataCadastro = cliente.DataCadastro.Value.ToUniversalTime();

            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento, 1,25).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado");
                return;
            }

            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {

            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return;

            cliente.DataCadastro = cliente.DataCadastro.Value.ToUniversalTime();

            if (_clienteRepository.Buscar(c => c.Documento == cliente.Documento && c.Id != cliente.Id, 1, 25).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado");
                return;
            }

            await _clienteRepository.Atualizar(cliente);
        }

        public async Task Remover(Guid id)
        {
            if (_veiculoRepository.Buscar(v => v.Cliente.Id == id, 1, 25).Result.Any())
            {
                Notificar("Não é possível excluir, pois existem veículos cadastrados para esse cliente!");
                return;
            }

            if (_abastecimentoRepository.Buscar(a => a.ClienteId == id, 1, 25).Result.Any())
            {
                Notificar("Não é possível excluir, pois existem abastecimentos cadastrados para esse cliente!");
                return;
            }

            await _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
           _clienteRepository?.Dispose();
        }
    }
}
