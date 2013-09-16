using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReproductorVideo
{
    class PresentadorMainWindow
    {
        IMainWindow view;
        public PresentadorMainWindow(IMainWindow view)
        {
            this.view = view;
        }

        public void AgregarVideoALista(String rutaVideo, int posicion, ArrayPropio<String> listaEtiquetas,bool reproduciendo)
        {
            int posAux = 0;
            if (view.NombreListaReproduccion != "" && rutaVideo != "")
            {
                FileInfo file = new FileInfo(rutaVideo);
                if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
                {
                    ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
                }
                
                ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];

                if (posicion == -1)
                {
                    for (int i = 0; i < reproductorV.ListasReproducciones.darTamanio(); i++)
                    {
                        if (reproductorV.ListasReproducciones[i].NombreLista == view.NombreListaReproduccion)
                        {
                            if (reproductorV.ListasReproducciones[i].Videos.darTamanio() != 0)
                            {
                                for (int o = 0; o < reproductorV.ListasReproducciones[i].Videos.darTamanio(); o++)
                                {
                                    if (reproductorV.ListasReproducciones[i].Videos[o].Posicion > posAux)
                                    {
                                        posAux = reproductorV.ListasReproducciones[i].Videos[o].Posicion;
                                    }
                                }
                                posAux += 1;
                            }
                        }
                    }
                }
                else
                {
                    if (reproduciendo == true)
                    {
                        for (int i = 0; i < reproductorV.ListasReproducciones.darTamanio(); i++)
                        {
                            if (reproductorV.ListasReproducciones[i].NombreLista == view.NombreListaReproduccion)
                            {
                                if (reproductorV.ListasReproducciones[i].Videos.darTamanio() != 0)
                                {
                                    for (int o = 0; o < reproductorV.ListasReproducciones[i].Videos.darTamanio(); o++)
                                    {
                                        if (reproductorV.ListasReproducciones[i].Videos[o].Posicion >= posicion)
                                        {
                                            reproductorV.ListasReproducciones[i].Videos[o].Posicion += 1;
                                        }
                                    }
                                    posAux = posicion;
                                }
                            }
                        }
                    }
                }
               
                Video video = new Video(file.Name, file.Length.ToString(), rutaVideo,posAux,listaEtiquetas);
                reproductorV.AgregarVideosAListaReproduccion(view.NombreListaReproduccion, video);
            }
        }

        public void SubirVideoPosicion(int posicion)
        {
            bool encontro = false;
            int posAux =0;
            Video video = null;
            if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
            {
                ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
            }
            ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
            if (posicion != -1)
            {
                for (int i = 0; i < reproductorV.ListasReproducciones.darTamanio(); i++)
                {
                    if (reproductorV.ListasReproducciones[i].NombreLista == view.NombreListaReproduccion)
                    {
                        if (reproductorV.ListasReproducciones[i].Videos.darTamanio() != 0)
                        {
                            for (int o = 0; o < reproductorV.ListasReproducciones[i].Videos.darTamanio(); o++)
                            {
                                if (encontro == false)
                                {
                                    if (reproductorV.ListasReproducciones[i].Videos[o].Posicion == posicion)
                                    {
                                        if (reproductorV.ListasReproducciones[i].Videos[o].Posicion + 1 < reproductorV.ListasReproducciones[i].Videos.darTamanio())
                                        {
                                            reproductorV.ListasReproducciones[i].Videos[o].Posicion += 1;
                                            posAux = reproductorV.ListasReproducciones[i].Videos[o].Posicion;
                                            encontro = true;
                                            video = reproductorV.ListasReproducciones[i].Videos[o];
                                            o = -1;
                                        }
                                    }
                                }
                                else
                                {
                                    if (reproductorV.ListasReproducciones[i].Videos[o].Posicion == posAux && reproductorV.ListasReproducciones[i].Videos[o] != video)
                                    {
                                        reproductorV.ListasReproducciones[i].Videos[o].Posicion -= 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void BajarVideoPosicion(int posicion)
        {
            bool encontro = false;
            int posAux = 0;
            Video video = null;
            if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
            {
                ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
            }
            ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
            if (posicion != -1)
            {
                for (int i = 0; i < reproductorV.ListasReproducciones.darTamanio(); i++)
                {
                    if (reproductorV.ListasReproducciones[i].NombreLista == view.NombreListaReproduccion)
                    {
                        if (reproductorV.ListasReproducciones[i].Videos.darTamanio() != 0)
                        {
                            for (int o = 0; o < reproductorV.ListasReproducciones[i].Videos.darTamanio(); o++)
                            {
                                if (encontro == false)
                                {
                                    if (reproductorV.ListasReproducciones[i].Videos[o].Posicion == posicion)
                                    {
                                        if (reproductorV.ListasReproducciones[i].Videos[o].Posicion - 1 >= 0)
                                        {
                                            reproductorV.ListasReproducciones[i].Videos[o].Posicion -= 1;
                                            posAux = reproductorV.ListasReproducciones[i].Videos[o].Posicion;
                                            encontro = true;
                                            video = reproductorV.ListasReproducciones[i].Videos[o];
                                            o = -1;
                                        }
                                    }
                                }
                                else
                                {
                                    if (reproductorV.ListasReproducciones[i].Videos[o].Posicion == posAux && reproductorV.ListasReproducciones[i].Videos[o] != video)
                                    {
                                        reproductorV.ListasReproducciones[i].Videos[o].Posicion += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void MostrarContenido()
        {
            Video video = view.ListaVideos as Video;
            view.Nombre = video.Nombre;
            view.Tamaño = video.Tamaño;
            view.Ruta = video.Ruta;
            view.Posicion = video.Posicion.ToString();
        }

        public ArrayPropio<String> MostrarEtiquetasVideo()
        {
            ArrayPropio<String> listaEtiquetas = new ArrayPropio<string>();
            Video video = view.ListaVideos as Video;
            for (int i = 0; i < video.Etiqueta.darTamanio(); i++)
            {
                listaEtiquetas.add(video.Etiqueta[i]);
            }
            return listaEtiquetas;
        }

        public void AgregarVideoAlPrincipioDeLista(String rutaVideo, ArrayPropio<String> listaEtiquetas)
        {
            int posAux = 0;
            FileInfo file = null;
            if (view.NombreListaReproduccion != "")
            {
                if (rutaVideo != "" && rutaVideo != null)
                {
                    file = new FileInfo(rutaVideo);

                    if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
                    {
                        ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
                    }

                    ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];


                    for (int i = 0; i < reproductorV.ListasReproducciones.darTamanio(); i++)
                    {
                        if (reproductorV.ListasReproducciones[i].NombreLista == view.NombreListaReproduccion)
                        {
                            if (reproductorV.ListasReproducciones[i].Videos.darTamanio() != 0)
                            {
                                for (int o = 0; o < reproductorV.ListasReproducciones[i].Videos.darTamanio(); o++)
                                {
                                    if (reproductorV.ListasReproducciones[i].Videos[o].Posicion >= 0)
                                    {
                                        reproductorV.ListasReproducciones[i].Videos[o].Posicion += 1;
                                    }
                                }
                            }
                        }
                    }
                    Video video = new Video(file.Name, file.Length.ToString(), rutaVideo, posAux, listaEtiquetas);
                    reproductorV.AgregarVideosAListaReproduccion(view.NombreListaReproduccion, video);
                }
            }
        }

        public ArrayPropio<Video> BuscarVideoPorEtiqueta()
        {
            ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
            string etiqueta = view.ListaEtiquetasBuscar as String;
            return reproductorV.BuscarVideoPorEtiqueta(etiqueta); ;
        }

        public void AgregarEtiquetas()
        {
            
            if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
            {
                ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
            }
            ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
            reproductorV.AgregarEtiquetasALista(view.NombreEtiqueta);
        }

        public ArrayPropio<String> ActualizarListaEtiquetas()
        {
            ArrayPropio<String> etiquetas = new ArrayPropio<string>(); ;
            if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
            {
                ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
            }
            for (int i = 0; i < ModelContainer.reproductorDeVideos[0].ListaEtiquetas.darTamanio(); i++)
            {
                etiquetas.add(ModelContainer.reproductorDeVideos[0].ListaEtiquetas[i]);
            }
            return etiquetas;

        }

        public ArrayPropio<Video> ActualizarLista()
        {
            ArrayPropio<Video> lista = new ArrayPropio<Video>();
            if (view.NombreListaReproduccion != "" && view.NombreListaReproduccion != null)
            {
                for (int i = 0; i < ModelContainer.reproductorDeVideos[0].ListasReproducciones.darTamanio(); i++)
                {
                    if (view.NombreListaReproduccion == ModelContainer.reproductorDeVideos[0].ListasReproducciones[i].NombreLista)
                    {
                        lista = ModelContainer.reproductorDeVideos[0].ListasReproducciones[i].Videos;
                    }
                }
            }
            return lista;
        }

        public ArrayPropio<String> CargarListaNombresListasReproduccion()
        {
            ArrayPropio<String> aux = new ArrayPropio<string>();
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            for (int i = 0; i < reproductor.ListasReproducciones.darTamanio(); i++)
            {
                aux.add(reproductor.ListasReproducciones[i].NombreLista);
            }
            return aux;
        }

        public ArrayPropio<Video> BuscarVideoPorMedioDeListasEncontradas()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            return reproductor.BuscarVideosEnLista(view.NombresVideoEncontradoEnListas, view.BuscarVideoEnListas, view.BuscarVideoEnListas.Length);
        }

        public ArrayPropio<Video> BuscarVideoEnLista()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            return reproductor.BuscarVideosEnLista(view.NombreListaReproduccion,view.BuscarVideoEnUnicaLista,view.BuscarVideoEnUnicaLista.Length);
        }

        public ArrayPropio<String> ListasDondeApareceVideo()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            return reproductor.BuscarVideoEnListas(view.BuscarVideoEnListas, view.BuscarVideoEnListas.Length);
        }

        public ArrayPropio<Video> BuscarVideoEnListas()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            return reproductor.BuscarVideosEnLista(view.NombresVideoEncontradoEnListas, view.BuscarVideoEnListas, view.BuscarVideoEnListas.Length);
        }

        public void QuitarVideo()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            if (view.NombreListaReproduccion != null && view.ListaVideos != null)
            reproductor.QuitarVideoLista(view.NombreListaReproduccion,view.ListaVideos as Video);

            Video video = view.ListaVideos as Video;
            for(int  i=0; i < reproductor.ListasReproducciones.darTamanio();i++)
            {
                if (reproductor.ListasReproducciones[i].NombreLista == view.NombreListaReproduccion)
                {
                    for (int a = 0; a < reproductor.ListasReproducciones[i].Videos.darTamanio(); a++)
                    {
                        if (reproductor.ListasReproducciones[i].Videos[a].Posicion > video.Posicion)
                        {
                            reproductor.ListasReproducciones[i].Videos[a].Posicion -= 1; 
                        }
                    }
                }
            }
        }

        public void EliminarEtiquetaDeUnVideo()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            
                String nombreLista = view.NombreListaReproduccion as String;
                String nombreEtiqueta = view.NombreEtiquetaVideo as String;
                Video video = view.ListaVideos as Video;
                reproductor.EliminarEtiquetaDeVideo(nombreLista, nombreEtiqueta, video);
        }

        public void QuitarEtiqueta()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            reproductor.QuitarEtiqueta(view.ListaEtiquetas as String);
        }

        public void GuardarListas()
        {
            ReproductorVideos reproductor = ModelContainer.reproductorDeVideos[0];
            reproductor.GuardarListas();
        }

        public void CargarListas()
        {
            if (ModelContainer.reproductorDeVideos.darTamanio() == 0)
            {
                ModelContainer.reproductorDeVideos.add(new ReproductorVideos());
            }
            ReproductorVideos reproductorV = ModelContainer.reproductorDeVideos[0];
            reproductorV.CargarListas();
        }
    }
}
