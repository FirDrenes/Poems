namespace Poems.Models.Repositories;

public class AuthorsRepository : IRepository<Author>
{
    private DbContext _context;

    public AuthorsRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return _context.Authors;
    }

    public async Task<Author> Find(Guid id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task Create(Author entity)
    {
        await _context.Authors.AddAsync(entity);
    }

    public async Task Delete(Author entity)
    {
        _context.Authors.Remove(entity);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}