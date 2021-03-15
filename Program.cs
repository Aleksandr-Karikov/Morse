using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morse_code
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Morse.TranslateToMorse(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
