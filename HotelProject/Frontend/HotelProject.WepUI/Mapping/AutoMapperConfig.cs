using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WepUI.Dtos.AboutDto;
using HotelProject.WepUI.Dtos.AppUserDto;
using HotelProject.WepUI.Dtos.BookingDto;
using HotelProject.WepUI.Dtos.ContactDto;
using HotelProject.WepUI.Dtos.GuestDto;
using HotelProject.WepUI.Dtos.LoginDto;
using HotelProject.WepUI.Dtos.RegisterDto;
using HotelProject.WepUI.Dtos.ServiceDto;
using HotelProject.WepUI.Dtos.StaffDto;
using HotelProject.WepUI.Dtos.SubscribeDto;
using HotelProject.WepUI.Dtos.TestimonialDto;

namespace HotelProject.WepUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();

            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();


            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpgradeGuestDto, Guest>().ReverseMap();

            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();


        }
    }
}
