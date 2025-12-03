using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupplierAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		// GET: api/<SupplierController>
		[HttpGet]
		public List<Supplier> Get()
		{
			return DAL.Get_Suppliers();
		}

		// GET api/<SupplierController>/5
		[HttpGet("{id}")]
		public Supplier Get(int id)
		{
			return DAL.Get_Suppliers(id);
		}

		// POST api/<SupplierController>
		[HttpPost]
		public void Post([FromBody] Supplier newSupplier)
		{
			DAL.Create_Supplier(newSupplier);
		}

		// PUT api/<SupplierController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Supplier editedSupplier)
		{
			DAL.Update_Supplier(id, editedSupplier);
		}

		// DELETE api/<SupplierController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			DAL.Delete_Supplier(id);
		}
	}
}
