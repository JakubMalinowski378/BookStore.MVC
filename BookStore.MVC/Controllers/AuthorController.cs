using BookStore.Application.Author.Commands;
using BookStore.Application.Author.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.MVC.Controllers;

public class AuthorController : Controller
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var authors = await _mediator.Send(new GetAuthorsQuery());
        return View(authors);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}
