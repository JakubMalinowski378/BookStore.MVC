using BookStore.Application.ApplicationUser;
using BookStore.Application.Author.Commands.CreateAuthor;
using BookStore.Application.Book.Queries.GetBooks;
using BookStore.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllBooksQuery));

        services.AddAutoMapper(typeof(BookMappingProfile));

        services.AddScoped<IUserContext, UserContext>();

        services.AddValidatorsFromAssemblyContaining<CreateAuthorCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
