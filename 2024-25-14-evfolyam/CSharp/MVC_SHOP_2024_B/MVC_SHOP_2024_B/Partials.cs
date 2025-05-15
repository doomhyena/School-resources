using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_SHOP_2024_B
{
	public partial class Authentic
	{
		[Required(ErrorMessage = "Felhasználónév megadása kötelező!")]
		[Display(Name = "Felhasználónév")]
		[StringLength(50, ErrorMessage = "Túl hosszú!")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Azonosító megadása kötelező!")]
		[Display(Name = "Dolgozó azonosító")]
		[Range(1, Int32.MaxValue - 1, ErrorMessage = "Csak pozitív egész szám lehet!")]
		public int EmployeeID { get; set; }

		[Required(ErrorMessage = "Jelszó megadása kötelező!")]
		[Display(Name = "Jelszó")]
		public string Password { get; set; }

		public virtual Employee Employee { get; set; }

		[NotMapped]
		public string Message { get; set; }
		public Authentic()
		{
			UserName = string.Empty;
			Message =  string.Empty;
			EmployeeID = int.MaxValue - 2;
		}
	}
}