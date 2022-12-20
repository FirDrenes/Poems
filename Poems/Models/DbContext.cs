using Microsoft.EntityFrameworkCore;

namespace Poems.Models;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{ 
    public DbSet<Author> Authors { get; set; }
    public DbSet<Poem> Poems { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbContext(DbContextOptions options) : base(options) 
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=poems;Trusted_Connection=True;");
    }
}