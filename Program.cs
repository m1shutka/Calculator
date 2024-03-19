using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            TPNumber num = new TPNumber(0.001, 10, 5);
            Console.WriteLine(num.Number);
            Console.WriteLine(num.IntAcc);
            num.IntP = 2;
            Console.WriteLine(num.Number);
            Console.WriteLine(num.IntAcc);
            Console.WriteLine(num.StrP);
        }
    }

}