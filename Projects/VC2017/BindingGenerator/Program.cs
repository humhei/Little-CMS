using CppSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleDriver.Run(new CppSharpInterfaceGenerator());
            Console.WriteLine("Done");
        }
    }
}
