using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno : EscuelaBase
    {
        public List<Evaluacion> Evaluaciones { set; get; }
    }
}