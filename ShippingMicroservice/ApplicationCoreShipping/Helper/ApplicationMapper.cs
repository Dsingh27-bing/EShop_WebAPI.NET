using AutoMapper;
using ApplicationCoreShipping.Model;

namespace ApplicationCoreShipping.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Entities.Shipper, ShippingRequestModel>().ReverseMap();
        CreateMap<Entities.Shipper, ShippingResponseModel>().ReverseMap();
        CreateMap<Entities.ShipperRegion, ShippingRequestModel>().ReverseMap();
        CreateMap<Entities.ShipperRegion, ShippingResponseModel>().ReverseMap();
    }
}