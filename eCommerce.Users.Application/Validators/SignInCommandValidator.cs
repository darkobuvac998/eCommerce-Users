using eCommerce.Users.Application.Commands;
using FluentValidation;

namespace eCommerce.Users.Application.Validators;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
        RuleFor(x => x.Surname).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20);
        RuleFor(x => x.Username).NotEmpty().NotNull().MinimumLength(6).MaximumLength(20);
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
    }
}
