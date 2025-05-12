using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_20240522_A.Models
{
	public partial class Employee
	{
		public bool East { get; set; }
		public string Name
		{
			get
			{
				return East ? $"{LastName} {FirstName}" : $"{FirstName} {LastName}";
			}
		}
	}
}
