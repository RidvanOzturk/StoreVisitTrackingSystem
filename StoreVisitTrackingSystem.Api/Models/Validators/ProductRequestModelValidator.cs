using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;

namespace StoreVisitTrackingSystem.Api.Models.Validators;

public class ProductRequestModelValidator : AbstractValidator<ProductRequestModel>
{
    public ProductRequestModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(100);
    }
}
