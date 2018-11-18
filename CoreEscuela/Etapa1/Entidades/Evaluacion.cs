using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string Nombre { set; get; }
        public Alumno Alumno { set; get; }
        public Asignatura Asignatura {set; get; }
        public string UniqueId { private set; get; }
        public float Nota { set; get; }

        public Evaluacion() => UniqueId = Guid.NewGuid().ToString();
    }
}