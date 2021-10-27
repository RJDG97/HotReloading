using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace HotReloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    CompileDLL();
                    Console.WriteLine("Compile DLL");
                }
                if (key.Key == ConsoleKey.Spacebar)
                    Print();
                if (key.Key == ConsoleKey.Escape)
                    break;
            };
        }
        public static void Print()
        {
            Console.WriteLine("Check");
        }
    }
}
