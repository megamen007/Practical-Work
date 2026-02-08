using AutoMapper;
using Praktika.Application.Categories.DTOs;
using Praktika.Praktika.Domain.Entities;

namespace Praktika.Application.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ItemCount, opt => opt.MapFrom(src => src.Items.Count));
        }
    }
}
