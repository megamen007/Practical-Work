using MediatR;

namespace Praktika.Application.Categories.Commands.DeleteCategory
{

    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}