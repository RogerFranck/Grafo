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
            ////Prueba 1 FindPath 
            //Grafo<string> grafo = new Grafo<string>();

            //Nodo<string> nodo1 = grafo.addNodo("A");
            //Nodo<string> nodo2 = grafo.addNodo("B");
            //Nodo<string> nodo3 = grafo.addNodo("C");
            //Nodo<string> nodo4 = grafo.addNodo("D");
            //Nodo<string> nodo5 = grafo.addNodo("E");

            //grafo.addArista(nodo1, nodo2, 10); //A-B
            //grafo.addArista(nodo1, nodo4, 1); //A-D
            //grafo.addArista(nodo4, nodo2, 2); //D-B
            //grafo.addArista(nodo4, nodo5, 10); //D-E
            //grafo.addArista(nodo5, nodo2, 2); //E-B
            //grafo.addArista(nodo5, nodo3, 1); //E-C
            //grafo.addArista(nodo2, nodo3, 20); //B-C

            //Console.WriteLine();
            //Console.WriteLine(grafo.ToString());

            //var resultado = grafo.findPath(nodo1, nodo3);
            //Console.WriteLine();
            //string Camino = "Camino: ";
            //foreach (Nodo<string> nodo in resultado.camino)
            //{
            //    Camino += $"{nodo.ToString()}, ";
            //}
            //Console.WriteLine($"Costo Minimo: {resultado.costoMin}");
            //Console.WriteLine(Camino);


            //Prueba 2 Find path
            Grafo<string> grafo2 = new Grafo<string>();

            Nodo<string> nodo1 = grafo2.addNodo("1");
            Nodo<string> nodo2 = grafo2.addNodo("2");
            Nodo<string> nodo3 = grafo2.addNodo("3");
            Nodo<string> nodo4 = grafo2.addNodo("4");
            Nodo<string> nodo5 = grafo2.addNodo("5");
            Nodo<string> nodo6 = grafo2.addNodo("6");
            Nodo<string> nodo7 = grafo2.addNodo("7");
            Nodo<string> nodo8 = grafo2.addNodo("8");

            grafo2.addArista(nodo1, nodo2); //1-2
            grafo2.addArista(nodo1, nodo4); //1-4
            grafo2.addArista(nodo2, nodo5); //2-5
            grafo2.addArista(nodo2, nodo4); //2-4
            grafo2.addArista(nodo4, nodo7); //4-7
            grafo2.addArista(nodo5, nodo6); //5-6
            grafo2.addArista(nodo6, nodo7); //6-7
            grafo2.addArista(nodo7, nodo8); //7-8
            grafo2.addArista(nodo3, nodo8); //8-3

            Console.WriteLine();
            Console.WriteLine(grafo2.ToString());

            var resultado2 = grafo2.findPath(nodo3, nodo1);
            Console.WriteLine();
            string Camino = "Camino: ";
            foreach (Nodo<string> nodo in resultado2.camino)
            {
                Camino += $"{nodo.ToString()}, ";
            }
            Console.WriteLine($"Costo Minimo: {resultado2.costoMin}");
            Console.WriteLine(Camino);



            //Métodos Clase Grafo
            Console.WriteLine(grafo2.ToString());
            Console.WriteLine();
            Console.WriteLine("\nAristas Nodo 1:\n" + nodo1.AristasToString());
            Console.WriteLine();

            Console.WriteLine("\n--Quitamos Arista entre nodo 1 y 2--");
            grafo2.removeArista(nodo1, nodo2);
            Console.WriteLine("Aristas Nodo 1:\n" + nodo1.AristasToString());

            Console.WriteLine("\n--Quitamos Nodo5--");
            grafo2.RemoveNodo(nodo5);
            Console.WriteLine("\nAristas Nodo 1:\n" + nodo1.AristasToString());
            Console.WriteLine("\nAristas Nodo 2:\n" + nodo2.AristasToString());

            Console.ReadLine();
        }
    }
}
