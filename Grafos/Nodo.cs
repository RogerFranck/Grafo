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

        public void removeArista(Arista<T> borrarArista)
        {
            if(Aristas.FindIndex(e=> e == borrarArista) != -1)
            {
                Aristas.Remove(borrarArista);
            }
            else
            {
                throw new Exception("Couldn't find the especified edge");
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

        override public string ToString()
        {
            return $"(ID:{Id}, value:{Data.ToString()})";
        }
        public string AristasToString()
        {
            string str = "[\n";
            foreach (Arista<T> arista in Aristas)
            {
                str += $"{arista.ToString()}\n\n";
            }

            str += "]";
            return str;
        }
    }
}
