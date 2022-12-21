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
    public class AbastecimentoService : BaseService, IAbastecimentoService
    {

        private readonly IAbastecimentoRepository _abastecimentoRepository;

        public AbastecimentoService(IAbastecimentoRepository abastecimentoRepository,
                                    INotificador notificador) : base(notificador)
        {
            _abastecimentoRepository = abastecimentoRepository;
        }

        public async Task Adicionar(Abastecimento abastecimento)
        {
           
            if (!ExecutarValidacao(new AbastecimentoValidation(), abastecimento)) return;

            abastecimento.DataAbastecimento = abastecimento.DataAbastecimento.Value.ToUniversalTime();
           
            if (_abastecimentoRepository.Buscar(a => a.DataAbastecimento == abastecimento.DataAbastecimento && a.VeiculoId == abastecimento.VeiculoId, 1, 25).Result.Any())
            {
                Notificar("Já existe um abastecimento com a mesma data para o veículo selecionado");
                return;
            }

            await _abastecimentoRepository.Adicionar(abastecimento);
        }

        public async Task Atualizar(Abastecimento abastecimento)
        {

            if (!ExecutarValidacao(new AbastecimentoValidation(), abastecimento)) return;

            abastecimento.DataAbastecimento = abastecimento.DataAbastecimento.Value.ToUniversalTime();

            if (_abastecimentoRepository.Buscar(a => a.DataAbastecimento == abastecimento.DataAbastecimento && a.VeiculoId == abastecimento.VeiculoId, 1, 25).Result.Any())
            {
                Notificar("Já existe um abastecimento com a mesma data para o veículo selecionado");
                return;
            }

            await _abastecimentoRepository.Atualizar(abastecimento);
        }

       public async Task Remover(Guid id)
        {
          await _abastecimentoRepository.Remover(id);
        }

        public void Dispose()
        {
            _abastecimentoRepository?.Dispose();
        }
    }
}
