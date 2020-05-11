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
using BibliotecaClases;
using Controlador;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para WPFListar.xaml
    /// </summary>
    public partial class WPFListar : MetroWindow
    {
        ClientesCollection cole = new ClientesCollection();

        Object objeto;

        public WPFListar(Object ventana_origen)
        {
            InitializeComponent();
            objeto = ventana_origen;
            dtgListar.ItemsSource = cole.Listar();
            dtgListar.Items.Refresh();
            cboSexoFiltro.ItemsSource = Enum.GetValues(typeof(TipoSexo));
            cboSexoFiltro.Items.Refresh();
            cboEstCivilFiltro.ItemsSource = Enum.GetValues(typeof(TipoEstadoCivil));
            cboEstCivilFiltro.Items.Refresh();
            if (objeto.GetType() == typeof(WPFAgregarCliente)) 
            {
                lblVentana.Content = "Es una instancia de Cliente";
            }
            if (objeto.GetType() == typeof(MainWindow)) 
            {
                lblVentana.Content = "Es una instancia de Menu";
                btnTraspaso.Visibility = Visibility.Hidden;
            }
        }
        public WPFListar()
        {
            
            InitializeComponent();
            dtgListar.ItemsSource = cole.Listar();
            dtgListar.Items.Refresh();
            cboSexoFiltro.ItemsSource = Enum.GetValues(typeof(TipoSexo));
            cboSexoFiltro.Items.Refresh();
            cboEstCivilFiltro.ItemsSource = Enum.GetValues(typeof(TipoEstadoCivil));
            cboEstCivilFiltro.Items.Refresh();
        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtRutFiltro.Text.Trim().Length == 0)
            {
                dtgListar.ItemsSource = cole.Listar();
                dtgListar.Items.Refresh();
            }      
            else
            {
                dtgListar.ItemsSource = cole.Listar()
                .Where(c => c.Rut.Equals(txtRutFiltro.Text)).ToList();
            }
        }

        private void BtnTraspaso_Click(object sender, RoutedEventArgs e)
        {
            if (objeto.GetType()==typeof(WPFAgregarCliente))
            {
                Cliente c = (Cliente)dtgListar.SelectedItem;
                ((WPFAgregarCliente)objeto).Llenar(c);
                
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
