using AutoMapper;
using DuAnThucTap.Data;
using DuAnThucTap.Models;

namespace DuAnThucTap.Helpers
{
    public class ApplicationMapper : Profile
    {
       public ApplicationMapper() { 
            CreateMap<Customer, CustomerModel>().ReverseMap();
        }
    }
}
