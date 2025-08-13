using AutoMapper;
using HotelApiProject.DtoLayer.Dtos.AboutDtos;
using HotelApiProject.DtoLayer.Dtos.Contactos;
using HotelApiProject.DtoLayer.Dtos.RoomDtos;
using HotelApiProject.DtoLayer.Dtos.ServiceDtos;
using HotelApiProject.DtoLayer.Dtos.SocialMediaDtos;
using HotelApiProject.DtoLayer.Dtos.StaffDtos;
using HotelApiProject.DtoLayer.Dtos.SubscribeDtos;
using HotelApiProject.DtoLayer.Dtos.TestimonialDtos;
using HotelApiProject.EntityLayer.Concrete;

namespace HotelApiProject.WebApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Room,RoomAddDto>().ReverseMap();
            CreateMap<Room,RoomUpdateDto>().ReverseMap();
            CreateMap<Room,RoomListDto>().ReverseMap();

            CreateMap<About, AboutAddDto>().ReverseMap();
            CreateMap<About, AboutUpdateDto>().ReverseMap();

            CreateMap<Service, ServiceAddDto>().ReverseMap();
            CreateMap<Service, ServiceListDto>().ReverseMap();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();

            CreateMap<Staff, StaffAddDto>().ReverseMap();
            CreateMap<Staff, StaffListDto>().ReverseMap();
            CreateMap<Staff, StaffUpdateDto>().ReverseMap();

            CreateMap<Subscribe, SubscribeAddDto>().ReverseMap();
            CreateMap<Subscribe, SubscribeListDto>().ReverseMap();
            CreateMap<Subscribe, SubscribeUpdateDto>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaAddDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaListDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();

            CreateMap<Testimonial, TestimonialAddDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialListDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialUpdateDto>().ReverseMap();

            CreateMap<Contact, ContactListDto>().ReverseMap();
        }
    }
}
