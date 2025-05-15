using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NETCoreAPI_20250224_A.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		// GET: api/<CategoryController>
		[HttpGet]
		public List<Category> Get()
		{
			return DAL.Get_Categories();
		}

		// GET api/<CategoryController>/5
		[HttpGet("{id}")]
		public Category Get(int id)
		{
			return DAL.Get_Category(id);
		}

		// POST api/<CategoryController>
		[HttpPost]
		public void Post([FromBody] Category newCategory)
		{
			DAL.Create_Category(newCategory);
		}

		// PUT api/<CategoryController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Category category)
		{
			DAL.Update_Category(id, category);
		}

		// DELETE api/<CategoryController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			DAL.Delete_Category(id);
		}
	}
}
