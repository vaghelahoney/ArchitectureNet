using FluentValidation;
using SuiteRx.Interface.Application.Dto;

namespace SuiteRx.Interface.Application.Validators
{
    public class ClothesDtoValidator : AbstractValidator<ClothesDto>
    {
        public ClothesDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Image is required.");
        }
    }
}
