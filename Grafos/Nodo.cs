using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Nodo<T>
    {
        public T Data { get; set; }
        public List<Arista<T>> Aristas = new List<Arista<T>>();
        public int Id;

        public Nodo(int id, T data)
        {
            Id = id;
            Data = data;
        }

        public void addArista(Arista<T> nuevaArista)
        {
            Aristas.Add(nuevaArista);
        }

        public void removeArista(Arista<T> borrarArista)
        {
            foreach(Arista<T> aristaActual in Aristas)
            {
                if(aristaActual == borrarArista)
                {
                    Aristas.Remove(aristaActual);
                }
            }
        }
        public void BorrarNodo()
        {
            foreach(Arista<T> aristaActual in Aristas)
            {
               if(Id == aristaActual.origen.Id)
               {
                    aristaActual.destino.removeArista(aristaActual);
               }
               else if(Id == aristaActual.destino.Id)
               {
                    aristaActual.origen.removeArista(aristaActual);
               }
            }
        }
    }
}
