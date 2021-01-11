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
            Grafo<string> grafo = new Grafo<string>();

            Nodo<string> nodo1 = grafo.addNodo("Tostado");
            Nodo<string> nodo2 = grafo.addNodo("Sergio");
            Nodo<string> nodo3 = grafo.addNodo("Roger");
            Nodo<string> nodo4 = grafo.addNodo("Luis");

            grafo.addArista(nodo1, nodo2);
            grafo.addArista(nodo1, nodo3);
            grafo.addArista(nodo4, nodo1);
            grafo.addArista(nodo2, nodo4);

            Console.WriteLine(grafo.ToString());
            Console.WriteLine();
            Console.WriteLine(nodo1.AristasToString());
            Console.WriteLine();

            grafo.removeArista(nodo3, nodo1);
            Console.WriteLine(nodo1.AristasToString());

            grafo.RemoveNodo(nodo4);
            Console.WriteLine();
            Console.WriteLine(grafo.ToString());
            Console.WriteLine("\nAristas Nodo 1:\n" + nodo1.AristasToString());
            Console.WriteLine("\nAristas Nodo 2:\n" + nodo2.AristasToString());


            Console.ReadLine();
        }
    }
}
