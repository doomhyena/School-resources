using DB;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShop_Core_2025_A.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		// GET: api/<ProductController>
		[HttpGet]
		public List<Product> Get()
		{
			return DAL.Get_Products();
		}

		[HttpGet("by-category/{categoryID}")]
		public List<Product> GetProductsByCategory(int categoryID)
		{
			return DAL.Get_Products(categoryID);
		}

		// GET api/<ProductController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ProductController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<ProductController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ProductController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
