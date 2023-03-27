using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Application.Author.Queries;
using BookStore.Application.Book.Queries.GetBooks;
using BookStore.Application.Book.Commands.CreateBook;

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
        var books = await _mediator.Send(new GetBooksQuery());
        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var authorsCredentials = await _mediator.Send(new GetAuthorsQuery());
        ViewData["Authors"] = new SelectList(authorsCredentials, "Id", "LastName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        if (!ModelState.IsValid)
        {
            var authorsCredentials = await _mediator.Send(new GetAuthorsQuery());
            ViewData["Authors"] = new SelectList(authorsCredentials, "Id", "LastName");
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}
