using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Domain;

namespace WebApi.Infra.Db;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public LibraryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql()
            .UseSnakeCaseNamingConvention()
            .UseSeeding((context, _) =>
            {
                var books = context.Set<Book>();

                var hasData = books.Any();
                if (!hasData)
                {
                    books.AddRange(DbSeed.GetBooks());
                    context.SaveChanges();
                }

            })
            .UseAsyncSeeding(async (context, _, cancellationToken) => 
            {
                var books = context.Set<Book>();

                var hasData = await books.AnyAsync(cancellationToken);
                if (!hasData)
                {
                    books.AddRange(DbSeed.GetBooks());
                    await context.SaveChangesAsync(cancellationToken);
                }
            });
    }
}
