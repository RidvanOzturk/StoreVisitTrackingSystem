using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;

namespace StoreVisitTrackingSystem.Api.Models.Validators;
public class PhotoRequestModelValidator : AbstractValidator<PhotoRequestModel>
{
    public PhotoRequestModelValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.");

        RuleFor(x => x.Base64Image)
            .NotEmpty()
            .WithMessage("Base64 image is required.");
    }
}