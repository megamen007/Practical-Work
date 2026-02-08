using MediatR;
using Praktika.Application.Categories.DTOs;

namespace Praktika.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto?>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery() { }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}