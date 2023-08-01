using DuAnThucTap.Data;

using DuAnThucTap.Models;
using DuAnThucTap.Reponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuAnThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerReponsitory _icusrepo;

        public  CustomerController(ICustomerReponsitory repo)
        {
            _icusrepo = repo;           
        }

        [HttpGet]
        public async Task<IActionResult> GetListCustomer() {
            try
            {
                return Ok(await _icusrepo.GetAllCustomerAsync());
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]

        public async Task<IActionResult>GetCustomerByID(int id) {
            try
            {
                var customer = await _icusrepo.GetCustomerByIDAsync(id);
                return customer == null ? NotFound("Khong tim thay khach hang nay!") : Ok(customer);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer( [FromBody] CustomerModel model)
        {
            try
            {   
                var newCustomer = await _icusrepo.AddCustomerAsync(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerByID(int id, CustomerModel model)
        {
            try
            {
                await _icusrepo.EditCustomerByIDAsync(id, model);
                var respone = _icusrepo.GetCustomerByIDAsync(id);
                return Ok(respone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerByID(int id)
        {
            try
            {
                await _icusrepo.DeleteCustomerByIDAsync(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
