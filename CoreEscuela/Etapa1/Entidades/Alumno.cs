using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string Nombre { set; get; }
        public string UniqueId { private set; get; }

        public List<Evaluacion> Evaluaciones { set; get; }

        public Alumno() => UniqueId = Guid.NewGuid().ToString();
    }
}