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

            if (data != null)
            {
                var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(Guid.Parse(data)));

                //List<ClienteViewModel> clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterPorFiltro(start, limit, query)).ToList();

                var totalRegistros = await _clienteRepository.TotalRegistros();

                return Json(new
                {
                    data = clienteViewModel,
                    total = totalRegistros,
                    success = true
                });
            }
            if (query != null)
            {
                List<ClienteViewModel> clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterPorFiltro(start, limit, query)).ToList();

                var totalRegistros = await _clienteRepository.TotalRegistros();

                return Json(new
                {
                    data = clientes,
                    total = totalRegistros,
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

                if (!OperacaoValida())
                {
                    var msg = Notificacoes();

                    if (msg.Count > 0) return Json(new { success = false, data = msg });
                }
            } 
           
            return Json(new {success = true});

        }

        [HttpPost]
        public async Task<IActionResult> EditCliente(string data)
        {
            var clienteViewModel = JsonConvert.DeserializeObject<ClienteViewModel>(data);

            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteViewModel);

                await _clienteService.Atualizar(cliente);

                if (!OperacaoValida())
                {
                    var msg = Notificacoes();

                    if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
                }
            }

            return Json(new { success = true });
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

            if (!OperacaoValida())
            {
                var msg = Notificacoes();

                if (msg.Count > 0) return Json(new { success = false, data = msg.FirstOrDefault() });
            }

            return Json(new { success = true });
        }
    }
}
