using Microsoft.Toolkit.Mvvm.ComponentModel;

class Pelicula : ObservableObject
{
    private string titulo;
    public string Titulo
    {
        get { return titulo; }
        set { SetProperty(ref titulo, value); }
    }

    private string pista;
    public string Pista
    {
        get { return pista; }
        set { SetProperty(ref pista, value); }
    }

    private string cartel;
    public string Cartel
    {
        get { return cartel; }
        set { SetProperty(ref cartel, value); }
    }

    private string nivel;
    public string Nivel
    {
        get { return nivel; }
        set { SetProperty(ref nivel, value); }
    }

    private string genero;

    public Pelicula(string titulo, string pista, string cartel, string nivel, string genero)
    {
        Titulo = titulo;
        Pista = pista;
        Cartel = cartel;
        Nivel = nivel;
        Genero = genero;
    }
    public Pelicula()
    {
    }

    public string Genero
    {
        get { return genero; }
        set { SetProperty(ref genero, value); }
    }
}

