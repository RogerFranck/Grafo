using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Grafo <T>
    {
        List<Nodo<T>> Nodos = new List<Nodo<T>>();
        private int contador;

        public Grafo()
        {
            contador = 0;
        }
        
        public Nodo<T> addNodo(T value)
        {
            contador++;
            Nodo<T> newNode = new Nodo<T>(contador, value);
            Nodos.Add(newNode);
            
            return newNode;
        }

        public void addArista(Nodo<T> nodo1, Nodo<T> nodo2, int costo = 1)//id, referencia al nodo
        {
            //Validando que no existe una arista con esta conexión 
            bool existe = false;
            foreach(Arista<T> aristaActual in nodo1.Aristas)
            {
                if(aristaActual.origen == nodo1 && aristaActual.destino == nodo2 || aristaActual.origen == nodo2 && aristaActual.destino == nodo1)
                {
                    existe = true;
                }
            }

            //Si no existe uno previamente, crea uno nuevo y añadelo a la lista de Aristas de los 2 nodos
            if (!existe)
            {
                Arista<T> newArista = new Arista<T>(nodo1, nodo2, costo);
                nodo1.Aristas.Add(newArista);
                nodo2.Aristas.Add(newArista);
            }
        }

        public void RemoveNodo(Nodo<T> nodoBorrar)
        {
            if(Nodos.FindIndex(e => e == nodoBorrar) != -1)
            {
                nodoBorrar.BorrarNodo(); //Borre todas las aristas en los otros nodos
                Nodos.Remove(nodoBorrar); //Borrar nodo Actual 
            }
            else
            {
                throw new Exception("Couldn't find the especified node" );
            }
        }
        public void removeArista(Nodo<T> nodo1, Nodo<T> nodo2)
        {
            
            for(int i = 0; i<nodo1.Aristas.Count; i++)
            {
                Arista<T> aristaActual = nodo1.Aristas[i];
                if (aristaActual.origen == nodo1 && aristaActual.destino == nodo2 || aristaActual.origen == nodo2 && aristaActual.destino == nodo1)
                {
                    nodo1.removeArista(aristaActual);
                    nodo2.removeArista(aristaActual);
                }
            }
        }

        override public string ToString()
        {
            string str = "[ ";
            foreach(Nodo<T> nodo in Nodos)
            {
                str += $"{nodo.ToString()}, ";
            }

            str += "]";
            return str;
        }
    }
}
