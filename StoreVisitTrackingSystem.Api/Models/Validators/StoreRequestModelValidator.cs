using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;

namespace StoreVisitTrackingSystem.Api.Models.Validators;

public class StoreRequestModelValidator : AbstractValidator<StoreRequestModel>
{
    public StoreRequestModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Store name is required.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithMessage("Exceeds maximum length.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Location is required.");

        RuleFor(x => x.Location)
            .MaximumLength(200)
            .WithMessage("Exceeds maximum length.");
    }
}