using System;

namespace Library
{
	public interface ICoffeeBar
	{
		void Charge (int price);

		int Brew (int amount)
		{
			Console.WriteLine ($"Brewing {amount} of coffee");
			return amount;
		}
	}
}
