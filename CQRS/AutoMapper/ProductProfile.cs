using AutoMapper;
using Domain;
using DTO;

namespace CQRS.AutoMapper
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Food, ProductDTO>().ReverseMap();
            CreateMap<NonFood, ProductDTO>().ReverseMap();
            CreateMap<ShoppingBasket, ShoppingBasketDTO>().ReverseMap();
            CreateMap<ShoppingBasketItem, ShoppingBasketDTO>().ReverseMap();

        }
    }
}
