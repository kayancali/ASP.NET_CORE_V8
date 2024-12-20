using AutoMapper;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

namespace StoreApp.Models;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductViewModel>();
    }
}