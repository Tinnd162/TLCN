using AutoMapper;
using Inventory.API.DTOs;
using Inventory.API.Entities;

namespace Inventory.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}