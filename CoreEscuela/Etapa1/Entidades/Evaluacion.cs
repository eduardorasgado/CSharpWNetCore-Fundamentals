using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string IdAlumno { set; get; }
        public string NombreAsignatura {set; get; }
        public string UniqueId { private set; get; }
        public float Nota { set; get; }

        public Evaluacion() => UniqueId = Guid.NewGuid().ToString();
    }
}