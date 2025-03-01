using AutoMapper;
using ProductApplicationCore.Model;

namespace ProductApplicationCore.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Entities.Product, ProductRequestModel>().ReverseMap();
        CreateMap<Entities.Product, ProductResponseModel>().ReverseMap();
        CreateMap<Entities.CategoryVariation, CategoryVariationRequestModel>().ReverseMap();
        CreateMap<Entities.CategoryVariation, CategoryVariationResponseModel>().ReverseMap();
        CreateMap<Entities.ProductCategory, ProductCategoryRequestModel>().ReverseMap();
        CreateMap<Entities.ProductCategory, ProductCategoryResponseModel>().ReverseMap();
        CreateMap<Entities.VariationValue, VariationRequestModel>().ReverseMap();
        CreateMap<Entities.VariationValue, VariationResponseModel>().ReverseMap();
        CreateMap<Entities.ProductVariationValues, ProductVariationRequestModel>().ReverseMap();
        CreateMap<Entities.ProductVariationValues, ProductVariationResponseModel>().ReverseMap();
    }
}