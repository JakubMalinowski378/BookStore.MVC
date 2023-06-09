﻿using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAll();
}
