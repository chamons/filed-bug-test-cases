using System;

namespace dotnet_global_tool_args
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine ($"Hello: {string.Join (" ", args)}");
        }
    }
}
