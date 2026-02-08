using MediatR;
using Praktika.Application.Categories.DTOs;

namespace Praktika.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {
        public bool IncludeItems { get; set; }

        public GetAllCategoriesQuery() { }

        public GetAllCategoriesQuery(bool includeItems)
        {
            IncludeItems = includeItems;
        }
    }
}