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
using PostoGasolina.Business.Interfaces;
using PostoGasolina.Business.Models;

namespace PostoGasolina.App.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository,
                                  IClienteService clienteService,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetGridClientes(string data,int start, int limit, string query)
        {

            List<ClienteViewModel> clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos(start, limit)).ToList();
            
            var totalRegistros = await _clienteRepository.TotalRegistros();

            return Json(new
            {
                data = clientes,
                total = totalRegistros,
                success = true
            });
        }

        public async Task<IActionResult> GetComboClientes(string data, int start, int limit, string query)
        {

            if (data == null && query != null || data != null && query != null)
            {
                List<ClienteViewModel> clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos(start, limit)).ToList();

                clientes.Remove(clientes.LastOrDefault());

                clientes.Add(_mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(Guid.Parse(query))));
                
                var totalRegistros = await _clienteRepository.TotalRegistros();

                return Json(new
                {
                    data = clientes,
                    total = totalRegistros,
                    success = true
                });
            }
            if (data != null && query == null)
            {
                Guid id = Guid.Parse(data);

                ClienteViewModel cliente = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

                return Json(new
                {
                    data = cliente,
                    success = true
                });
            }
            else
            {
                List<ClienteViewModel> clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos(start, limit)).ToList();

                var totalRegistros = await _clienteRepository.TotalRegistros();

                return Json(new
                {
                    data = clientes,
                    total = totalRegistros,
                    success = true
                });
            }
        }

       [HttpPost]
        public async Task<IActionResult> SaveCliente(string data)
        {
            var clienteViewModel = JsonConvert.DeserializeObject<ClienteViewModel>(data);

            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);

                await _clienteService.Adicionar(cliente);
            }

            return Json(new
            {
                success = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditCliente(string data)
        {
            var clienteViewModel = JsonConvert.DeserializeObject<ClienteViewModel>(data);

            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);

                await _clienteService.Atualizar(cliente);
            }

            return Json(new
            {
                success = true
            });
        }

       [HttpPost]
        public async Task<IActionResult> DeleteCliente(string data)
        {
            var result = JsonConvert.DeserializeObject<ClienteViewModel>(data);

            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(result.Id));

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            await _clienteService.Remover(clienteViewModel.Id);

            return Json(new
            {
                success = true
            });
        }
    }
}
