using AutoMapper;
using PromotionApplicationCore.Model;

namespace PromotionApplicationCore.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Entities.PromotionSale, PromotionResponseModel>().ReverseMap();
        CreateMap<Entities.PromotionSale, PromotionRequestModel>().ReverseMap();
        CreateMap<Entities.PromotionDetails, PromotionDetailsResponseModel>().ReverseMap();
        CreateMap<Entities.PromotionDetails, PromotionDetailsRequestModel>().ReverseMap();
    }
}