using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace ReproductorVideo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IMainWindow
    {
        PresentadorMainWindow presenter;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new PresentadorMainWindow(this);
            BloquearBotones();
            presenter.CargarListas();
            CargarNombresListaReproduccion();
            ActualizarListaEtiquetas();
        }

        public void BloquearBotones()
        {
            BtnAgregarVideo.IsEnabled = false;
            BtnAgregarVideoAlPrincipio.IsEnabled = false;
        }

        public void InicializarLista()
        {
            
        }

        public String BuscarVideoEnListas
        {
            get { return TxtBucarVideoEnListas.Text; }
            set { TxtBucarVideoEnListas.Text = value; }
        }

        public String BuscarVideoEnUnicaLista
        {
            get { return TxtBuscarVideoUnicaLista.Text; }
            set { TxtBuscarVideoUnicaLista.Text = value; }
        }

        public String NombreEtiqueta
        {
            get { return TxtAgregarEtiqueta.Text; }
            set { TxtAgregarEtiqueta.Text = value; }
        }

        public Object NombreEtiquetaVideo
        {
            get { return LstEtiquetasVideo.SelectedItem; }
        }

        public Object ListaEtiquetasBuscar
        {
            get { return LstBuscarEtiquetas.SelectedItem; }
        }

        public Object ListaEtiquetas
        {
            get { return LstEtiquetas.SelectedItem; }
        }

        public String Nombre
        {
            set { TxtNombre.Text = value; }
        }

        public String Tamaño
        {
            set { txtTamaño.Text = value; }
        }

        public String Ruta
        {
            set { TxtRuta.Text = value; }
        }

        public String Posicion
        {
            set { TxtPosicion.Text = value; }
        }

        public String NombresVideoEncontradoEnListas
        {
            get { return CboxNombresVideosEncontradoListas.SelectedItem.ToString(); }
        }

        public String NombreListaReproduccion
        {
            get { return CboxNombresListasReproduccion.SelectedItem.ToString(); }
        }

        public Object ListaVideos
        {
            get { return LstVideos.SelectedItem; }
        }

        private void BtnAgregarVideo_Click(object sender, RoutedEventArgs e)
        {
            Boolean estaReproducionedo = IsPlaying();
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                ArrayPropio<String> listaEtiquetas = new ArrayPropio<string>();
                String etiqueta = "";
                if (LstEtiquetas.SelectedItems != null)
                {
                    for (int i = 0; i < LstEtiquetas.SelectedItems.Count; i++)
                    {
                        etiqueta = LstEtiquetas.SelectedItems[i] as String;
                        listaEtiquetas.add(etiqueta);
                    }
                }
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "MP4 Files (*.mp4)|*.mp4|AVI Files (*.avi)|*.avi|MPEG-4 Files (*.MPEG)|*.MPEG|WMV Files (*.WMV)|*.WMV"
                    + "|All Files (*.*)|*.*";
                open.ShowDialog();
                presenter.AgregarVideoALista(open.FileName, LstVideos.SelectedIndex, listaEtiquetas,estaReproducionedo);
                CargarOActualizarLista();
                LstEtiquetasVideo.UnselectAll();
            }
        }

        private void BtnBorrarVideo_Click(object sender, RoutedEventArgs e)
        {
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                presenter.QuitarVideo();
                CargarOActualizarLista();
            }
        }

        private void BtnAgregarVideoAlPrincipio_Click(object sender, RoutedEventArgs e)
        {
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                ArrayPropio<String> listaEtiquetas = new ArrayPropio<string>();
                String etiqueta = "";
                if (LstEtiquetas.SelectedItems != null)
                {
                    for (int i = 0; i < LstEtiquetas.SelectedItems.Count; i++)
                    {
                        etiqueta = LstEtiquetas.SelectedItems[i] as String;
                        listaEtiquetas.add(etiqueta);
                    }
                }
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "MP4 Files (*.mp4)|*.mp4|AVI Files (*.avi)|*.avi|MPEG-4 Files (*.MPEG)|*.MPEG|WMV Files (*.WMV)|*.WMV"
                    + "|All Files (*.*)|*.*";
                open.ShowDialog();
                presenter.AgregarVideoAlPrincipioDeLista(open.FileName, listaEtiquetas);
                CargarOActualizarLista();
                LstEtiquetasVideo.UnselectAll();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VentanaListas VListas = new VentanaListas(this);
            VListas.Show();
        }

        private void CboxListasReproduccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CboxNombresListasReproduccion.Items.Count != 0)
            {
                CargarOActualizarLista();
            }
            if (BtnAgregarVideo.IsEnabled == false && BtnAgregarVideoAlPrincipio.IsEnabled == false )
            {
                BtnAgregarVideoAlPrincipio.IsEnabled = true;
                BtnAgregarVideo.IsEnabled = true;
            }
        }

        public void CargarOActualizarLista()
        {
            int v =0;
            LstVideos.Items.Clear();
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                for (int i = 0; i < presenter.ActualizarLista().darTamanio(); i++)
                {
                    if (presenter.ActualizarLista()[i].Posicion == v)
                    {
                        LstVideos.Items.Add(presenter.ActualizarLista()[i]);
                        v++;
                        i = -1;
                    }
                }
            }
        }

        public void CargarNombresListaReproduccion()
        {
            CboxNombresListasReproduccion.Items.Clear();
            if (presenter.CargarListaNombresListasReproduccion().darTamanio() != 0)
            {
                for (int i = 0; i < presenter.CargarListaNombresListasReproduccion().darTamanio(); i++)
                {
                    CboxNombresListasReproduccion.Items.Add(presenter.CargarListaNombresListasReproduccion()[i]);
                }
            }
        }

        private void TxtBuscarVideoUnicaLista_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                if (TxtBuscarVideoUnicaLista.Text.Length == 0)
                {
                    CargarOActualizarLista();
                }
                if (TxtBuscarVideoUnicaLista.Text.Length != 0)
                {
                    LstVideos.Items.Clear();
                    for (int i = 0; i < presenter.BuscarVideoEnLista().darTamanio(); i++)
                    {
                        LstVideos.Items.Add(presenter.BuscarVideoEnLista()[i]);
                    }
                }
            }
        }

        public void BuscarVideoEnMultiplesListas()
        {
                if (TxtBucarVideoEnListas.Text.Length != 0)
                {
                    if (CboxNombresVideosEncontradoListas.SelectedIndex == -1)
                    {
                        CboxNombresVideosEncontradoListas.Items.Clear();
                        for (int i = 0; i < presenter.ListasDondeApareceVideo().darTamanio(); i++)
                        {
                            CboxNombresVideosEncontradoListas.Items.Add(presenter.ListasDondeApareceVideo()[i]);
                        }
                    }

                    if (CboxNombresVideosEncontradoListas.SelectedItem != null)
                    {
                        LstVideos.Items.Clear();
                        for (int i = 0; i < presenter.BuscarVideoPorMedioDeListasEncontradas().darTamanio(); i++)
                        {
                            LstVideos.Items.Add(presenter.BuscarVideoPorMedioDeListasEncontradas()[i]);
                        }
                    }
                }
                else { CargarOActualizarLista(); CboxNombresVideosEncontradoListas.Items.Clear(); }
        }

        private void TxtBucarVideoEnListas_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarVideoEnMultiplesListas();
        }

        private void LstBuscarEtiquetas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstBuscarEtiquetas.SelectedIndex != -1)
            {
                LstVideos.Items.Clear();
                for (int i = 0; i < presenter.BuscarVideoPorEtiqueta().darTamanio(); i++)
                {
                    LstVideos.Items.Add(presenter.BuscarVideoPorEtiqueta()[i]);
                }
            }
            else { CargarOActualizarLista(); }
        }

        public void ActualizarListaEtiquetas()
        {
            LstEtiquetas.Items.Clear();
            LstBuscarEtiquetas.Items.Clear();
            if (presenter.ActualizarListaEtiquetas().darTamanio() != 0)
            {
                for (int i = 0; i < presenter.ActualizarListaEtiquetas().darTamanio(); i++)
                {
                    LstEtiquetas.Items.Add(presenter.ActualizarListaEtiquetas()[i]);
                    LstBuscarEtiquetas.Items.Add(presenter.ActualizarListaEtiquetas()[i]);
                }
            }
        }

        private void BtnAgregarEtiqueta_Click(object sender, RoutedEventArgs e)
        {
            if(TxtAgregarEtiqueta.Text !="")
            presenter.AgregarEtiquetas();
            ActualizarListaEtiquetas();
        }

        private void LstVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstVideos.SelectedItem != null)
            {
                presenter.MostrarContenido();
                LstEtiquetasVideo.Items.Clear();
                for (int i = 0; i < presenter.MostrarEtiquetasVideo().darTamanio(); i++)
                {
                    LstEtiquetasVideo.Items.Add(presenter.MostrarEtiquetasVideo()[i]);
                }
            }
        }



        public bool IsPlaying()
        {
            var pos1 = MediaV.Position;
            System.Threading.Thread.Sleep(30);
            var pos2 = MediaV.Position;
            return (pos2 - pos1).TotalMilliseconds > 20;
        }

        public int ReproducirPorPos()
        {
            int numero = LstVideos.SelectedIndex;
            if (numero++ > LstVideos.SelectedItems.Count)
            {
                numero++;
            }
            return numero++;
        }

        public void Reproducir()
        {
            if (LstVideos.SelectedIndex != -1)
            {
                Video video = LstVideos.SelectedItem as Video;
                Uri uri = new Uri(video.Ruta, UriKind.Absolute);
                if (MediaV.Source == null)
                {
                    MediaV.Source = uri;
                    MediaV.Play();
                    BtnPlay.Content = "Pause";
                }
                else
                {
                    if (MediaV.Source.LocalPath.ToString().Equals(video.Ruta))
                    {
                        if (IsPlaying() == false)
                        {
                            MediaV.Play();
                            BtnPlay.Content = "Pause";
                        }
                        else
                        {
                            MediaV.Pause();
                            BtnPlay.Content = "Play";
                        }
                    }
                    else
                    {
                        MediaV.Source = uri;
                        MediaV.Play();
                    }
                }
            }

            else
            {
                Video video = null;
                Uri uri = null;
                try
                {
                    if (LstVideos.Items.Count != 0)
                    {

                        if (IsPlaying() != true)
                        {
                            video = LstVideos.Items[ReproducirPorPos()] as Video;
                            uri = new Uri(video.Ruta, UriKind.Absolute);
                        }

                        else
                        {
                            if (MediaV.Source.LocalPath.ToString().Equals(video.Ruta))
                            {
                                if (IsPlaying() == false)
                                {
                                    MediaV.Play();
                                    BtnPlay.Content = "Pause";
                                }
                                else { MediaV.Pause(); BtnPlay.Content = "Play"; }
                            }
                        }
                    }
                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Reproducir();
        }

        private void MediaV_MediaEnded(object sender, RoutedEventArgs e)
        {
            Reproducir();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            MediaV.Stop();
            BtnPlay.Content = "Play";
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            
                Video video = null;
                if ((LstVideos.SelectedIndex - 1) < 0)
                {
                    if (LstVideos.Items.Count != 0)
                    {
                        video = LstVideos.Items[(LstVideos.Items.Count - 1)] as Video;
                        LstVideos.SelectedIndex = LstVideos.Items.Count - 1;
                    }
                }
                else
                {
                    video = LstVideos.Items[LstVideos.SelectedIndex -1] as Video;
                    LstVideos.SelectedIndex = LstVideos.SelectedIndex - 1;
                }
                if (LstVideos.Items.Count != 0)
                {
                    Uri uri = new Uri(video.Ruta, UriKind.Absolute);
                    MediaV.Source = uri;
                    MediaV.Play();
                    BtnPlay.Content = "Pause";
                }
        }

        private void BtnAdelante_Click(object sender, RoutedEventArgs e)
        {
            if (LstVideos.SelectedIndex == -1)
            {
                if (LstVideos.Items.Count != 0)
                {
                    Video video = LstVideos.Items[0] as Video;
                    LstVideos.SelectedIndex = 0;
                    Uri uri = new Uri(video.Ruta, UriKind.Absolute);
                    MediaV.Source = uri;
                    MediaV.Play();
                    BtnPlay.Content = "Pause";
                }
            }
            else
            {
                Video video = null;
                if ((LstVideos.SelectedIndex + 1) > LstVideos.Items.Count - 1)
                {
                    video = LstVideos.Items[0] as Video;
                    LstVideos.SelectedIndex = 0;
                }
                else
                {
                    video = LstVideos.Items[LstVideos.SelectedIndex + 1] as Video;
                    LstVideos.SelectedIndex = LstVideos.SelectedIndex + 1;
                }
                Uri uri = new Uri(video.Ruta, UriKind.Absolute);
                MediaV.Source = uri;
                MediaV.Play();
                BtnPlay.Content = "Pause";
            }
        }

        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaV.Volume = e.NewValue;
        }

        private void CerrarYguardar(object sender, System.ComponentModel.CancelEventArgs e)
        {
            presenter.GuardarListas();
        }

        private void LstVideos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LstVideos.UnselectAll();
        }

        private void MenuItemDeleteLstVideos_Click(object sender, RoutedEventArgs e)
        {
            if (LstVideos.SelectedIndex == -1)
            {
                return;
            }
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                presenter.QuitarVideo();
                CargarOActualizarLista();
            }
        }

        private void LstEtiquetas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LstEtiquetas.UnselectAll();
        }

        private void MenuItemDeleteLstEtiquetas_Click(object sender, RoutedEventArgs e)
        {
            if (LstEtiquetas.SelectedIndex == -1)
            {
                return;
            }
            if (LstEtiquetas.SelectedItem != null)
            {
                presenter.QuitarEtiqueta();
                ActualizarListaEtiquetas();
            }
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            LstBuscarEtiquetas.UnselectAll();
        }

        private void BtnArriba_Click(object sender, RoutedEventArgs e)
        {
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                presenter.SubirVideoPosicion(LstVideos.SelectedIndex);
                CargarOActualizarLista();
            }
        }

        private void BtnAbajo_Click(object sender, RoutedEventArgs e)
        {
            if (CboxNombresListasReproduccion.SelectedItem != null)
            {
                presenter.BajarVideoPosicion(LstVideos.SelectedIndex);
                CargarOActualizarLista();
            }
        }

        private void CboxNombresVideosEncontradoListas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuscarVideoEnMultiplesListas();
        }

        private void LstEtiquetasVideo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LstEtiquetasVideo.UnselectAll();
        }

        private void MenuItemDeleteLstEtiquetasVideos_Click(object sender, RoutedEventArgs e)
        {
            if (LstEtiquetasVideo.SelectedIndex == -1)
            {
                return;
            }
            if (LstEtiquetasVideo.SelectedItem != null && LstVideos.SelectedItem !=null)
            {
                presenter.EliminarEtiquetaDeUnVideo();
                LstEtiquetasVideo.Items.Clear();
                for (int i = 0; i < presenter.MostrarEtiquetasVideo().darTamanio(); i++)
                {
                    LstEtiquetasVideo.Items.Add(presenter.MostrarEtiquetasVideo()[i]);
                }
            }
        }

    }
}
