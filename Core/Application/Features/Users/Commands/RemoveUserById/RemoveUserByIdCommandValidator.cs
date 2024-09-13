using Application.Common;
using FluentValidation;

namespace Application.Features.Users.Commands.RemoveUserById;

public class RemoveUserByIdCommandValidator : AbstractValidator<RemoveUserByIdCommand>
{
    public RemoveUserByIdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Id"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Id"))
            ;
    }
}