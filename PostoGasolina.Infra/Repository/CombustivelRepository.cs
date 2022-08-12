using PostoGasolina.Business.Models;
using PostoGasolina.Business.Models.Interfaces;
using PostoGasolina.Infra.Context;
using System;
using System.Threading.Tasks;

namespace PostoGasolina.Infra.Repository
{
    public class CombustivelRepository : Repository<Combustivel>, ICombustivelRepository
    {
        public CombustivelRepository(PostoDbContext context) : base(context)
        {
        }

        public Task<Combustivel> ObterSaldoCombustivel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

