using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ListaPeliculasService
{
    public ObservableCollection<Pelicula> GetPeliculas()
    {
        string ruta = "";
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {

            ruta = openFileDialog.FileName;
        }

        ObservableCollection<Pelicula> peliculas = new ObservableCollection<Pelicula>();
        string peliculasJson = File.ReadAllText(ruta);
        peliculas = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
        return peliculas;
    }
}

