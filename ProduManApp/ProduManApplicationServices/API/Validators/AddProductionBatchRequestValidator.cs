using FluentValidation;
using ProduManApplicationServices.API.Domain;

namespace ProduManApplicationServices.API.Validators;

public class AddProductionBatchRequestValidator : AbstractValidator<AddProductionBatchRequest>
{
    public AddProductionBatchRequestValidator()
    {
        this.RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1).WithMessage("Quantity must be greater than 1"); 
        this.RuleFor(x => x.CustomerOrderNumber).Length(6, 20).WithMessage("CustomerOrderNumber must be between 6 and 20 characters long");
    }
}