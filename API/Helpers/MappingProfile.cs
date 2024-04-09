using API.Dtos;
using AutoMapper;
using Core.Models;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductType, x => x.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.ProductBrand, x => x.MapFrom(x => x.ProductBrand.Name))
                .ForMember(x => x.PictureUrl, x => x.MapFrom<ProductImageURLresolver>());
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}
