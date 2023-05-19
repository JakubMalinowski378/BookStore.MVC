using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BookStore.Application.Author.Commands.CreateAuthor;
using BookStore.Application.Author.Commands.EditAuthor;
using BookStore.Application.Author.Queries.GetAuthorById;
using BookStore.Application.Author.Queries.GetAuthors;
using Microsoft.AspNetCore.Authorization;
using BookStore.Application.Author.Commands.DeleteAuthor;
using BookStore.Application.Author.Queries.GetAuthorBooks;
using BookStore.Application.Exceptions;

namespace BookStore.MVC.Controllers;

[Authorize]
public class AuthorController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthorController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var authors = await _mediator.Send(new GetAllAuthorsQuery());
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

    [HttpGet]
    [Route("Author/{id}/Details")]
    public async Task<IActionResult> Details(int id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery() { Id = id });
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }

    [HttpGet]
    [Route("Author/{id}/Edit")]
    public async Task<IActionResult> Edit(int id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery() { Id = id });
        if(author == null)
        {
            return NotFound();
        }
        var dto = _mapper.Map<EditAuthorCommand>(author);
        return View(dto);
    }

    [HttpPost]
    [Route("Author/{id}/Edit")]
    public async Task<IActionResult> Edit(int id, EditAuthorCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        command.Id = id;

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route("Author/{id}/Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery() { Id = id });
        return View(author);
    }

    [HttpPost]
    [ActionName("Delete")]
    [Route("Author/{id}/Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _mediator.Send(new DeleteAuthorCommand() { Id = id });
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route("Author/{id}/Book")]
    public async Task<IActionResult> AuthorBooks(int id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery() { Id = id});
        if(author == null)
        {
            throw new NotFoundException("Author not found");
        }
        ViewData["author"] = $"{author.FirstName} {author.LastName}";
        var books = await _mediator.Send(new GetAuthorBooksQuery() {  Id = id });
        return View(books);
    }
}
