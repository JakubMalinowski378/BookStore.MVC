using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Languages.Queries.GetAllLanguages;

public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<Domain.Entities.Language>>
{
    private readonly ILanguageRepository _languageRepository;

    public GetAllLanguagesQueryHandler(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Language>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        var languages = await _languageRepository.GetAll();
        return languages;
    }
}
