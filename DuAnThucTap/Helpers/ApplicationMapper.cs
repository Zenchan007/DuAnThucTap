using AutoMapper;
using DuAnThucTap.Data;
using DuAnThucTap.DTO;
using DuAnThucTap.Models;

namespace DuAnThucTap.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>().ForMember(cus => cus.ID, otp => otp.Ignore()); 
            CreateMap<Customer, Customer_DTO>().ReverseMap();
        }
    }
}
