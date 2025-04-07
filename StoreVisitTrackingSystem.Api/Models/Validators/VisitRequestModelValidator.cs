using FluentValidation;
using StoreVisitTrackingSystem.Api.Models.Requests;

namespace StoreVisitTrackingSystem.Api.Models.Validators;

public class VisitRequestModelValidator : AbstractValidator<VisitRequestModel>
{
    public VisitRequestModelValidator()
    {
        RuleFor(x => x.StoreId)
            .GreaterThan(0)
            .WithMessage("StoreId must be greater than 0.");

        RuleFor(x => x.VisitDate)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Visit date cannot be in the future.");
    }
}
