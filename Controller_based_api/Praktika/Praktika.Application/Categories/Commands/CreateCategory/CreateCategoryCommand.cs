using MediatR;
using Praktika.Application.Categories.DTOs;

namespace Praktika.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
