using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Arista<T>
    {
        public Nodo<T> origen;
        public Nodo<T> destino;
        int costo;

        public Arista(Nodo<T> Origen, Nodo<T> Destino, int setcosto)
        {
            origen = Origen;
            destino = Destino;
            costo = setcosto;
        }

        override public string ToString()
        {
            return $"Nodo Origen:{origen.ToString()}\nNodo Destino:{destino.ToString()}\nCosto:{costo}";
        }
    }
}
