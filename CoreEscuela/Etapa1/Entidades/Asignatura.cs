using System;

namespace CoreEscuela.Entidades
{
    /// <summary>
    /// Un curso debe de tener asignaturas
    /// </summary>
    public class Asignatura
    {
        public string Nombre { set; get; }
        public string UniqueId { private set; get; }

        public Asignatura() => UniqueId = Guid.NewGuid().ToString();
    }
}