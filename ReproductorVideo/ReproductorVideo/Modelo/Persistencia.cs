using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ReproductorVideo
{
    class Persistencia
    {
        ReproductorVideos reproductor;

        public Persistencia(ReproductorVideos reproductor)
        {
            this.reproductor = reproductor;
        }

        public void GuardarListasReproducciones(ArrayPropio<ListaReproduccion> listaR)
        {
            try
            {
                FileStream stream = new FileStream(@"..\..\listas\listaReproduccion", FileMode.Create);
                BinaryFormatter formateador = new BinaryFormatter();
                formateador.Serialize(stream, listaR);
                stream.Close();
            }
            catch (Exception c)
            {
                Console.Write(c.Message);
                Console.WriteLine();
            }
        }

        public void GuardarListaEtiquetas(ArrayPropio<String> listaE)
        {
            try
            {
                FileStream stream = new FileStream(@"..\..\listas\listaEtiquetas", FileMode.Create);
                BinaryFormatter formateador = new BinaryFormatter();
                formateador.Serialize(stream, listaE);
                stream.Close();
            }
            catch (Exception c)
            {
                Console.Write(c.Message);
                Console.WriteLine();
            }
        }
        [OnDeserialized]
        public void CargarListasReproducciones()
        {
            ArrayPropio<ListaReproduccion> listaR = null;
            try
            {
                FileStream stream = new FileStream(@"..\..\listas\listaReproduccion", FileMode.Open);
                BinaryFormatter formateador = new BinaryFormatter();
                listaR = formateador.Deserialize(stream) as ArrayPropio<ListaReproduccion>;
                reproductor.ListasReproducciones = listaR;
                stream.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Console.WriteLine();
            }
        }
        [OnDeserialized]
        public void CargarListaEtiquetas()
        {
            ArrayPropio<String> listaE = null;
            try
            {
                FileStream stream = new FileStream(@"..\..\listas\listaEtiquetas", FileMode.Open);
                BinaryFormatter formateador = new BinaryFormatter();
                listaE = formateador.Deserialize(stream) as ArrayPropio<String>;
                reproductor.ListaEtiquetas = listaE;
                stream.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Console.WriteLine();
            }
        }
    }
}
