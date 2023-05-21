using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Persistance;

public class BookStoreDbContext : IdentityDbContext
{
	public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
	{

	}

	public DbSet<Domain.Entities.Author> Authors { get; set; }
	public DbSet<Domain.Entities.Book> Books { get; set; }
    public DbSet<Domain.Entities.Genre> Genres { get; set; }
    public DbSet<Domain.Entities.Language> Languages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

		builder.Entity<Domain.Entities.Book>(eb =>
		{
			eb.HasOne(b => b.Author);

			eb.HasMany(b => b.Genres)
            .WithMany(b => b.Books);

			eb.HasOne(b => b.Language);

			eb.Property(b => b.Price)
            .HasPrecision(18, 2);
        });
    }
}
