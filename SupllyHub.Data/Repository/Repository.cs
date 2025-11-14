using SupllyHub.Business.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using SupllyHub.Business.Models;
using SupllyHub.Data.Context;
using System.Linq.Expressions;

namespace SupllyHub.Data.Repository;
public abstract class Repository<TEntity>(MyDbContext context) : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MyDbContext Context = context;
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public virtual Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        return SaveChanges();
    }

    public virtual async Task Delete(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id});
        await SaveChanges();
    }

    public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate) =>
        await DbSet.AsNoTracking().Where(predicate).ToListAsync();

    public virtual async Task<IEnumerable<TEntity>> GetAll() =>
        await DbSet.ToListAsync();

    public virtual async Task<TEntity> GetById(Guid id) => await DbSet.FindAsync(id);

    public virtual async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public async Task<int> SaveChanges() => 
        await Context.SaveChangesAsync();

    public void Dispose() => Context?.Dispose();
}