using MediatR;

namespace Praktika.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public int Id {get ; set;}

        public DeleteItemCommand(int id)
        {
            Id = id;
        }
    }
}