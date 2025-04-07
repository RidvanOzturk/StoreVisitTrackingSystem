using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;

namespace StoreVisitTrackingSystem.Api.Models.Validators;
public class PhotoRequestModelValidator : AbstractValidator<PhotoRequestModel>
{
    public PhotoRequestModelValidator()
    {
        const string Base64ImageRegex = @"^data:image\/[a-zA-Z]+;base64,";

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.");

        RuleFor(x => x.Base64Image)
            .NotEmpty()
            .WithMessage("Base64 image is required.");

        RuleFor(x => x.Base64Image)
            .Matches(Base64ImageRegex)
            .WithMessage("Invalid image format.");
    }
}