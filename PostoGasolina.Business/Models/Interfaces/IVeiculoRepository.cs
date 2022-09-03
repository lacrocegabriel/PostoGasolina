﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Models.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {

        Task<IEnumerable<Veiculo>> ObterVeiculosCliente();
        Task<IEnumerable<Veiculo>> ObterVeiculosPorCliente(Guid clienteId);
        
        
    }
}
