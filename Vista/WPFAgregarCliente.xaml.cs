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
    /// Lógica de interacción para WPFAgregarCliente.xaml
    /// </summary>
    public partial class WPFAgregarCliente : MetroWindow
    {
        ClientesCollection cole = new ClientesCollection();
        
        public WPFAgregarCliente()
        {
            InitializeComponent();
            cboSexo.ItemsSource =
                Enum.GetValues(typeof(TipoSexo));
            cboSexo.Items.Refresh();
            cboEstadoCivil.ItemsSource =
                Enum.GetValues(typeof(TipoEstadoCivil));
            cboEstadoCivil.Items.Refresh();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Cliente c = new Cliente();
                c.Rut = txtRut.Text;
                c.Nombre = txtNombre.Text;
                c.Apellido = txtApellido.Text;
                c.FechaCreacion = (DateTime)dtpFechaNac.SelectedDate;
                c.Sexo = (TipoSexo)cboSexo.SelectedItem;
                c.EstadoCivil = (TipoEstadoCivil)cboEstadoCivil.SelectedItem;
                bool x = new ClientesCollection().Agregar(c);
                await this.ShowMessageAsync("Clientes", x ? "Grabo" : "No Grabo");
                Limpiar();
                txtRut.Focus();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", ex.Message);
                throw;
            }
        }

        

        private void Limpiar()
        {
            txtRut.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cboSexo.SelectedIndex=-1;
            cboEstadoCivil.SelectedIndex=-1;
            dtpFechaNac.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cliente c =  cole.BuscarPorRut(txtRut.Text);
            if (c != null)
            {
                Llenar(c);
                
            }
            else
            {
                await this.ShowMessageAsync("Error", "No Existe Rut.");
                Limpiar();
                txtRut.Focus();
            }
        }

        public void Llenar(Cliente c)
        {
            txtRut.Text = c.Rut;
            txtNombre.Text = c.Nombre;
            txtApellido.Text = c.Apellido;
            dtpFechaNac.Text = c.FechaCreacion.ToString("dd/MM/yyyy");
            cboSexo.Text = c.Sexo.ToString();
            cboEstadoCivil.Text = c.EstadoCivil.ToString();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show("¿Desea Actualizarlo?",
                                                        "Actualizar Registro.",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Rut = txtRut.Text;
                    c.Nombre = txtNombre.Text;
                    c.Apellido = txtApellido.Text;
                    c.Sexo = (TipoSexo)cboSexo.SelectedItem;
                    c.EstadoCivil = (TipoEstadoCivil)cboEstadoCivil.SelectedItem;
                    bool resp = cole.ActualizarCliente(c);
                    await this.ShowMessageAsync("Actualizar", resp ? "Actualizo Registro" : "No Actualizo");
                    Limpiar();
                    txtRut.Focus();
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync("Actualizar", "No Actualizo");
                    throw;
                }
            }
                
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show("¿Desea Eliminarlo?", 
            "Eliminar Registro.", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);
            
            if (respuesta == MessageBoxResult.Yes)
            {
                bool resp = cole.Eliminar(txtRut.Text);
                if (resp)
                {
                    await this.ShowMessageAsync("Eliminar", "Elimino");
                    Limpiar();
                    txtRut.Focus();
                }
                else
                {
                    await this.ShowMessageAsync("Eliminar", "Rut no Encontrado");
                    txtRut.Focus();
                    
                }
            }
            
        }

        private void ___Click(object sender, RoutedEventArgs e)
        {
            WPFListar lista = new WPFListar(this);
            lista.Show();
        }
    }
}
