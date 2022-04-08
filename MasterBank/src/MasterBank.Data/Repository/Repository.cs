using MasterBank.Business.Interfaces.Repository;
using MasterBank.Business.Models;
using MasterBank.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterBank.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly MasterBankDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MasterBankDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
