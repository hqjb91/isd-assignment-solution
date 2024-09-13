using Application.Common;
using FluentValidation;

namespace Application.Features.Users.Commands.CreateUser;

// Fluent Validation Validating CreateUserCommand
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Name"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Name"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "20"))
            .Matches(ApplicationConstants.AlphabeticalRegex).WithMessage(string.Format(ApplicationConstants.InvalidFormatError, "Alphabetic"))
            ;

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "User Name"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "User Name"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "20"))
            ;

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Email"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Email"))
            .EmailAddress().WithMessage(string.Format(ApplicationConstants.InvalidFormatError, "Email"))
            ;

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Phone"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Phone"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "10"))
            ;

        RuleFor(x => x.Website)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Website"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Website"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "20"))
            ;

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Address"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Address"))
            ;

        RuleFor(x => x.Address.Geo)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Geo"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Geo"))
            ;

        RuleFor(x => x.Address.Zipcode)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Zipcode"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Zipcode"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "10"))
            ;

        RuleFor(x => x.Address.City)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "City"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "City"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "20"))
            .Matches(ApplicationConstants.AlphabeticalRegex).WithMessage(string.Format(ApplicationConstants.InvalidFormatError, "Alphabetic"))
            ;

        RuleFor(x => x.Address.Street)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Street"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Street"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "20"))
            ;

        RuleFor(x => x.Address.Suite)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Suite"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Suite"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "20"))
            ;

        RuleFor(x => x.Company)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Company"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Company"))
            ;

        RuleFor(x => x.Company.Name)
            .NotEmpty().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Company Name"))
            .NotNull().WithMessage(string.Format(ApplicationConstants.FieldRequiredError, "Company Name"))
            .MaximumLength(20).WithMessage(string.Format(ApplicationConstants.MaximumLengthError, "20"))
            .Matches(ApplicationConstants.AlphabeticalRegex).WithMessage(string.Format(ApplicationConstants.InvalidFormatError, "Alphabetic"))
            ;

    }
}