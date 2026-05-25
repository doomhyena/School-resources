using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_2025_B
{
	public interface IAutomata
	{
		AutomataType AutomataType { get; }
		Wallet CoinBox { get; set; }
		bool IsFree { get; set; }
		List<Product> PriceList();
		bool ProductIsExits(int pID);
		Product Purchase(int selected, Wallet inserted);
	}
}
