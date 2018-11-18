using System;

namespace CoreEscuela.Entidades
{
    /// <summary>
    /// Un curso debe de tener asignaturas
    /// </summary>
    public class Asignatura : EscuelaBase
    {
        public override string ToString()
        {
            return $"Nombre: {Nombre}";
        }
    }
}