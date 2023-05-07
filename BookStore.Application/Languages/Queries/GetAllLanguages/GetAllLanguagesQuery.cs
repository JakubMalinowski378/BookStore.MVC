using MediatR;

namespace BookStore.Application.Languages.Queries.GetAllLanguages;

public class GetAllLanguagesQuery : IRequest<IEnumerable<Domain.Entities.Languages>>
{

}
