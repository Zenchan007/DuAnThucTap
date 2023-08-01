using DuAnThucTap.Data;
using DuAnThucTap.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuAnThucTap.Reponsitories
{
    public interface ICustomerReponsitory
    {
        public  Task<List<Customer>> GetAllCustomerAsync();
        public  Task<CustomerModel> GetCustomerByIDAsync(int id);
        public Task EditCustomerByIDAsync(int id, CustomerModel model);
        public Task<int> AddCustomerAsync(CustomerModel model);
        public Task DeleteCustomerByIDAsync(int id);
    }
}
