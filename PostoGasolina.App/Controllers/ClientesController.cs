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
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, 
                                  IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string data)
        {

            if (data == null)
            {
                List<ClienteViewModel> a = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()).ToList();

                return Json(new
                {
                    data = a,
                    success = true
                });
            }
            else
            {
                Guid id = Guid.Parse(data);

                ClienteViewModel a = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

                return Json(new
                {
                    data = a,
                    success = true
                });
            }
            //return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
                
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string data)
        {

            var clienteViewModel = JsonConvert.DeserializeObject<ClienteViewModel>(data);

            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);

                await _clienteRepository.Adicionar(cliente);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
            
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            
            return View(clienteViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string data)
        {
            var clienteViewModel = JsonConvert.DeserializeObject<ClienteViewModel>(data);

            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);

                await _clienteRepository.Atualizar(cliente);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
            
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string data)
        {

            var result = JsonConvert.DeserializeObject<ClienteViewModel>(data);

            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(result.Id));

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            await _clienteRepository.Remover(clienteViewModel.Id);

            return RedirectToAction("Index");
        }
    }
}
