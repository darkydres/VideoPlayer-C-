using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorVideo
{
    [Serializable]
    class ListaReproduccion
    {
        String nombreLista;
        ArrayPropio<Video> videos;

        public ListaReproduccion(string nombreLista)
        {
            this.nombreLista = nombreLista;
            videos = new ArrayPropio<Video>();
        }

        public String NombreLista
        {
            get { return nombreLista; }
            set { nombreLista = value; }
        }

        public ArrayPropio<Video> Videos
        {
            get { return videos; }
            set { videos = value; }
        }

        public override string ToString()
        {
            return NombreLista;
        }
    }
}
