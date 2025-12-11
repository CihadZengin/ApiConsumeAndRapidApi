using AutoMapper;
using HotelProject.DtoLayer.Dtos.RomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WepApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRomDto, Room>().ReverseMap();
        }
    }
}
