using System;

using nuint = System.nuint;

namespace Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			for (nuint i = 0; i < (nuint)2; i++)
				System.Console.WriteLine (i);
		}
	}
}

