using AutoMapper;
using BookStore.Application.Author;
using BookStore.Application.Author.Commands.EditAuthor;

namespace BookStore.Application.Mappings;

public class AuthorMappingProfile : Profile
{
	public AuthorMappingProfile()
	{
		CreateMap<Domain.Entities.Author, AuthorDto>()
			.ReverseMap();

		CreateMap<Domain.Entities.Author, EditAuthorCommand>()
			.ReverseMap();
	}
}
