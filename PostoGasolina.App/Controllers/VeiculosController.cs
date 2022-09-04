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
using PostoGasolina.Business.Models.Interfaces;

namespace PostoGasolina.App.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculosController(IVeiculoRepository veiculoRepository, 
                                  IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string data, int start, int limit)
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

                List<VeiculoViewModel> veiculos = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterVeiculosPorCliente(id)).ToList();

                return Json(new
                {
                    data = veiculos,
                    success = true
                });
            }            
        }

        public async Task<IActionResult> Details(Guid id)
        {

            return View( _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id)));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string data)
        {

            var veiculoViewModel = JsonConvert.DeserializeObject<VeiculoViewModel>(data);

            if (ModelState.IsValid)
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);

                await _veiculoRepository.Adicionar(veiculo);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));
            
            if (veiculoViewModel == null)
            {
                return NotFound();
            }

            return View(veiculoViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string data)
        {
            var veiculoViewModel = JsonConvert.DeserializeObject<VeiculoViewModel>(data);

            if (ModelState.IsValid)
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);

                await _veiculoRepository.Atualizar(veiculo);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));

            if (veiculoViewModel == null)
            {
                return NotFound();
            }

            return View(veiculoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string data)
        {
            var result = JsonConvert.DeserializeObject<VeiculoViewModel>(data);

            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(result.Id));

            if (veiculoViewModel == null)
            {
                return NotFound();
            }

            await _veiculoRepository.Remover(result.Id);

            return RedirectToAction("Index");            
        }

    }
}
