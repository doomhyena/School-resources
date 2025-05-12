using Automata_2024_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_2024_B
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<Product, int> products = new Dictionary<Product, int>()
			{
				{new Product("Kávé",ProductType.Drink){Price=250 },50 },
				{new Product("Tea",ProductType.Drink){Price=100 },100 },
				{new Product("Hell energiaital",ProductType.Drink){Price=400 },80 },
				{new Product("Balaton szelet",ProductType.Food){Price=250 },100 },
				{new Product("Müzli szelet",ProductType.Drink){Price=350 },100 }
			};
			Wallet wallet = new Wallet(){ _5 = 10, _10 = 10, _20 = 10, _50 = 10, _100 = 10, _200 = 10 };
			Automata a = new Automata(products, wallet);
			//List<Product> lista = a.API_GetProductsList();
			//a.API_InsertCoins(new Wallet());
			//bool success = a.Get_Product(lista.First());
			//if (a.CoinBackBox.Sum > 0)
			//{
			//	// person visszateszi a zsebébe
			//	a.CoinBackBox=new Wallet();
			//}
			//if (success)
			//{
			//	// person naplózza a vásárlást
			//}
			//-----------------
			Console.ReadKey();
		}
	}
}
