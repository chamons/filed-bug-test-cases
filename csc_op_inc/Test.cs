using System;

#if USE_XM
using nuint = System.nuint;
#else
using nuint = CSCHack.nuint;
#endif

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

