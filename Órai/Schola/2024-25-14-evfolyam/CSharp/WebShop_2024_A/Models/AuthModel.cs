using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_2024_A.Models
{
	public class AuthModel
	{
		public User User { get; set; }
		public string Message { get; set; }
		public bool IsRegistration { get; set; }

		public AuthModel()
		{
			Message = string.Empty;
			User = new User();
		}
	}
}