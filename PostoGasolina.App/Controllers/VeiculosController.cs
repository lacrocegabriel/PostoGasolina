using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index(string data)
        {

            if (data == null)
            {
                List<VeiculoViewModel> a = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos()).ToList();

                return Json(new
                {
                    data = a,
                    success = true
                });

            }
            else
            {
                Guid id = Guid.Parse(data);

                List<VeiculoViewModel> a = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterVeiculosPorCliente(id)).ToList();

                return Json(new
                {
                    data = a,
                    success = true
                });
            }


            


            //return View(_mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos()));
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VeiculoViewModel veiculoViewModel)
        {
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VeiculoViewModel veiculoViewModel)
        {
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterPorId(id));

            if (veiculoViewModel == null)
            {
                return NotFound();
            }

            await _veiculoRepository.Remover(id);

            return RedirectToAction("Index");            
        }

    }
}
