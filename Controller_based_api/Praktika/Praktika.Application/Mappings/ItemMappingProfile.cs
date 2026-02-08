using AutoMapper;
using Praktika.Application.Items.DTOs;
using Praktika.Praktika.Domain.Entities;

namespace Praktika.Application.Mappings
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.category != null ? src.category.Name : null))
                .ForMember(dest => dest.ImageBase64, opt => opt.MapFrom(src => src.Image != null ? Convert.ToBase64String(src.Image) : null));
        }
    }
}
