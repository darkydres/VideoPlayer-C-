using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorVideo
{
    interface IMainWindow
    {
        String BuscarVideoEnListas { get; set; }
        String BuscarVideoEnUnicaLista { get; set; }
        String NombresVideoEncontradoEnListas { get; }
        String NombreListaReproduccion { get; }
        String NombreEtiqueta { get; set; }
        String Nombre { set; }
        String Tamaño { set; }
        String Ruta { set; }
        String Posicion { set; }
        Object ListaVideos { get; }
        Object ListaEtiquetasBuscar { get; }
        Object ListaEtiquetas { get; }
        Object NombreEtiquetaVideo { get; }
    }
}
