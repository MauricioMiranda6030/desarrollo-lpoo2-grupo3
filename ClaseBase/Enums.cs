using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    class Enums
    {
        enum State
        {
            programado,
            postergado,
            reprogramado,
            cancelado
        }

        enum Athletics
        {
            CarreraDeVelocidad,
            CarreraDeMedioFondo,
            CarreradeFondo,
            CarreraDeValla,
            Marcha
        }

        enum Swimming
        {
            Libre50m,
            Libre100m,
            Espalda100m,
            Espalda200m
        }

        enum Event
        {
            Inscripto,
            Acreditado,
            Anulado,
            Abandono,
            Descalificado
        }
    }
}
