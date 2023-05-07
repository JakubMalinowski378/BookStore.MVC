﻿using AutoMapper;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthors;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Domain.Entities.Authors>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Authors>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authorRepository.GetAll();

        return authors;
    }
}
