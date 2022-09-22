using PostoGasolina.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostoGasolina.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> ObterPorId(Guid id);
        Task<TEntity> ObterPorFiltro(string query);
        Task<List<TEntity>> ObterTodos(int start, int limit);
        Task<int> TotalRegistros();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate, int start, int limit);
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<int> SaveChanges();
    }
}
