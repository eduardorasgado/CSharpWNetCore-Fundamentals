using System;

namespace CoreEscuela.Entidades
{
    /// <summary>
    /// Clase que representa un curso dentro de una lista de cursos
    /// que tiene una Escuela.
    /// </summary>
    public class Curso
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        
        public TiposJornadas Jornada { get; set; }

        // constructor
        // creando un id autogenerado
        public Curso() => UniqueId = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Jornada: {Jornada}";
        }
    }
}