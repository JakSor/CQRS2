using Domain;
using FluentValidation;

namespace CQRS.Validation
{
    class FoodValidator : AbstractValidator<Food>
    {
        public FoodValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25).WithMessage("Please enter a name (25 char. max)");

            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Please select if active or not");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price cannot be free or negative");
            RuleFor(x => x.QuantityInPackage).GreaterThan(1).WithMessage("amount cannot be less than 1 ");
            RuleFor(x => x.IsDrink).NotEmpty().WithMessage("Please select a drink category");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Please keep the description to max 25 char");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");
            RuleFor(x => x.ExpireDate).NotEmpty().GreaterThan(DateTime.Now);
        }
    }
}
