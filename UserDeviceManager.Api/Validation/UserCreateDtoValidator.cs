using FluentValidation;

namespace UserDeviceManager.Api.Validation;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor(user => user.Email)
               .NotEmpty()
               .WithMessage("Email is required")
               .MaximumLength(128)
               .WithMessage("Email must not exceed 128 characters")
               .EmailAddress()
               .WithMessage("Invalid email format");

        RuleFor(user => user.LastName)
            .NotEmpty()
            .WithMessage("LastName is required")
            .MaximumLength(128)
            .WithMessage("LastName must not exceed 128 characters");

        RuleFor(user => user.FirstName)
             .NotEmpty()
             .WithMessage("FirstName is required")
             .MaximumLength(128)
             .WithMessage("FirstName must not exceed 128 characters");
    }
}
