using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion : EscuelaBase
    {
        public Alumno Alumno { set; get; }
        public Asignatura Asignatura {set; get; }
        public float Nota { set; get; }
        
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Nota: {Nota}, Asignatura: {Asignatura}";
        }
    }
}