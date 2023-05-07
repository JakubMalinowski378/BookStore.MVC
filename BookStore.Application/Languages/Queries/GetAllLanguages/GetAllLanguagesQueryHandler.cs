using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Languages.Queries.GetAllLanguages;

public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<Domain.Entities.Languages>>
{
    private readonly ILanguageRepository _languageRepository;

    public GetAllLanguagesQueryHandler(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Languages>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        var languages = await _languageRepository.GetAll();
        return languages;
    }
}
