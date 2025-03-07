using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using AutoMapper;

namespace ApplicationCore.Helper;

public class ApplicationMapper:Profile
{
    
        public ApplicationMapper()
        {
            CreateMap<Entities.Order, OrderRequestModel>().ReverseMap();
            CreateMap<Entities.Order, OrderResponseModel>().ReverseMap();
            CreateMap<Entities.OrderDetails, OrderDetailsRequestModel>().ReverseMap();
            CreateMap<Entities.OrderDetails, OrderDetailsResponseModel>().ReverseMap();
            CreateMap<Entities.Customer, CustomerRequestModel>().ReverseMap();
            CreateMap<Entities.Customer, CustomerResponseModel>().ReverseMap();
            CreateMap<Entities.Address, AddressRequestModel>().ReverseMap();
            CreateMap<Entities.Address, AddressResponseModel>().ReverseMap();
            CreateMap<Entities.PaymentMethod, PaymentMethodRequestModel>().ReverseMap();
            CreateMap<Entities.PaymentMethod, PaymentMethodResponseModel>().ReverseMap();
            CreateMap<Entities.PaymentType, PaymentTypeRequestModel>().ReverseMap();
            CreateMap<Entities.PaymentType, PaymentTypeResponseModel>().ReverseMap();
            CreateMap<Entities.ShoppingCart, ShoppingCartRequestModel>().ReverseMap();  
            CreateMap<Entities.ShoppingCart, ShoppingCartResponseModel>().ReverseMap();
            CreateMap<Entities.ShoppingCartItem, ShoppingCartItemRequestModel>().ReverseMap();
            CreateMap<Entities.ShoppingCartItem, ShoppingCartItemResponseModel>().ReverseMap();
            CreateMap<Entities.UserAddress, UserAddressRequestModel>().ReverseMap();
            CreateMap<Entities.UserAddress, UserAddressResponseModel>().ReverseMap();



        }
    
}