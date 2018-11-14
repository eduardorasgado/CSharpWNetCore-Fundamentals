using System;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        private string UniqueId { get; set; }
        public string Nombre { get; set; }
        
        public TiposJornadas Jornada { get; set; }


        public Curso()
        {
            // creando un id autogenerado
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}