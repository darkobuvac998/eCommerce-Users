using eCommerce.Users.Application.Commands;
using eCommerce.Users.Domain.Contracts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Users.Application.Validators;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public SignInCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
        RuleFor(x => x.Surname).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20);
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(20)
            .MustAsync(
                async (name, token) =>
                {
                    var user = await _unitOfWork!.Users
                        .GetByUsername(name)
                        .FirstOrDefaultAsync(token);
                    return user is null;
                }
            );
        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MustAsync(
                async (email, token) =>
                {
                    var user = await _unitOfWork!.Users
                        .GetByEmail(email)
                        .FirstOrDefaultAsync(token);
                    return user is null;
                }
            );
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
    }
}
