using AutoMapper;
using Microsoft.Extensions.Hosting.Internal;
using ReviewsApplicationCore.Model;

namespace ReviewsApplicationCore.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        
        CreateMap<Entity.Reviews, ReviewsResponseModel>().ReverseMap();
        CreateMap<Entity.Reviews, ReviewsRequestModel>().ReverseMap();
    }
}