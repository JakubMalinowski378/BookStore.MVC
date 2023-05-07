using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Application.Book.Queries.GetBooks;
using BookStore.Application.Book.Commands.CreateBook;
using BookStore.Application.Author.Queries.GetAuthors;
using BookStore.Application.Genre.Queries.GetAllGenres;
using BookStore.Application.Languages.Queries.GetAllLanguages;

namespace BookStore.MVC.Controllers;

public class BookController : Controller
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _mediator.Send(new GetAllBooksQuery());
        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var authorsCredentials = await _mediator.Send(new GetAllAuthorsQuery());
        var genres = await _mediator.Send(new GetAllGenresQuery());
        var languages = await _mediator.Send(new GetAllLanguagesQuery());
        ViewData["Authors"] = new SelectList(
            authorsCredentials.Select(a =>
            new { a.Id, FirstAndLastName=$"{a.FirstName} {a.LastName}" }
            ), "Id", "FirstAndLastName");
        ViewData["Genres"] = new SelectList(genres, "Id", "Genre");
        ViewData["Languages"] = new SelectList(languages, "Id", "Language");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        if (!ModelState.IsValid)
        {
            var authorsCredentials = await _mediator.Send(new GetAllAuthorsQuery());
            ViewData["Authors"] = new SelectList(authorsCredentials, "Id", "LastName");
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}
