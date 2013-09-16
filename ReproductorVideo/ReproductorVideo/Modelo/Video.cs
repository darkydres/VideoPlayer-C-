using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorVideo
{
    [Serializable]
    class Video
    {
        String nombre;
        String tamaño;
        String ruta;
        int posicion;
        ArrayPropio<String> etiqueta;
        public Video(string nombre, string tamaño, string ruta, int posicion, ArrayPropio<String> etiqueta)
        {
            this.nombre = nombre;
            this.tamaño = tamaño;
            this.ruta = ruta;
            this.posicion = posicion;
            this.etiqueta = etiqueta;
        }

        public String Nombre
        {
            get { return nombre; }
            set{nombre = value;}
        }

        public String Tamaño
        {
            get { return tamaño; }
            set { tamaño = value; }
        }

        public String Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }

        public ArrayPropio<String> Etiqueta
        {
            get { return etiqueta; }
            set { etiqueta = value; }
        }

        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
