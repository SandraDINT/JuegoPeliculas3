using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Partida
{
    private int _puntuacion;
    private bool _partidaGanada;
    private bool _partidaIniciada;

    public Partida(int puntuacion, bool partidaGanada, bool partidaIniciada)
    {
        this._puntuacion = 0;
        this._partidaGanada = false;
        this._partidaIniciada = false;
    }


}

