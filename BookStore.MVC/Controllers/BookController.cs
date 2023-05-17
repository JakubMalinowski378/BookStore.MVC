using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Application.Book.Queries.GetBooks;
using BookStore.Application.Book.Commands.CreateBook;
using BookStore.Application.Author.Queries.GetAuthors;
using BookStore.Application.Genre.Queries.GetAllGenres;
using BookStore.Application.Languages.Queries.GetAllLanguages;
using BookStore.Application.Book;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize]
    public async Task<IActionResult> Create()
    {
        var authorsCredentials = await _mediator.Send(new GetAllAuthorsQuery());
        var genres = await _mediator.Send(new GetAllGenresQuery());
        var languages = await _mediator.Send(new GetAllLanguagesQuery());
        ViewData["Authors"] = new SelectList(
            authorsCredentials.Select(a =>
            new { a.Id, FirstAndLastName=$"{a.FirstName} {a.LastName}" }
            ), "Id", "FirstAndLastName");
        ViewData["Languages"] = new SelectList(languages, "Id", "Language");
        var model = new CreateBookDto()
        {
            Genres = genres.ToList()
        };
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        if (!ModelState.IsValid || command.GenresIds == null)
        {
            var authorsCredentials = await _mediator.Send(new GetAllAuthorsQuery());
            var genres = await _mediator.Send(new GetAllGenresQuery());
            var languages = await _mediator.Send(new GetAllLanguagesQuery());
            ViewData["Authors"] = new SelectList(
            authorsCredentials.Select(a =>
            new { a.Id, FirstAndLastName = $"{a.FirstName} {a.LastName}" }
            ), "Id", "FirstAndLastName");
            ViewData["Genres"] = genres.Select(g => new { g.Id, g.Genre });
            ViewData["Languages"] = new SelectList(languages, "Id", "Language");
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}
