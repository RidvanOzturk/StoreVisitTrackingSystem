using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;
namespace StoreVisitTrackingSystem.Api.Models.Validators;

public class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
{
    public LoginRequestModelValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.");
    }
}
