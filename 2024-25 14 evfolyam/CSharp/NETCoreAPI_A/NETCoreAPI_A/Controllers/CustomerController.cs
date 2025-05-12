using DB;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NETCoreAPI_A.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		// GET: api/<CustomerController>
		[HttpGet]
		public List<Customer> Get()
		{
			return DAL.Get_Cusomer();
		}

		// GET api/<CustomerController>/5
		[HttpGet("{id}")]
		public Customer Get(string id)
		{
			return DAL.Get_Customer(id);
		}

		// POST api/<CustomerController>
		[HttpPost]
		public ActionResult Post([FromBody] Customer customer)
		{
			var result = DAL.Create_Customer(customer);
			if (!result.Item1)
			{
				return BadRequest(result.Item2.Message);
			}
			return Ok();
		}

		// PUT api/<CustomerController>/5
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] Customer customer)
		{
			DAL.Update_Customer(id, customer);
		}

		// DELETE api/<CustomerController>/5
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			DAL.Delete_Customer(id);
		}
	}
}
