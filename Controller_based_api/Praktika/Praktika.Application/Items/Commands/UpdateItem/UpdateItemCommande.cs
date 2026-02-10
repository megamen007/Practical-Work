using MediatR;
using Praktika.Application.Items.DTOs;

namespace Praktika.Application.Items.UpdateItem
{
    public class UpdateItemCommand : IRequest<ItemDto>
    {
        public int Id {get ; set;}

        public string Name {get ; set;} = string.Empty;

        public double Price {get ; set;}

        public string? Notes {get; set;} = string.Empty;

        public byte[]? Image {get ; set;}
    }
}