using DuAnThucTap.Data;
using DuAnThucTap.DTO;
using DuAnThucTap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuAnThucTap.Reponsitories
{
    public interface ICustomerReponsitory
    {
        public  Task<List<Customer_DTO>> GetAllCustomerAsync();
        public  Task<CustomerModel> GetCustomerByIDAsync(int id);
        public Task<int> AddCustomerAsync(CustomerModel model);
        public Task DeleteCustomerByIDAsync(int id);
        public Task EditCustomerByIDAsync(int id, CustomerModel model);
        public Task<bool> CustomerExistsAsync(int id);
    }
}
