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
    /// Lógica de interacción para WpfContratoCliente.xaml
    /// </summary>
    public partial class WpfContratoCliente : MetroWindow
    {

        Contrato co = new Contrato();
        public WpfContratoCliente()
        {
            InitializeComponent();
            txtFechaCreacion.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtNum.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            cboPlan.ItemsSource = Enum.GetValues(typeof(TipoPlan));
            cboPlan.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato c = new Contrato();
                c.Numero = txtNum.Text;
                c.FechaCreacionContrato = DateTime.Now.Date;
                c.Cliente = new ClientesCollection().BuscarPorRut(txtRut.Text);
                c.Plan = (Plan)cboPlan.SelectedItem;
                c.FechaIniVigencia = (DateTime)dtgFechaInicioVigencia.SelectedDate;
                c.FechaFinVigencia = c.FechaIniVigencia.AddYears(1);
                c.Vigente = true;
                c.DeclaracionSalud = rbtSi.IsChecked == true ? true : false;
                c.PrimaAnual = float.Parse(txtPrimaAnual.Text);
                c.PrimaMensual = float.Parse(txtPrimaMensual.Text);
                ContratoCollection con = new ContratoCollection();
                bool resp = con.Agregar(c);
                MessageBox.Show(resp ? "Grabo" : "No Grabo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
