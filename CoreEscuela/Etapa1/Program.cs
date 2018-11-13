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
            
            // asignacion a un atributo de tipo enum
            escuela.TipoEscuela = TiposEscuelas.Online;

            // llamando el metodo ToString de forma implicita
            Console.WriteLine(escuela);
            
            // Concatenando y split a una variable string
            Console.WriteLine("La " + escuela.Nombre.Split(": ")[1] + " ubicada en " + escuela.Pais + " de tipo: " + escuela.TipoEscuela);
        }
    }
}