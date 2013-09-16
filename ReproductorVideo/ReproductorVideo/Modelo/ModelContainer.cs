using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorVideo
{
    class ModelContainer
    {
        public static ArrayPropio<ListaReproduccion> listasDeReproduccion { get; set; }
        public static ArrayPropio<ReproductorVideos> reproductorDeVideos { get; set; }

        static ModelContainer()
        {
            ModelContainer.reproductorDeVideos = new ArrayPropio<ReproductorVideos>();
            ModelContainer.listasDeReproduccion = new ArrayPropio<ListaReproduccion>();
        }
    }
}
