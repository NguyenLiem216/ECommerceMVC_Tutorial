using AutoMapper;
using ECommerceMVC.Data;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RegisterVM, Khachhang>();
                //.ForMember(kh => kh.Hoten, option => option.MapFrom(RegisterVM => RegisterVM.Hoten))
                //.ReverseMap();
        }
    }
}
