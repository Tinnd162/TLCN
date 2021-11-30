using AutoMapper;
using Common;
using Inventory.API.DTOs;
using Inventory.API.Entities;

namespace Inventory.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddProductDTO, ProductEventBO>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceLogDTO.Price))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryDTO.Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.BrandDTO.Name))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.LinkImage));
        }
    }
}