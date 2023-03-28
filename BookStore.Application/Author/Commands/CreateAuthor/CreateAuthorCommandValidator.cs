using FluentValidation;

namespace BookStore.Application.Author.Commands.CreateAuthor;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("First name should be longer than 3");

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Last name should be longer than 3");
    }
}
