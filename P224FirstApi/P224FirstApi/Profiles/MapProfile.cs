using AutoMapper;
using P224FirstApi.DAL.Entities;
using P224FirstApi.DTOs.CategoryDtos;
using P224FirstApi.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Produc
            CreateMap<Product, ProductGetDto>()
                .ForMember(dest => dest.MehsulunAdi, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.MehsulunQiymeti, src => src.MapFrom(src => src.Price))
                .ForMember(dest => dest.MehsulunEndirimQiymeti, src => src.MapFrom(src => src.DiscountPrice))
                .ForMember(dest => dest.DiscountPercent, src => src.MapFrom(src => (100 - ((src.Price - src.DiscountPrice) * 100) / src.Price)));

            CreateMap<Product, ProductListDto>()
                .ForMember(dest => dest.MehsulunAdi, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.MehsulunQiymeti, src => src.MapFrom(src => src.Price));
            #endregion

            #region Category
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryGetDto>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryPutDto, Category>();
            #endregion
        }
    }
}
