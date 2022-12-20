namespace Poems.Models.Repositories;

public interface IRepository<TEntity>
{
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity> Find(Guid id);
    public Task Create(TEntity entity);
    public Task Delete(TEntity entity);
    public Task SaveChanges();
}