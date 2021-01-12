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

        public (int? costoMin, List<Nodo<T>> camino) findPath(Nodo<T> Origen, Nodo<T> Destino)
        {

            List<Nodo<T>> Visitados = new List<Nodo<T>>();
            List<Nodo<T>> NoVisitados = new List<Nodo<T>>(Nodos);          

            //Tabla de registros
            Dictionary<int, (int? costo, Nodo<T> anterior)> Registros = new Dictionary<int, (int?, Nodo<T>)>();

            foreach(Nodo<T> nodo in NoVisitados)
            {
                Registros.Add(nodo.Id, (null, null));
            }
            Registros[Origen.Id] = (0, null);

            Nodo<T> NodoActual = Origen;
            int costoAcumulado = 0;

            while (Visitados.Count < Nodos.Count)
            {
                //Evaluar las opciones de Arista que tiene el nodo actual y Elegir la Arista con el menor costo               
                Arista<T> costoMin = null;
                NoVisitados.Remove(NodoActual);
                foreach (Arista<T> aristaActual in NodoActual.Aristas)
                {
                    if(Visitados.FindIndex(e => e == getOtherNode(aristaActual, NodoActual)) != -1)
                    {
                        continue;
                    }
                    //Actualizar menor costo
                    //if(costoMin == null || aristaActual.costo<costoMin.costo)
                    //{
                    //    costoMin = aristaActual;
                    //}
                    //Actualizar nodos destino en Registro solo si representa un costo menor al ya registrado
                    Nodo<T> NodoDestino = getOtherNode(aristaActual, NodoActual);
                    if (Registros[NodoDestino.Id].costo > Registros[NodoActual.Id].costo + aristaActual.costo || Registros[NodoDestino.Id].costo == null)
                    {
                        Registros[NodoDestino.Id] = (Registros[NodoActual.Id].costo + aristaActual.costo, NodoActual);
                    }
                }
                Visitados.Add(NodoActual);
                //costoAcumulado += costoMin.costo;

                //Encontrar el de mínimo costo dentro de los No Visitados
                Nodo<T> min = null;
                foreach(Nodo<T> nodo in NoVisitados)
                {
                    //No considerar el cero
                    if(Registros[nodo.Id].costo == 0)
                    {
                        continue;
                    }
                    if(min == null || Registros[nodo.Id].costo < Registros[min.Id].costo || (Registros[min.Id].costo == null))
                    {
                        min = nodo;
                    }
                }
                NodoActual = min;
            }

            NodoActual = Destino;
            List<Nodo<T>> Camino = new List<Nodo<T>>();
            Camino.Add(Destino);
            while (Registros[NodoActual.Id].anterior != null)
            {
                Camino.Add(Registros[NodoActual.Id].anterior);
                NodoActual = Registros[NodoActual.Id].anterior;
            }
            Camino.Reverse();

            return (Registros[Destino.Id].costo, Camino);
        }

        private Nodo<T> getOtherNode(Arista<T> arista, Nodo<T> thisNode) 
        {
            if (arista.origen == thisNode)
            {
                return arista.destino;
            }
            else if (arista.destino == thisNode)
            {
                return arista.origen;
            }
            else
            {
                return null;
            }
        }
    }
}
