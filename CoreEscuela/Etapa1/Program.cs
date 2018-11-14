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
            Console.WriteLine("La " + escuela.Nombre.Split(": ")[1] +
                              " ubicada en " + escuela.Pais + " de tipo: " + escuela.TipoEscuela);
            
            var escuela2 = new Escuela("C# Academy", 2014, TiposEscuelas.Online, ciudad: "Monterrey");
            Console.WriteLine(escuela2);
            
            // arreglo estatico de cursos
            var arregloCursos = new Curso[3];
            
            // creando instancias de cursos
            // y las introducimos en el arreglo
            arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };
            
            arregloCursos[1] = new Curso
            {
                Nombre = "201"
            };
            
            var curso3 = new Curso()
            {
                Nombre = "301"
            };

            arregloCursos[2] = curso3;
            
            Console.WriteLine("=============");

            Console.WriteLine("Presione enter: ");            
            // leer una linea de entrada del usuario
            var enter = Console.ReadLine();
            
            // llamando al metodo de la clase Program
            ImprimirCursosWhile(arregloCursos);
            Console.WriteLine("---------");
            ImprimirCursosDoWhile(arregloCursos);
            Console.WriteLine("---------");
            ImprimirCursosFor(arregloCursos);

        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            Console.WriteLine("Ciclo While");
            // iterando con un ciclo while
            var counter = 0;
            while (counter < arregloCursos.Length)
            {
                Console.WriteLine(arregloCursos[counter]);
                counter++;
            }
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            Console.WriteLine("Ciclo For");
            // iterando entre los miembros del arreglo para 
            // imprimirlos
            for (var i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine(arregloCursos[i]);
            }
        }
        
        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            Console.WriteLine("Ciclo Do while");
            // El ciclo do while se tiene que invocar al menos
            // una vez
            var counter = 0;
            do
            {
                Console.WriteLine(arregloCursos[counter]);
                counter++;
            } while (counter < arregloCursos.Length);
        }
    }
}