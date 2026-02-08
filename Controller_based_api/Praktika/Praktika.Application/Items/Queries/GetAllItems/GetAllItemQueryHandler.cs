using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Praktika.Application.Items.DTOs;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Items.Queries.GetAllItems
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<ItemDto>>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public GetAllItemsQueryHandler(PraktikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Items.Include(i => i.category).AsQueryable();

            if (request.CategoryId.HasValue)
                query = query.Where(i => i.CategoryId == request.CategoryId.Value);

            var items = await query.ToListAsync(cancellationToken);

            return _mapper.Map<List<ItemDto>>(items);
        }
    }
}