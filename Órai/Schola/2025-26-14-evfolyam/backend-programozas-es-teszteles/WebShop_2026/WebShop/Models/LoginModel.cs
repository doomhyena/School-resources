
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "A felhasználónév megadása kötelező!")]
		[MaxLength(64, ErrorMessage = "Túl hosszú!")]
		[MinLength(6,ErrorMessage = "Túl rövid!")]
		[Display(Name ="Felhasználónév")]
		public string UserName { get; set; }



		[Required(ErrorMessage = "A jelszó megadása kötelező!")]
		[MinLength(6, ErrorMessage = "Túl rövid!")]
		[Display(Name = "Jelszó")]
		public string Password { get; set; }
	}
}