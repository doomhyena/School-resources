using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	internal class Model
	{
		public Board Board { get; set; }
		public Menu Menu { get; set; }
		public List<IActor> Actors { get; set; }
		public PacMan PacMan { get; set; }
		public Model(Size _size)
		{
			Menu = new Menu();
			Menu.Items.Add(new MenuItem("New Game"));
			Menu.Items.Add(new MenuItem("Load Game"));
			Menu.Items.Add(new MenuItem("Save Game"));
			Menu.Items.Add(new MenuItem("Exit Game"));
			Menu.Selected = Menu.Items.First().Id;
			Board = new Board(_size);
			Actors = new List<IActor>();
		}
	}
}
