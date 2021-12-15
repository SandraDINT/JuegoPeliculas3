using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeliculaMVVM vm = new PeliculaMVVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            vm.Avanzar();

        }

        private void imageAtras_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            vm.Retroceder();
        }

        private void buttonCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            vm.CargarDatos();
        }

        private void buttonGuardarDatos_Click(object sender, RoutedEventArgs e)
        {
            vm.ExportarDatos();
        }

        private void buttonExaminar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                textBoxImagen.Text = openFileDialog.FileName;
            }
            vm.SubirImagenAzure(textBoxImagen.Text);
        }

        private void buttonNuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            vm.NuevaPartida();
        }

        private void checkBoxPista_Checked(object sender, RoutedEventArgs e)
        {
            textBlockPista.Visibility = Visibility.Visible;
        }

        private void checkBoxPista_Unchecked(object sender, RoutedEventArgs e)
        {
            textBlockPista.Visibility = Visibility.Collapsed;
        }

        private void buttonValidar_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxTituloPelicula.Text == vm.PeliculaActual.Titulo)
            {
                MessageBox.Show("¡Has acertado!");
            }
        }

        private void buttonAddPelicula_Click(object sender, RoutedEventArgs e)
        {
            vm.AddPelicula();
        }

        private void buttonEliminarPelicula_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarPelicula();
            MessageBox.Show("Película eliminada");
        }

        private void buttonEditarPelicula_Click(object sender, RoutedEventArgs e)
        {
            vm.EditarPelicula();
        }

        private void buttonFinalizar_Click(object sender, RoutedEventArgs e)
        {
            vm.FinalizarPartida();
        }
    }
}
