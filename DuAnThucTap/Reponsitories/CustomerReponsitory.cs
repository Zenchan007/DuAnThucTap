using AutoMapper;
using DuAnThucTap.Data;
using DuAnThucTap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuAnThucTap.Reponsitories
{
    public class CustomerReponsitory : ICustomerReponsitory
    {
        private readonly CustomerContext _context;
        private readonly IMapper _mapper;

        public CustomerReponsitory(CustomerContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;   
        }
        public async Task<int> AddCustomerAsync(CustomerModel model)
        {
            var newCustomer = _mapper.Map<Customer>(model);
            await _context.Customers!.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.ID;
        }

        public async Task DeleteCustomerByIDAsync( int id)
        {
            var deleteCustomer = await _context.FindAsync<Customer>(id);
            if(deleteCustomer != null)
            {
                _context.Customers!.Remove(deleteCustomer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditCustomerByIDAsync(int id,CustomerModel model)
        {
                var editCustomer = await _context.FindAsync<Customer>(id);
                if(editCustomer != null)
                {
                   editCustomer = _mapper.Map<Customer>(model);
                _context.Customers!.Update(editCustomer);
                await _context.SaveChangesAsync();
                }     
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            var customers = await _context.Customers!.ToListAsync();
            return customers;
        }

        public async Task<CustomerModel> GetCustomerByIDAsync(int id)
        {
            var customer = await _context.Customers!.FindAsync(id);
            return _mapper.Map<CustomerModel>(customer);
        }
    }
}
