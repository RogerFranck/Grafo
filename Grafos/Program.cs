using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine(string.Join(",", numeros));
            numeros.Remove(3);
            Console.WriteLine(string.Join(",", numeros));

            Console.ReadLine();
        }
    }
}
