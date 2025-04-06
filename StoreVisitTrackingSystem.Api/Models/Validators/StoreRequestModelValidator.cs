using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;

namespace StoreVisitTrackingSystem.Api.Models.Validators;

public class StoreRequestModelValidator : AbstractValidator<StoreRequestModel>
{
    public StoreRequestModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Store name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(200);
    }
}