﻿using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface ILanguageRepository
{
    Task<IEnumerable<Language>> GetAll();
}
