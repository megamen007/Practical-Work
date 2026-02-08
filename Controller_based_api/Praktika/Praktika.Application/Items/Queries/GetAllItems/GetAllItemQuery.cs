using MediatR;
using Praktika.Application.Items.DTOs;

namespace Praktika.Application.Items.Queries.GetAllItems
{
	public class GetAllItemsQuery : IRequest<List<ItemDto>>
	{
		public int? CategoryId { get; set; }

		public GetAllItemsQuery() { }

		public GetAllItemsQuery(int? categoryId)
		{
			CategoryId = categoryId;
		}
	}
}