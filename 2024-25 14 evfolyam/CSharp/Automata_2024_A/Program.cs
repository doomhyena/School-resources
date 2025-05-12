using Automata_2024_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Automata_2024_A
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<Product, int> products = new Dictionary<Product, int>() {
				{new Product("Kávé",200,ProductType.Drink),10 },
				{new Product("Tea",100,ProductType.Drink),50 },
				{new Product("Balaton szelet",250,ProductType.Food),10 },
				{new Product("Mars szelet",200,ProductType.Food),20 },
				{new Product("Hell energiaital",300,ProductType.Drink),30 },

			};
			Wallet wallet = new Wallet() { _5 = 10, _10 = 10, _20 = 10, _50 = 10, _100 = 0, _200 = 0 };
			Automata a1 = new Automata(products, wallet);

			//a1.Purchase();
			List<Product> drinks = a1.API_GetProducts(ProductType.Drink);
			bool purchase = a1.API_Purchase(products.Keys.First(), new Wallet() { _100 = 1, _50 = 2 });
			if (a1.ChangeCoins.Sum>0)
			{
				// person elteszi a visszajárót
				a1.ChangeCoins = new Wallet();
			}

			//---------------------
			Console.ReadKey();
		}
	}
}
