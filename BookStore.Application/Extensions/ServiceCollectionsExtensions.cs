using BookStore.Application.ApplicationUser;
using BookStore.Application.Book.Queries.GetBooks;
using BookStore.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetBooksQuery));

        services.AddAutoMapper(typeof(BookMappingProfile));

        services.AddScoped<IUserContext, UserContext>();
    }
}
