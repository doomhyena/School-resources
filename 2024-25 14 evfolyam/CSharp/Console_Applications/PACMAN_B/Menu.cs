using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	class Menu
	{
		public List<MenuItem> Items { get; set; }
		public int Selected { get; set; }
		public int MaxID { get { return Items.Max(q => q.ID); } }
		public int MinID { get { return Items.Min(q => q.ID); } }
		public Menu(List<MenuItem> _items)
		{
			Items = _items;
			Selected = Items.First().ID;
		}
	}

	class MenuItem
	{
		private static int _id = 1;
		public int ID { get; set; }
		public String Name { get; set; }
		public MenuItem(String _name)
		{
			ID = _id++;
			Name = _name;
		}
	}
}
