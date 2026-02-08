using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Praktika.Application.Categories.DTOs;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(PraktikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (category == null)
                return null;

            return _mapper.Map<CategoryDto>(category);
        }
    }
}