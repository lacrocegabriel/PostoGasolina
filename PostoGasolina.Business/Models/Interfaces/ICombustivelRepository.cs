﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Models.Interfaces
{
    public interface ICombustivelRepository<TEntity> : IRepository<Combustivel>
    {
        Task<Combustivel> ObterSaldoCombustivel(Guid id);
    }
}
