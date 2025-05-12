using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	internal class Menu
	{
		public List<MenuItem> Items { get; set; }
		public int Selected { get; set; }
		public int MinID { get { return Items.Min(q => q.Id); } }
		public int MaxID { get { return Items.Max(q => q.Id); } }
		public Menu()
		{
			Items = new List<MenuItem>();
		}
	}

	public class MenuItem
	{
		private static int id = 1;
		public int Id { get; private set; }
		public string Text { get; private set; }

		public MenuItem(String _text)
		{
			Id = id++;
			Text = _text;
		}
	}
}
