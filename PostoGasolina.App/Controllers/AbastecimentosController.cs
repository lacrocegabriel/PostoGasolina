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
using PostoGasolina.Business.Models.Interfaces;

namespace PostoGasolina.App.Controllers
{
    public class AbastecimentosController : Controller
    {
        private readonly IAbastecimentoRepository _abastecimentoRepository;
        private readonly IMapper _mapper;

        public AbastecimentosController(IAbastecimentoRepository abastecimentoRepository, 
                                        IMapper mapper)
        {
            _abastecimentoRepository = abastecimentoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetGridAbastecimentos(int start, int limit)
        {
            List<AbastecimentoViewModel> abastecimentos = _mapper.Map<IEnumerable<AbastecimentoViewModel>>(await _abastecimentoRepository.ObterAbastecimentosVeiculoCliente(start, limit)).ToList();

            var totalRegistros = _abastecimentoRepository.TotalRegistros();

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

            var json = JsonConvert.DeserializeObject<AbastecimentoViewModel>(data);

            if (ModelState.IsValid)
            {
                var abastecimento = _mapper.Map<Abastecimento>(json);

                await _abastecimentoRepository.Adicionar(abastecimento);
            }

            return Json(new
            {
                success = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditAbastecimento(string data)
        {

            var json = JsonConvert.DeserializeObject<AbastecimentoViewModel>(data);

            if (ModelState.IsValid)
            {
                var abastecimento = _mapper.Map<Abastecimento>(json);    

                await _abastecimentoRepository.Atualizar(abastecimento);
            }
            
            return Json(new
            {
                success = true
            });
        }

       [HttpPost]
        public async Task<IActionResult> DeleteAbastecimento(string data)
        {

            var json = JsonConvert.DeserializeObject<AbastecimentoViewModel>(data);

            var abastecimentoViewModel = _mapper.Map<AbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(json.Id));

            if (abastecimentoViewModel == null)
            {
                return NotFound();
            }

            await _abastecimentoRepository.Remover(json.Id);

            return Json(new
            {
                success = true
            });
        }

    }
}
