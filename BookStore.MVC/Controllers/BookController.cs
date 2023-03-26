using BookStore.Application.Book.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
}
