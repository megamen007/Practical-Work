using AutoMapper;
using MediatR;
using Praktika.Application.Items.DTOs;
using Praktika.Application.Items.UpdateItem;
using Praktika.Praktika.Domain.Entities;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Items.Commands.UpdateCategory
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ItemDto>
    {
        private readonly PraktikaDbContext _context;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(PraktikaDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(new object[] {request.Id}, cancellationToken);
            if (item == null)
                return null;
            
            item.Name = request.Name;
            item.Price = request.Price;
            item.Notes = request.Notes;
            item.Image = request.Image;

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ItemDto>(item);
        }
    }
}