using MediatR;
using Praktika.Praktika.Infrastructure.Persistence;

namespace Praktika.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand , bool>
    {
        private readonly PraktikaDbContext _context;

        public DeleteItemCommandHandler(PraktikaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteItemCommand request , CancellationToken cancellationToken)
        {
            var Item = await _context.Items.FindAsync(new object[] {request.Id}, cancellationToken);
            if (Item == null)
                return false;

            _context.Items.Remove(Item);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}