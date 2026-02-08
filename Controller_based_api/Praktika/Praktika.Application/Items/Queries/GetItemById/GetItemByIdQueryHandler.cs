using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Praktika.Application.Items.DTOs;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemDto?>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(PraktikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemDto?> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _context.Items
                .Include(i => i.category)
                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

            if (item == null)
                return null;

            return _mapper.Map<ItemDto>(item);
        }
    }
}