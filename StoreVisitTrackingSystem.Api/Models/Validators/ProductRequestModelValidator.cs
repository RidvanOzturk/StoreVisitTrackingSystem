using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;

namespace StoreVisitTrackingSystem.Api.Models.Validators;

public class ProductRequestModelValidator : AbstractValidator<ProductRequestModel>
{
    public ProductRequestModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithErrorCode("Exceeds maximum length.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required.");

        RuleFor(x => x.Category)
            .MaximumLength(100)
            .WithMessage("Exceeds maximum length.");
    }
}
