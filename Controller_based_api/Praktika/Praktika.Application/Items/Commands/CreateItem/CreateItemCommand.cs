using MediatR;
using Microsoft.AspNetCore.Http;
using Praktika.Application.Items.DTOs;

namespace Praktika.Application.Items.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<ItemDto>
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? Notes { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}