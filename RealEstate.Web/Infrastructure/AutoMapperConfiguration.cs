using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Web.Models;
using RealEstate.Web.Models.Administrator;

namespace RealEstate.Web.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<AccountInputModel, Account>();
            Mapper.CreateMap<SellPropertyModel, Property>().ForMember(x=>x.NombrePropiedad, y=>y.MapFrom(o=>o.PropertyName));
            Mapper.CreateMap<Property, ListPropertiesModel>().ForMember(x=>x.Precio, y=>y.MapFrom(o=>o.Price)).ForMember(x=>x.Ciudad, y=>y.MapFrom(o=>o.City)).ForMember(x=>x.Pais,y=>y.MapFrom(o=>o.Country)).ForMember(x=>x.Nombre,y=>y.MapFrom(o=>o.NombrePropiedad)).ForMember(x=>x.Colonia,y=>y.MapFrom(o=>o.Suburb));
            Mapper.CreateMap<House,ListPropertiesModel>().ForMember(x=>x.Precio, y=>y.MapFrom(o=>o.Price)).ForMember(x=>x.Ciudad, y=>y.MapFrom(o=>o.City)).ForMember(x=>x.Pais,y=>y.MapFrom(o=>o.Country)).ForMember(x=>x.Nombre,y=>y.MapFrom(o=>o.NombrePropiedad)).ForMember(x=>x.Colonia,y=>y.MapFrom(o=>o.Suburb));
            Mapper.CreateMap<Property, PropertyProfileModel>()
                .ForMember(x => x.PropertyName, y => y.MapFrom(o => o.NombrePropiedad));
            Mapper.CreateMap<Account, AccountProfileModel>();

            Mapper.CreateMap<Property, APropertiesListModel>().ForMember(x => x.City, y => y.MapFrom(o => o.City)).ForMember(x => x.Country, y => y.MapFrom(o => o.Country));
            Mapper.CreateMap<Account, AUserListModel>();
            Mapper.CreateMap<Property, BanPropertyModel>();
            Mapper.CreateMap<Account, BanUserModel>();
            Mapper.CreateMap<SellHouseModel, House>();
            

        }
    }
}