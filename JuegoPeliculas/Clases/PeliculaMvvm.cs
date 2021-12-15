using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class PeliculaMVVM : ObservableObject
{
    /*Me he quedado a medias de usar el azureService*/


    private ListaPeliculasService servicioPeliculas;
    private AzureService azureService;
    private List<String> _nivelesDificultad;
    private Pelicula _peliculaFormulario;

    public PeliculaMVVM()
    {
        servicioPeliculas = new ListaPeliculasService();
        ContadorPeliculaActual = 1;
        _nivelesDificultad = new List<String> {"Fácil", "Normal", "Difícil" };
        _generos = new List<String> { "Comedia", "Drama", "Acción", "Terror", "Ciencia-Ficción" };
        PeliculaFormulario = null;
        azureService = new AzureService();
    }

    private bool _datosCargados;
    public bool DatosCargados
    {
        get { return _datosCargados; }
        set { SetProperty(ref _datosCargados, value); }
    }

    private bool _editandoPelicula;
    public bool EditandoPelicula
    {
        get { return _editandoPelicula; }
        set { SetProperty(ref _editandoPelicula, value); }
    }
    public Pelicula PeliculaFormulario
    {
        get { return _peliculaFormulario; }
        set { SetProperty(ref _peliculaFormulario, value); }
    }

    private List<String> _generos;
    public List<String> Generos
    {
        get { return _generos; }
        set { SetProperty(ref _generos, value); }
    }
    public List<String> Dificultades 
    { 
        get { return _nivelesDificultad; }
        set {SetProperty(ref _nivelesDificultad, value); } 
    }

    private ObservableCollection<Pelicula> _listaPeliculas;
    public ObservableCollection<Pelicula> Peliculas {
        get { return _listaPeliculas; }
        set { SetProperty(ref _listaPeliculas, value); } 
    }

    private Pelicula _peliculaActual;
    public Pelicula PeliculaActual
    {
        get { return _peliculaActual; }
        set
        {
            SetProperty(ref _peliculaActual, value);
        }
    }

    private int _contadorPeliculaActual;
    public int ContadorPeliculaActual
    {
        get { return _contadorPeliculaActual; }
        set { SetProperty(ref _contadorPeliculaActual, value); }
    }

    private int _totalPeliculas;
    public int TotalPeliculas
    {
        get { return _totalPeliculas; }
        set { SetProperty(ref _totalPeliculas, value); }
    }

    //Métodos
    public void Avanzar()
    {
        if (ContadorPeliculaActual < TotalPeliculas)
        {
            ContadorPeliculaActual++;
            PeliculaActual = _listaPeliculas[ContadorPeliculaActual - 1];
        }

    }
    public void Retroceder()
    {
        if (ContadorPeliculaActual > 1)
        {
            ContadorPeliculaActual--;
            PeliculaActual = _listaPeliculas[ContadorPeliculaActual - 1];
        }
    }

    public void FinalizarPartida()
    {
        DatosCargados = false;
        PeliculaActual = null;
        Peliculas = null;
    }

    public void CargarDatos()
    {
        Peliculas = servicioPeliculas.GetPeliculas();
        PeliculaActual = Peliculas[0];
        TotalPeliculas = _listaPeliculas.Count;
        DatosCargados = true;
    }
    public void ExportarDatos()
    {
        string personasJson = JsonConvert.SerializeObject(Peliculas);
        string ruta = "";
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        if (saveFileDialog.ShowDialog() == true)
            ruta = saveFileDialog.FileName;

        File.WriteAllText(ruta, personasJson);
    }

    public void AddPelicula()
    {
        Pelicula pelicula = new Pelicula();
        PeliculaActual = PeliculaFormulario;
        EditandoPelicula = true;
        if(PeliculaFormulario != null)
        {
            pelicula =
            new Pelicula(PeliculaFormulario.Titulo, PeliculaFormulario.Pista, PeliculaFormulario.Cartel, PeliculaFormulario.Nivel, PeliculaFormulario.Genero);
            Peliculas.Add(pelicula);
        }
             
        
    }
    public void EditarPelicula()
    {
        EditandoPelicula = true;
    }
    public void EliminarPelicula()
    {
        Peliculas.Remove(PeliculaActual);
    }
    public string SubirImagenAzure(string url)
    {
        string cartel = azureService.SubirImagen(url);
        return cartel;
    }
    public void NuevaPartida()
    {
        if(Peliculas.Count > 0)
        {
            DatosCargados = true;
        }
    }

}

