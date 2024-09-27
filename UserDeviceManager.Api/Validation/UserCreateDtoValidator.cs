using FluentValidation;

namespace UserDeviceManager.Api.Validation;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor(user => user.Email)
               .NotEmpty().WithMessage("Email is required")
               .EmailAddress().WithMessage("Invalid email format")
               .MinimumLength(10).WithMessage("Minimum Length 10 !!!!!!!");
    }
}
