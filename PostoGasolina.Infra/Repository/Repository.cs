using Microsoft.EntityFrameworkCore;
using PostoGasolina.Business.Models;
using PostoGasolina.Business.Interfaces;
using PostoGasolina.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostoGasolina.Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly PostoDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(PostoDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos(int start, int limit)
        {
            return
                await DbSet
                .OrderBy(x => x.Id)
                .Skip(start)
                .Take(limit)
                .ToListAsync();
        }
        public async Task<int> TotalRegistros()
        {
            var total = await DbSet.CountAsync();

            return total;
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate, int start, int limit)
        {
            return await DbSet.AsNoTracking()
                                .Where(predicate)
                                .Skip(start)
                                .Take(limit)
                                .ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        
    }
}
