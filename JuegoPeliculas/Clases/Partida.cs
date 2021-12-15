using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Partida : ObservableObject
{
    private int _puntuacion;
    private bool _partidaGanada;
    private bool _partidaIniciada;
    private string _textoAValidar;
    public Partida()
    {
    }

    public Partida(int puntuacion, bool partidaGanada, bool partidaIniciada, string textoAValidar)
    {
        Puntuacion = puntuacion;
        PartidaGanada = partidaGanada;
        PartidaIniciada = partidaIniciada;
        TextoAValidar = textoAValidar;
    }

    public string TextoAValidar
    {
        get { return _textoAValidar; }
        set { SetProperty(ref _textoAValidar, value); }
    }
    public int Puntuacion
    {
        get { return _puntuacion; }
        set { SetProperty(ref _puntuacion, value); }
    }

    public bool PartidaGanada
    {
        get { return _partidaGanada; }
        set { SetProperty(ref _partidaGanada, value); }
    }

    public bool PartidaIniciada
    {
        get { return _partidaIniciada; }
        set { SetProperty(ref _partidaIniciada, value); }
    }
}

