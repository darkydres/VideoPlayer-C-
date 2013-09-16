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
using System.Windows.Shapes;

namespace ReproductorVideo
{
    /// <summary>
    /// Lógica de interacción para VentanaListas.xaml
    /// </summary>
    public partial class VentanaListas : Window, IVentanaListas
    {
        PresentadorVentanaListas presenter;
        MainWindow main;
        public VentanaListas(MainWindow main)
        {
            InitializeComponent();
            presenter = new PresentadorVentanaListas(this);
            this.main = main;
            CargarActualizarListaListasReproducciones();
        }

        public String NombreLista
        {
            get { return TxtNombreLista.Text; }
            set { TxtNombreLista.Text = value; }
        }

        public Object ListaListasReproduccion
        {
            get { return LstListasRExistentes.SelectedItem; }
        }


        public void CargarActualizarListaListasReproducciones()
        {
            LstListasRExistentes.Items.Clear();
            for (int i = 0; i < presenter.listasDeReproducciones().darTamanio(); i++)
            {
                LstListasRExistentes.Items.Add(presenter.listasDeReproducciones()[i]);
            }
            
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            presenter.CrearListaReproduccion();
            CargarActualizarListaListasReproducciones();
            main.CargarNombresListaReproduccion();
        }

        private void BtnBorrarLista_Click(object sender, RoutedEventArgs e)
        {
            presenter.EliminarListaReproduccion();
            CargarActualizarListaListasReproducciones();
            main.CargarNombresListaReproduccion();
        }

        
    }
}
