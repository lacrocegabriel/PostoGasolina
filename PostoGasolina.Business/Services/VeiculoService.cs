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
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IAbastecimentoRepository _abastecimentoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository,
                              IAbastecimentoRepository abastecimentoRepository,
                              INotificador notificador) : base(notificador)
        {
            _veiculoRepository = veiculoRepository;
            _abastecimentoRepository = abastecimentoRepository;
        }

        public async Task Adicionar(Veiculo veiculo)
        {
            if (_veiculoRepository.Buscar(v => v.Placa == veiculo.Placa, 1, 25).Result.Any())
            {
                Notificar("Já existe um veículo com a mesma placa informada");
                return;
            }

            await _veiculoRepository.Adicionar(veiculo);
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            if (_veiculoRepository.Buscar(v => v.Placa == veiculo.Placa, 1, 25).Result.Any())
            {
                Notificar("Já existe um veículo com a mesma placa informada");
                return;
            }

            await _veiculoRepository.Atualizar(veiculo);
        }

        public async Task Remover(Guid id)
        {
            if ( _abastecimentoRepository.Buscar(a => a.VeiculoId == id,1,25).Result.Any())
            {
                Notificar("Existem abastecimentos vinculados a este veículo, portanto sua exclusão não será realizada!");
                return;
            }

            await _veiculoRepository.Remover(id);
        }

        public void Dispose()
        {
            _veiculoRepository?.Dispose();
        }
    }
}
