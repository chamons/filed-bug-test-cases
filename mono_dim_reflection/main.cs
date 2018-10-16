using System;
using System.Collections.Generic;
using System.Linq;
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
			ICoffeeBar barAsInterface = new CoffeeBar ();
			ICoffeeBar barAsConcrete = new CoffeeBar ();

			Console.WriteLine ("Methods on CoffeeBar:");
			Console.WriteLine (string.Join ("\n", typeof (CoffeeBar).GetMethods ().Select (x => "\t" + x.Name)));
			Console.WriteLine ("Methods on ICoffeeBar:");
			Console.WriteLine (string.Join ("\n", typeof (ICoffeeBar).GetMethods ().Select (x => "\t" + x.Name)));

			typeof (ICoffeeBar).GetMethod ("Brew").Invoke (barAsInterface, new object [] { 1 });
			typeof (ICoffeeBar).GetMethod ("Brew").Invoke (barAsConcrete, new object [] { 1 });
		}
	}
}
