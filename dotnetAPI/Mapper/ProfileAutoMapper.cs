using AutoMapper;
using dotnetAPI.models;
using dotnetAPI.Models.DTOs;

namespace dotnetAPI.Mapper
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper() {
            CreateMap<Product, ProductDTO>();
        }
        
    }
}
