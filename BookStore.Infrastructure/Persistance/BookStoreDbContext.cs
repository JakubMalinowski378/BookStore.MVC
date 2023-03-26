using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Persistance;

public class BookStoreDbContext : IdentityDbContext
{
	public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
	{

	}

	public DbSet<Domain.Entities.Book> Books { get; set; }
	public DbSet<Domain.Entities.Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

		builder.Entity<Domain.Entities.Book>()
			.HasOne(x => x.Author);

    }
}
