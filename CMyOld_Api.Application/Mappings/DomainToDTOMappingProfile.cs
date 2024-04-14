using AutoMapper;
using CMyOld_Api.Application.DTOs;
using CMyOld_Api.Domain.Entities;

namespace CMyOld_Api.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}