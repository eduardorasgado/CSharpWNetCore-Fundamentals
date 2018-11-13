using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Cpp Academy", 2016);
            
            Console.WriteLine(escuela.Nombre);

            escuela.Pais = "Mexico";
            escuela.Ciudad = "CDMX";
            
            // Concatenando y split a una variable string
            Console.WriteLine("La " + escuela.Nombre.Split(": ")[1] + " ubicada en " + escuela.Pais);
        }
    }
}