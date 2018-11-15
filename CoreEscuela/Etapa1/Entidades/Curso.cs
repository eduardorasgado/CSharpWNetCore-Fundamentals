using System;

namespace CoreEscuela.Entidades
{
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