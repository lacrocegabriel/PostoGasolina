using System;

namespace PostoGasolina.Business.Models.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

    }
}
