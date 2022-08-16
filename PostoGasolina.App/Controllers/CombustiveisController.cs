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
    public class CombustiveisController : Controller
    {
        private readonly ICombustivelRepository _combustivelRepository;
        private readonly IMapper _mapper;

        public CombustiveisController(ICombustivelRepository combustivelRepository,
                                      IMapper mapper)
        {
            _combustivelRepository = combustivelRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CombustivelViewModel>>(await _combustivelRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var combustivelViewModel = _mapper.Map<CombustivelViewModel>(await _combustivelRepository.ObterPorId(id));

            if (combustivelViewModel == null)
            {
                return NotFound();
            }

            return View(combustivelViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CombustivelViewModel combustivelViewModel)
        {
            if (ModelState.IsValid)
            {
                var combustivel = _mapper.Map<Combustivel>(combustivelViewModel);

                await _combustivelRepository.Adicionar(combustivel);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var combustivelViewModel = _mapper.Map<CombustivelViewModel>(await _combustivelRepository.ObterPorId(id));
            
            if (combustivelViewModel == null)
            {
                return NotFound();
            }
            
            return View(combustivelViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CombustivelViewModel combustivelViewModel)
        {
           if (ModelState.IsValid)
            {
                var combustivel = _mapper.Map<Combustivel>(combustivelViewModel);

                await _combustivelRepository.Atualizar(combustivel);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var combustivelViewModel = _mapper.Map<CombustivelViewModel>(await _combustivelRepository.ObterPorId(id));
                
            if (combustivelViewModel == null)
            {
                return NotFound();
            }

            return View(combustivelViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var combustivelViewModel = _mapper.Map<CombustivelViewModel>(await _combustivelRepository.ObterPorId(id));

            if (combustivelViewModel == null)
            {
                return NotFound();
;           }

            await _combustivelRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
