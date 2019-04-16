using System;
using System.Runtime.CompilerServices;

namespace Tooling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var version = typeof(Program).Assembly.GetName().Version;
            Console.WriteLine(version);
        }
    }
}
