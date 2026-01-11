using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private IDataRepository<Customer> _repository;


        public CustomersController (IDataRepository<Customer> repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Customer> customers = _repository.GetAll();
            return Ok(customers);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer customer = _repository.Get(id);

            if (customer == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(customer);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is Null");
            }
            _repository.Add(customer);
            return CreatedAtRoute("Get", new { Id = customer.ID }, customer);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null");
            }
            Customer customerToUpdate = _repository.Get(id);
            if (customerToUpdate == null)
            {
                return NotFound("Customer could not be found");
            }
            _repository.Change(customerToUpdate, customer);
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = _repository.Get(id);
            if (customer == null)
            {
                return BadRequest("Customer is not found");
            }
            _repository.Delete(customer);
            return NoContent();
        }
    }
}
