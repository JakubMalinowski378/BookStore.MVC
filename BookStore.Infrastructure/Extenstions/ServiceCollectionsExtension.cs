using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Persistance;
using BookStore.Infrastructure.Repositories;
using BookStore.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure.Extenstions;

public static class ServiceCollectionsExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("BookStore")));

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<BookStoreDbContext>();

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
    }
}
