using Abp.Runtime.Validation;
using AutoMapper;
using Castle.Core.Resource;
using DuAnThucTap.Data;
using DuAnThucTap.DTO;
using DuAnThucTap.Models;
using DuAnThucTap.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DuAnThucTap.Reponsitories
{
    public class CustomerReponsitory : ICustomerReponsitory
    {
        private readonly CustomerContext _context;
        private readonly IMapper _mapper;
        private readonly CustomerValidator _validationrules;

        public CustomerReponsitory(CustomerContext context, IMapper mapper, CustomerValidator validationrules) {
            _context = context;
            _mapper = mapper;
            _validationrules = validationrules;
        }
        public async Task<int> AddCustomerAsync(CustomerModel model)
        {
            await ValidateModel(model);
            var newCustomer = _mapper.Map<Customer>(model);
            await _context.Customers!.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.ID;
         
        }

        public async Task<bool> CustomerExistsAsync(int id)
        {
            return await _context.Customers!.AnyAsync(e => e.ID == id);
        }

        public async Task DeleteCustomerByIDAsync( int id)
        {
            var deleteCustomer = await _context.FindAsync<Customer>(id);
            if(deleteCustomer != null) 
            {
                _context.Customers!.Remove(deleteCustomer); 
                await _context.SaveChangesAsync();
            }
            else {
                throw new AbpValidationException($"Không tìm thấy khách hàng có ID:{id}");
            }
        }
        public async Task ValidateModel(CustomerModel model)
        {
            var result = await _validationrules.ValidateAsync(model);
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage);
                throw new AbpValidationException(string.Join(Environment.NewLine, errorMessages));
            }
        }
        public async Task EditCustomerByIDAsync(int id,  CustomerModel model)
        {
            await ValidateModel(model);
            var editCustomer = await _context.FindAsync<Customer>(id);
            if(editCustomer != null)
            {
                _mapper.Map(model, editCustomer); // 
                _context.Customers!.Update(editCustomer);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new AbpValidationException($"Không tìm thấy khách hàng có ID:{id}");
            }
        }

        public async Task<List<Customer_DTO>> GetAllCustomerAsync()
        {
            var customers = await _context.Customers!.ToListAsync();

            if (customers != null)
            {
                // Cách làm 1: 
                //var customer_dto = new List<Customer_DTO>();
                //customer_dto = customers.Select(cus => new Customer_DTO
                //{
                //    ID = cus.ID,
                //    Age_Customer = cus.Age_Customer,
                //    Address_Customer = cus.Address_Customer,
                //    Description_Customer = cus.Description_Customer
                //}).ToList();
                //return customer_dto;
                var customer_dto = _mapper.Map<List<Customer_DTO>>(customers); // Dùng automapper được :D 
                return customer_dto.ToList();
            }
            else
            {
                throw new AbpValidationException($"Danh sách rỗng!");
            }

        }

        public async Task<CustomerModel> GetCustomerByIDAsync(int id)
        {
            var customer = await _context.Customers!.FindAsync(id);
            return customer != null ? _mapper.Map<CustomerModel>(customer) : throw new AbpValidationException($"Không tìm thấy khách hàng có ID: {id}");
        }
    }
}
