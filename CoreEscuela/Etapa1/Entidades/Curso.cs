using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    /// <summary>
    /// Clase que representa un curso dentro de una lista de cursos
    /// que tiene una Escuela.
    /// </summary>
    public class Curso : EscuelaBase
    {   
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Jornada: {Jornada}";
        }
    }
}