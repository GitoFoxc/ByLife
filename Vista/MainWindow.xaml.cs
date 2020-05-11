﻿using System;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WPFAgregarCliente agregar = new WPFAgregarCliente();
            agregar.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WPFListar lista = new WPFListar(this);
            lista.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WpfContratoCliente contrato = new WpfContratoCliente();
            contrato.Show();
        }
    }
}
