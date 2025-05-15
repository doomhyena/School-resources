using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	class Model
	{
		public Board MyBoard { get; set; }
		public Menu MyMenu { get; set; }
		public List<IActor> Actors { get; set; }
		public PacMan PacMan { get; set; }
		public Model(Size _mazeSize)
		{			
			List<MenuItem> menuItems = new List<MenuItem>() {
									{new MenuItem("New Game") },
									{ new MenuItem("Load Game")},
									{ new MenuItem("Save Game")},
									{ new MenuItem("Exit")}
									};
			MyMenu = new Menu(menuItems);
			MyBoard = new Board(_mazeSize);
			Actors = new List<IActor>();			
		}
		
	}
}
