using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Praktika.Application.Categories.DTOs;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(PraktikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .Include(c => c.Items)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}