using AutoMapper;
using BookStore.Application.Author;

namespace BookStore.Application.Mappings;

public class AuthorMappingProfile : Profile
{
	public AuthorMappingProfile()
	{
		CreateMap<Domain.Entities.Author, AuthorDto>()
			.ReverseMap();
	}
}
