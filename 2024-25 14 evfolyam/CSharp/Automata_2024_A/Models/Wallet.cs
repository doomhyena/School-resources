
using System;

namespace Automata_2024_A.Models
{
	public struct Wallet
	{
		public int _5 { get; set; }
		public int _10 { get; set; }
		public int _20 { get; set; }
		public int _50 { get; set; }
		public int _100 { get; set; }
		public int _200 { get; set; }
		public int Sum
		{
			get
			{
				return _5 * 5 + _10 * 10 + _20 * 20 + _50 * 50 + _100 * 100 + _200 * 200;
			}
		}

		internal void Add(Wallet t)
		{
			_5 += t._5;
			_10 += t._10;
			_20 += t._20;
			_50 += t._50;
			_100 += t._100;
			_200 += t._200;
		}

		public override string ToString()
		{
			return String.Format($"5:{_5} | 10:{_10} | 20:{_20} | 50:{_50} | 100:{_100} | 200:{_200} | Sum:{Sum:C0}");
		}
	}
}
