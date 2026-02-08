using MediatR;
using Praktika.Application.Items.DTOs;

namespace Praktika.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<ItemDto?>
    {
        public int Id { get; set; }

        public GetItemByIdQuery() { }

        public GetItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}