using System;
using Library;

namespace Main
{
	public class CoffeeBar : ICoffeeBar
	{
		public void Charge (int price)
		{
			Console.WriteLine ($"Charging for amount of {price}");
		}
	}

	public static class EntryPoint
	{
		public static void Main ()
		{
			CoffeeBar bar = new CoffeeBar ();
			bar.Charge (2);
			bar.Brew (1);
		}
	}
}
