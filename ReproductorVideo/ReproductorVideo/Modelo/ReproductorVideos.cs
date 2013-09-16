using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorVideo
{
    class ReproductorVideos
    {
        ArrayPropio<ListaReproduccion> listasReproducciones;
        ArrayPropio<String> listaEtiquetas;

        public ReproductorVideos()
        {
            listasReproducciones = new ArrayPropio<ListaReproduccion>();
            listaEtiquetas = new ArrayPropio<string>();
        }

        public void AgregarEtiquetasALista(String etiqueta)
        {
            if(!listaEtiquetas.Contains(etiqueta))
            listaEtiquetas.add(etiqueta);
        }

        public ArrayPropio<Video> BuscarVideoPorEtiqueta(String etiqueta)
        {
            ArrayPropio<Video> videosEncontrados = new ArrayPropio<Video>();
            //bool encontro = false;
            for (int i = 0; i < listasReproducciones.darTamanio(); i++)
            {
                for (int m = 0; m < listasReproducciones[i].Videos.darTamanio(); m++)
                {
                    for(int l =0; l < listasReproducciones[i].Videos[m].Etiqueta.darTamanio();l++)
                    {
                        //encontro = false;
                        if (listasReproducciones[i].Videos[m].Etiqueta[l].Equals(etiqueta))
                        {
                            //encontro = true;
                            if (!videosEncontrados.Contains(listasReproducciones[i].Videos[m]))
                            {
                                videosEncontrados.add(listasReproducciones[i].Videos[m]);
                            }
                        }
                    }
                }
            }
            return videosEncontrados;
        }

        public void QuitarEtiqueta(String etiqueta)
        {
            for(int i =0; i < listaEtiquetas.darTamanio();i++)
            {
                if(listaEtiquetas[i] == etiqueta)
                {
                    listaEtiquetas.remove(i);
                }
            }
        }

        public void CrearListaReproduccion(string nombreLista)
        {
            bool encontro = false;
            for (int i = 0; i < listasReproducciones.darTamanio(); i++)
            {
                    if (listasReproducciones[i].NombreLista == nombreLista)
                    {
                        encontro = true;
                    }
            }

            if (encontro == false)
            {
                ListaReproduccion listaNueva = new ListaReproduccion(nombreLista);
                listasReproducciones.add(listaNueva);
            }
        }

        public void AgregarVideosAListaReproduccion(string nombreLista, Video video)
        {
            for (int i = 0; i < listasReproducciones.darTamanio(); i++)
            {
                if (listasReproducciones[i].NombreLista == nombreLista)
                {
                    listasReproducciones[i].Videos.add(video);
                }
            }
        }

        public void AgregarVideoAlPrincipioListaReproduccion(string nombreLista, Video video)
        {
            ArrayPropio<Video> Aux = new ArrayPropio<Video>();
            for (int i = 0; i < listasReproducciones.darTamanio(); i++)
            {
                if (listasReproducciones[i].NombreLista == nombreLista)
                {
                    for (int e = 0; e < listasReproducciones[i].Videos.darTamanio(); e++)
                    {
                        if (i == 0)
                        {
                            Aux.add(video);
                        }
                        Aux.add(listasReproducciones[i].Videos[e]);
                    }
                }
            }
        }

        public ArrayPropio<Video> BuscarVideosEnLista(string nombreLista, string palabra, int numero)
        {
            int copiaNumero = numero;
            String cadenaCortada = null;
            String cadenaRecortada = null;
            ArrayPropio<Video> listaE = new ArrayPropio<Video>(); ;
            ArrayPropio<Video> lista = null;

            for (int g = 0; g < listasReproducciones.darTamanio(); g++)
            {
                if (nombreLista == listasReproducciones[g].NombreLista)
                {
                    lista = listasReproducciones[g].Videos;
                }
            }
            if (listasReproducciones.darTamanio() != 0)
            {
                if (copiaNumero == 1)
                {
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        for (int j = 0; j < lista.darTamanio(); j++)
                        {
                            lista[j].Nombre = lista[j].Nombre.ToLower();
                            for (int k = 0; k < lista[j].Nombre.Length; k++)
                            {
                                if (palabra[i].Equals(lista[j].Nombre.ElementAt(k)))
                                {
                                    if (!listaE.Contains(lista[j]))
                                    {
                                        listaE.add(lista[j]);
                                    }
                                }
                            }
                        }
                    }
                }

                else
                {
                    for (int j = 0; j < lista.darTamanio(); j++)
                    {
                        copiaNumero = numero;
                        do
                        {
                            if (copiaNumero == lista[j].Nombre.Length)
                            {
                                cadenaCortada = lista[j].Nombre;
                            }
                            if (copiaNumero < lista[j].Nombre.Length)
                            {
                                if (copiaNumero == numero)
                                {
                                    cadenaCortada = lista[j].Nombre.Remove(copiaNumero);
                                }
                                else
                                {
                                    cadenaCortada = lista[j].Nombre.Remove(copiaNumero - (numero - 1));
                                }
                            }
                            if (copiaNumero != numero && copiaNumero <= lista[j].Nombre.Length)
                            {
                                cadenaRecortada = cadenaCortada.Remove(0, copiaNumero - (numero + 1));
                            }
                            else if (copiaNumero == numero)
                            {
                                cadenaRecortada = cadenaCortada;
                            }
                            if (palabra.Equals(cadenaRecortada))
                            {
                                if (listaE.Contains(lista[j].Nombre) == false)
                                {
                                    listaE.add(lista[j]);
                                }
                            }
                            copiaNumero += numero;

                        } while (copiaNumero < lista[j].Nombre.Length);
                    }
                    for (int j = 0; j < lista.darTamanio(); j++)
                    {
                        do
                        {
                            if (copiaNumero == lista[j].Nombre.Length)
                            {
                                cadenaCortada = lista[j].Nombre;
                            }
                            if (copiaNumero < lista[j].Nombre.Length)
                            {
                                cadenaCortada = lista[j].Nombre.Remove(copiaNumero);
                            }
                            if (copiaNumero != numero && copiaNumero <= lista[j].Nombre.Length)
                            {
                                cadenaRecortada = cadenaCortada.Remove(0, copiaNumero - 2);
                            }
                            else if (copiaNumero == numero)
                            {
                                cadenaRecortada = cadenaCortada;
                            }
                            if (palabra.Equals(cadenaRecortada))
                            {
                                if (!listaE.Contains(lista[j].Nombre))
                                {
                                    listaE.add(lista[j]);
                                }
                            }
                            copiaNumero += numero;
                        } while (copiaNumero < lista[j].Nombre.Length);
                    }


                }
            }
            return listaE;
            }
            
        public ArrayPropio<String> BuscarVideoEnListas(string palabra, int numero)
        {
            ArrayPropio<String> nombreListas = new ArrayPropio<string>();

            int copiaNumero = numero;
            String cadenaCortada = null;
            String cadenaRecortada = null;
            ArrayPropio<Video> listaE = new ArrayPropio<Video>(); ;
            ListaReproduccion lista = null;

            for (int g = 0; g < listasReproducciones.darTamanio(); g++)
            {
                    lista = listasReproducciones[g];
            
            if (listasReproducciones.darTamanio() != 0)
            {
                if (copiaNumero == 1)
                {
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        for (int j = 0; j < lista.Videos.darTamanio(); j++)
                        {
                            for (int k = 0; k < lista.Videos[j].Nombre.Length; k++)
                            {
                                if (palabra[i].Equals(lista.Videos[j].Nombre.ElementAt(k)))
                                {
                                    if (!nombreListas.Contains(lista.NombreLista))
                                    {
                                        nombreListas.add(lista.NombreLista);
                                    }

                                }
                            }
                        }
                    }
                }

                else
                {
                    for (int j = 0; j < lista.Videos.darTamanio(); j++)
                    {
                        copiaNumero = numero;
                        do
                        {
                            if (copiaNumero == lista.Videos[j].Nombre.Length)
                            {
                                cadenaCortada = lista.Videos[j].Nombre;
                            }
                            if (copiaNumero < lista.Videos[j].Nombre.Length)
                            {
                                cadenaCortada = lista.Videos[j].Nombre.Remove(copiaNumero);
                            }
                            if (copiaNumero != numero && copiaNumero <= lista.Videos[j].Nombre.Length)
                            {
                                cadenaRecortada = cadenaCortada.Remove(0, copiaNumero - 2);
                            }
                            else if (copiaNumero == numero)
                            {
                                cadenaRecortada = cadenaCortada;
                            }
                            if (palabra.Equals(cadenaRecortada))
                            {
                                if (!nombreListas.Contains(lista.NombreLista))
                                {
                                    nombreListas.add(lista.NombreLista);
                                }
                            }
                            copiaNumero += numero;
                        } while (copiaNumero < lista.Videos[j].Nombre.Length);
                    }
                }
            }

            }           
                return nombreListas;
        }

        public void QuitarListaReproduccion(String nombreLista)
        {
            for (int i = 0; i < listasReproducciones.darTamanio(); i++)
            {
                if (listasReproducciones[i].NombreLista == nombreLista)
                {
                    listasReproducciones.remove(i);
                } 
            }
        }

        public void QuitarVideoLista(String nombreLista, Video video)
        {
            for(int i = 0; i < listasReproducciones.darTamanio(); i++)
            {
                if (listasReproducciones[i].NombreLista == nombreLista)
                {
                    for (int j = 0; j < listasReproducciones[i].Videos.darTamanio(); j++)
                    {
                        if (listasReproducciones[i].Videos[j].Nombre == video.Nombre)
                        {
                            listasReproducciones[i].Videos.remove(j);
                        }
                    }
                }
            }
        }

        public void EliminarEtiquetaDeVideo(String nombreLista, String nombreEtiqueta, Video video)
        {
            for (int i = 0; i < listasReproducciones.darTamanio(); i++)
            {
                if(listasReproducciones[i].NombreLista == nombreLista)
                {
                    for (int a = 0; a < listasReproducciones[i].Videos.darTamanio(); a++)
                    {
                        if (listasReproducciones[i].Videos[a] == video)
                        {
                            for (int j = 0; j < listasReproducciones[i].Videos[a].Etiqueta.darTamanio(); j++)
                            {
                                if (listasReproducciones[i].Videos[a].Etiqueta[j].Equals(nombreEtiqueta))
                                {
                                    listasReproducciones[i].Videos[a].Etiqueta.remove(j);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GuardarListas()
        {
            Persistencia per = new Persistencia(this);
            per.GuardarListasReproducciones(ListasReproducciones);
            per.GuardarListaEtiquetas(ListaEtiquetas);
        }

        public void CargarListas()
        {
            Persistencia per = new Persistencia(this);
            per.CargarListasReproducciones();
            per.CargarListaEtiquetas();
        }

        public ArrayPropio<ListaReproduccion> ListasReproducciones
        {
            get { return listasReproducciones; }
            set { listasReproducciones = value; }
        }

        public ArrayPropio<String> ListaEtiquetas
        {
            get { return listaEtiquetas; }
            set { listaEtiquetas = value; }
        }
    }
}
