using AutoMapper;
using BookStore.Application.Book;

namespace BookStore.Application.Mappings;

public class BookMappingProfile : Profile
{
	public BookMappingProfile()
	{
		CreateMap<Domain.Entities.Books, BookDto>()
			.ReverseMap();

		CreateMap<CreateBookDto, Domain.Entities.Books>();
	}
}
