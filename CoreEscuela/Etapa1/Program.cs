// para poder usar WriteLine por si solo
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Cpp Academy", 2016);
            
            WriteLine(escuela.Nombre);

            escuela.Pais = "Mexico";
            escuela.Ciudad = "CDMX";
            
            // asignacion a un atributo de tipo enum
            escuela.TipoEscuela = TiposEscuelas.Online;

            // llamando el metodo ToString de forma implicita
            WriteLine(escuela);
            
            // Concatenando y split a una variable string
            WriteLine("La " + escuela.Nombre.Split(": ")[1] +
                              " ubicada en " + escuela.Pais + " de tipo: " + escuela.TipoEscuela);
            
            var escuela2 = new Escuela("C# Academy", 2014, TiposEscuelas.Online, ciudad: "Monterrey");
            WriteLine(escuela2);
            
            // arreglo estatico de cursos
            //var arregloCursos = new Curso[]
            Curso[] arregloCursos = 
            {
                // creando instancias de cursos
                // y las introducimos en el arreglo
                new Curso{ Nombre = "101" },
                new Curso{ Nombre = "201" },
                new Curso{ Nombre = "301" }
            };

            escuela.Cursos = arregloCursos;
            //escuela.Cursos = null;
            //escuela = null;
            
            WriteLine("=============");

            WriteLine("Presione enter: ");            
            // leer una linea de entrada del usuario
            var enter = ReadLine();
            
            // llamando al metodo de la clase Program
            ImprimirCursosWhile(arregloCursos);
            WriteLine("---------");
            ImprimirCursosDoWhile(arregloCursos);
            WriteLine("---------");
            ImprimirCursosFor(arregloCursos);
            WriteLine("---------");
            ImprimirCursosForEach(arregloCursos);
            WriteLine("---------");

            ImprimirCursosEscuela(escuela);

        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            WriteLine("Ciclo While");
            // iterando con un ciclo while
            var counter = 0;
            while (counter < arregloCursos.Length)
            {
                WriteLine(arregloCursos[counter]);
                counter++;
            }
        }
        
        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            WriteLine("Ciclo Do while");
            // El ciclo do while se tiene que invocar al menos
            // una vez
            var counter = 0;
            do
            {
                WriteLine(arregloCursos[counter]);
                counter++;
            } while (counter < arregloCursos.Length);
        }
        
        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            WriteLine("Ciclo For");
            // iterando entre los miembros del arreglo para 
            // imprimirlos
            for (var i = 0; i < arregloCursos.Length; i++)
            {
                WriteLine(arregloCursos[i]);
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            WriteLine("ForEach loop");
            // Iteración sobre un arreglo con un foreach
            // Es muy seguro, pero no podemos tener el control del
            // indice del arreglo
            foreach (var e in arregloCursos)
            {
                WriteLine(e);
            }
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("-Cursos de la escuela 1-");
            // merging sequential check with ?
            // this is same as:
            // escuela != null && escuela.Cursos != null
            if(escuela?.Cursos != null) ImprimirCursosForEach(escuela.Cursos);
        }
    }
}