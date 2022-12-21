using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PostoGasolina.App.Data;
using PostoGasolina.App.ViewModels;
using PostoGasolina.Business.Models;
using PostoGasolina.Business.Interfaces;

namespace PostoGasolina.App.Controllers
{
    public class AbastecimentosController : BaseController
    {
        private readonly IAbastecimentoRepository _abastecimentoRepository;
        private readonly IAbastecimentoService _abastecimentoService;
        private readonly IMapper _mapper;

        public AbastecimentosController(IAbastecimentoRepository abastecimentoRepository,
                                        IAbastecimentoService abastecimentoService,
                                        IMapper mapper,
                                         INotificador notificador) : base(notificador)
        {
            _abastecimentoRepository = abastecimentoRepository;
            _abastecimentoService = abastecimentoService;
            _mapper = mapper;
            
        }

        public async Task<IActionResult> GetGridAbastecimentos(int start, int limit)
        {
            List<AbastecimentoViewModel> abastecimentos = _mapper.Map<IEnumerable<AbastecimentoViewModel>>(await _abastecimentoRepository.ObterAbastecimentosVeiculoCliente(start, limit)).ToList();

            var totalRegistros = await _abastecimentoRepository.TotalRegistros();

            return Json(new
            {
                data = abastecimentos,
                total = totalRegistros,
                success = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> SaveAbastecimento(string data)
        {

            if (ModelState.IsValid)
            {
                var abastecimento = _mapper.Map<Abastecimento>(JsonConvert.DeserializeObject<AbastecimentoViewModel>(data));

                await _abastecimentoService.Adicionar(abastecimento);

                if (!OperacaoValida())
                {
                    var msg = Notificacoes();

                    if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
                }
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> EditAbastecimento(string data)
        {

            if (ModelState.IsValid)
            {
                var abastecimento = _mapper.Map<Abastecimento>(JsonConvert.DeserializeObject<AbastecimentoViewModel>(data));

                await _abastecimentoService.Atualizar(abastecimento);

                if (!OperacaoValida())
                {
                    var msg = Notificacoes();

                    if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
                }
            }

            return Json(new { success = true });
        }

       [HttpPost]
        public async Task<IActionResult> DeleteAbastecimento(string data)
        {

            var abastecimento = JsonConvert.DeserializeObject<AbastecimentoViewModel>(data);

            var abastecimentoViewModel = _mapper.Map<AbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(abastecimento.Id));

            if (abastecimentoViewModel == null)
            {
                return NotFound();
            }

            await _abastecimentoRepository.Remover(abastecimento.Id);

            if (!OperacaoValida())
            {
                var msg = Notificacoes();

                if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
            }
            
            return Json(new { success = true });
        }

    }
}
