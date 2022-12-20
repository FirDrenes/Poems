using Microsoft.EntityFrameworkCore;

namespace Poems.Models.Repositories;

public class PoemsRepository : IRepository<Poem>
{
    private DbContext _context;

    public PoemsRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Poem>> GetAll()
    {
        return _context.Poems.Include(x => x.Author)
                             .Include(x => x.Comments);
    }

    public async Task<Poem> Find(Guid id)
    {
        return await _context.Poems.Include(x => x.Author)
            .Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(Poem entity)
    {
        await _context.Poems.AddAsync(entity);
    }

    public async Task Delete(Poem entity)
    {
        _context.Poems.Remove(entity);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}