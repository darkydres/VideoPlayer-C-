using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorVideo
{
    class PresentadorVentanaListas
    {
        IVentanaListas view;

        public PresentadorVentanaListas(IVentanaListas view)
        {
            this.view = view;
        }

        public void CrearListaReproduccion()
        {
            if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
            {
                ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
            }
            ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
            if (view.NombreLista != "")
            reproductorV.CrearListaReproduccion(view.NombreLista);
        }

        public ArrayPropio<ListaReproduccion> listasDeReproducciones()
        {
            if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
            {
                ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
            }
            ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
                return reproductorV.ListasReproducciones;
        }

        public void EliminarListaReproduccion()
        {
            if (view.ListaListasReproduccion != null)
            {
                ListaReproduccion nombreLista = view.ListaListasReproduccion as ListaReproduccion;
                ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
                reproductorV.QuitarListaReproduccion(nombreLista.NombreLista);
            }
        }
    }
}
