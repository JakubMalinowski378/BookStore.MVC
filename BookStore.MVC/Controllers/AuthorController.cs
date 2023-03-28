using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BookStore.Application.Author.Commands.CreateAuthor;
using BookStore.Application.Author.Commands.EditAuthor;
using BookStore.Application.Author.Queries.GetAuthorById;
using BookStore.Application.Author.Queries.GetAuthors;

namespace BookStore.MVC.Controllers;

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

    [Route("Author/{id}/Edit")]
    public async Task<IActionResult> Edit(int id)
    {
        
        var author = await _mediator.Send(new GetAuthorByIdCommand() { Id = id });
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
}
