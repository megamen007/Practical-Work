using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Praktika.Application.Items.DTOs;
using Praktika.Praktika.Domain.Entities;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ItemDto>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(PraktikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            byte[]? imageData = null;
            if (request.Image != null && request.Image.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await request.Image.CopyToAsync(memoryStream, cancellationToken);
                imageData = memoryStream.ToArray();
            }

            var item = new Item
            {
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Notes = request.Notes,
                Image = imageData
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            var itemWithCategory = await _context.Items
                .Include(i => i.category)
                .FirstOrDefaultAsync(i => i.Id == item.Id, cancellationToken);

            return _mapper.Map<ItemDto>(itemWithCategory);
        }
    }
}