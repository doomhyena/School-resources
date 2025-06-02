using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_2025_B
{
	public class Wallet
	{
		//5,10,20,50,100,200
		//-------------------
		//2,3,0,1,0,1
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

		public Wallet(int _5, int _10, int _20, int _50, int _100, int _200)
		{
			this._5 = _5;
			this._10 = _10;
			this._20 = _20;
			this._50 = _50;
			this._100 = _100;
			this._200 = _200;
		}
		public Wallet(string inserted)
		{
			string[] insA = inserted.Split(',');
			int[] result = new int[6];
			if (insA.Length == 6)
			{
				_5 = int.Parse(insA[0]);
				_10 = int.Parse(insA[1]);
				_20 = int.Parse(insA[2]);
				_50 = int.Parse(insA[3]);
				_100 = int.Parse(insA[4]);
				_200 = int.Parse(insA[5]);
			}
			else
			{
				_5 = _10 = _20 = _50 = _100 = _200 = 0;
			}
		}
		public Wallet()
		{

		}
		public Wallet(Wallet s)
		{
			_5= s._5;
			_10 = s._10;
			_20 = s._20;
			_50 = s._50;
			_100 = s._100;
			_200 = s._200;
		}
		public void Clear()
		{
			_5 = _10 = _20 = _50 = _100 = _200 = 0;
		}
		public Wallet Clone()
		{
			return new Wallet(_5, _10, _20, _50, _100, _200);
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
			return $"5:{_5} |10:{_10} |20:{_20} |50:{_50} |100:{_100} |200:{_200} ||Összesen:{Sum} Ft";
		}
	}
}
