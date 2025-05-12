using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_2024_A.Models
{
	public class ShopIndexModel
	{
        public List<Category> Categories { get; set; }
        public int SelectedCategoryID { get; set; }
        public List<Product> Products { get; set; }
    }
}