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

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AbastecimentoViewModel>>(await _abastecimentoRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var abastecimentoViewModel = _mapper.Map<AbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(id));

            if (abastecimentoViewModel == null)
            {
                return NotFound();
            }

            return View(abastecimentoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AbastecimentoViewModel abastecimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var abastecimento = _mapper.Map<Abastecimento>(abastecimentoViewModel);

                await _abastecimentoRepository.Adicionar(abastecimento);
            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var abastecimentoViewModel = _mapper.Map<AbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(id));
            
            if (abastecimentoViewModel == null)
            {
                return NotFound();
            }
            
            return View(abastecimentoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AbastecimentoViewModel abastecimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var abastecimento = _mapper.Map<Abastecimento>(abastecimentoViewModel);    

                await _abastecimentoRepository.Atualizar(abastecimento);
            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var abastecimentoViewModel = _mapper.Map<AbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(id));
                
            if (abastecimentoViewModel == null)
            {
                return NotFound();
            }

            return View(abastecimentoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var abastecimentoViewModel = _mapper.Map<AbastecimentoViewModel>(await _abastecimentoRepository.ObterPorId(id));

            if (abastecimentoViewModel == null)
            {
                return NotFound();
            }

            await _abastecimentoRepository.Remover(id);

            return RedirectToAction("Index");
        }

    }
}
