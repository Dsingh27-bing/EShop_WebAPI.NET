using AuthenticationApplicationCore.Model;
using AutoMapper;

namespace AuthenticationApplicationCore.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Entities.User, UserRequestModel>().ReverseMap();
        CreateMap<Entities.User, UserResponseModel>().ReverseMap();
    }
}