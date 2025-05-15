using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_20240522.Models
{
	public partial class Employee
	{
		public string Name { get => $"{LastName} {FirstName}"; }
	}
}
