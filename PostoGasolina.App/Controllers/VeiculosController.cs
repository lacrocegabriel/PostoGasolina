using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class VeiculosController : BaseController
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;

        public VeiculosController(IVeiculoRepository veiculoRepository, 
                                  IMapper mapper,
                                  IVeiculoService veiculoService,
                                  INotificador notificador) : base(notificador)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _veiculoService = veiculoService;
        }

        public async Task<IActionResult> GetGridVeiculos(string data, int start, int limit, string query)
        {

            if (data == null)
            {
                List<VeiculoViewModel> veiculos = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterVeiculosCliente(start,limit)).ToList();

                var totalRegistros = await _veiculoRepository.TotalRegistros();

                return Json(new
                {
                    data = veiculos,
                    total = totalRegistros,
                    success = true
                });

            }
            else
            {
                Guid id = Guid.Parse(data);

                List<VeiculoViewModel> veiculos = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterVeiculosPorCliente(id, start, limit)).ToList();

                return Json(new
                {
                    data = veiculos,
                    success = true
                });
            }            
        }
        public async Task<IActionResult> GetComboVeiculos(string data, int start, int limit, string query)
        {

            if (data == null)
            {
                List<VeiculoViewModel> veiculos = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterVeiculosCliente(start, limit)).ToList();

                var totalRegistros = await _veiculoRepository.TotalRegistros();

                return Json(new
                {
                    success = true
                });

            }
            else
            {
                Guid id = Guid.Parse(data);

                List<VeiculoViewModel> veiculos = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterVeiculosPorCliente(id, start, limit)).ToList();

                return Json(new
                {
                    data = veiculos,
                    success = true
                });
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> SaveVeiculo(string data)
        {

            var veiculoViewModel = JsonConvert.DeserializeObject<VeiculoViewModel>(data);

            if (ModelState.IsValid)
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);

                await _veiculoService.Adicionar(veiculo);

                if (!OperacaoValida())
                {
                    var msg = Notificacoes();

                    if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
                }
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> EditVeiculo(string data)
        {
            var veiculoViewModel = JsonConvert.DeserializeObject<VeiculoViewModel>(data);

            if (ModelState.IsValid)
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);

                await _veiculoService.Atualizar(veiculo);

                if (!OperacaoValida())
                {
                    var msg = Notificacoes();

                    if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
                }
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVeiculo(string data)
        {
            var result = JsonConvert.DeserializeObject<VeiculoViewModel>(data);

            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(result.Id));

            if (veiculoViewModel == null)
            {
                return NotFound();
            }

            await _veiculoService.Remover(result.Id);

            if (!OperacaoValida())
            {
                var msg = Notificacoes();

                if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
            }

            return Json(new { success = true });
        }

    }
}
