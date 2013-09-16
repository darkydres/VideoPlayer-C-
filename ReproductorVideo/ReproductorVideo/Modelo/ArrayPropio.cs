using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;

namespace ReproductorVideo
{
    [Serializable]
    public class ArrayPropio<T>
    {
        private T[] elementos;
        private int tamanio;
        protected int modificaciones;

        public ArrayPropio()
        {
            elementos = new T[10];
        }

        public ArrayPropio(int inicial)
        {
            if (inicial < 0)
            {
                throw new Exception("El tamaño inicial no es valido");
            }
            this.elementos = (T[])new T[inicial];
        }

        public void add(T objeto)
        {
            validarCapacidad(tamanio + 1);
            elementos[tamanio++] = objeto;
        }

        public T this[int i]
        {
            get { return elementos[i]; }
            set { elementos[i] = value; }
        }

        public int darTamanio()
        {
            return this.tamanio;
        }

        public void validarCapacidad(int capacidadMinima)
        {
           modificaciones++;
           int viejaCapacidad = elementos.Length;
           if (capacidadMinima > viejaCapacidad)
           {
               T[] datosViejos = elementos;
               int nuevaCapacidad = (viejaCapacidad * 3) / 2 + 1;
               if (nuevaCapacidad < capacidadMinima)
               {
                   nuevaCapacidad = capacidadMinima;
               }
               elementos = (T[])new T[nuevaCapacidad];
               Array.Copy(datosViejos, 0, elementos, 0, tamanio);
           }
        }

        public void remove(int i)
        {
            if (i >= tamanio)
            {
                throw new Exception("El indice esta mas alla del tamaño del arreglo");
            }

            modificaciones++;
            Object valorViejo = elementos[i];

            int numeroMovido = tamanio - i - 1;
            if (numeroMovido > 0)
            {
                Array.Copy(elementos, i + 1, elementos, i, numeroMovido);
            }
            elementos[--tamanio] = default(T);
        }

        public T[] getArray()
        {
            return elementos;
        }

        public Boolean Contains(Object palabra)
        {
            bool Encontrado = false; 
            for(int i = 0; i < elementos.Length; i++)
            {
                if(elementos[i] != null)
                if (elementos[i].Equals(palabra))
                {
                    Encontrado = true;
                }
            }
            return Encontrado;
        }
    }
}
