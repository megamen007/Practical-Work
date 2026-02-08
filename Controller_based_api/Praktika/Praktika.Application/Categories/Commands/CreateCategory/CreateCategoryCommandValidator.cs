using FluentValidation;

namespace Praktika.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required");

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage("Category name cannot exceed 50 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description cannot exceed 500 characters");

 
            RuleFor(x => x.Name)
                .Must(BeValidName)
                .WithMessage("Category name contains invalid characters")
                .When(x => !string.IsNullOrEmpty(x.Name));
        }


        private bool BeValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                   name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-');
        }
    }
}