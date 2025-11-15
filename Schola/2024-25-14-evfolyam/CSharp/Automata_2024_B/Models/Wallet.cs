using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_2024_B.Models
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
		
		public void Copy(Wallet source)
		{ 
			_5 = source._5;
			_10 = source._10;
			_20 = source._20;
			_50 = source._50;
			_100 = source._100;
			_200 = source._200;
		}

		public void Add(Wallet w)
		{
			_5 += w._5;
			_10 += w._10;
			_20 += w._20;
			_50 += w._50;
			_100 += w._100;
			_200 += w._200;

		}
		public override string ToString()
		{
			return String.Format($"5:{_5} | 10:{_10} | 20:{_20} | 50:{_50} | 100:{_100} | 200:{_200} |Sum:{Sum:C0}")	;
		}
	}
}
