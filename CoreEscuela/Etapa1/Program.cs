// para poder usar WriteLine por si solo

using System;
// list, queue, stack, hashset, dictionary
using System.Collections.Generic;
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

            // from using System.Collections.Generic;
            var listaCursos = new List<Curso>()
            {
                new Curso{ Nombre = "101" },
                new Curso{ Nombre = "201" },
                new Curso{ Nombre = "301" }
            };
            
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

            escuela.CursosPrimitive = arregloCursos;
            //escuela.Cursos = null;
            //escuela = null;
            escuela.CursosLista = listaCursos;
            
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
            
            Conditionals();

            ImprimiendoColeccionesLista(escuela);
            
            // exclusivamente para la lista generica
            AgregarElementosALista(escuela.CursosLista);
            
            ImprimiendoColeccionesLista(escuela);
            
            // eliminado solo un elemento dentro de la lista generica
            EliminarUnElementoDeLista(escuela.CursosLista);
            
            ImprimiendoColeccionesLista(escuela);
            
            // Eliminando solo elementos que cumplan con criterios
            // especificos
            EliminarElementosDeListaEspecificos(escuela.CursosLista);
            
            ImprimiendoColeccionesLista(escuela);
            
            // Eliminando todos los elementos de la lista
            EliminarElementosDeLista(escuela.CursosLista);
            
            ImprimiendoColeccionesLista(escuela);
            
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
            // verificacion por signo de interrogacion?
            // esto es lo mismo que
            // escuela != null && escuela.Cursos != null
            // y significa que no se va a verificar cursos a menos
            // que escuela no sea nula
            if(escuela?.CursosPrimitive != null) ImprimirCursosForEach(escuela.CursosPrimitive);
        }

        private static void Conditionals()
        {
            // generando un numero aleatorio entre 0 y 10
            var randGenerator = new Random();
            int randNum = randGenerator.Next(0, 10);
            
            // poniendo a prueba los condicionales
            if (randNum == 10)
            {
                WriteLine("Its 10");
            }
            else if (randNum == 5 )
            {
                WriteLine("Its 5");
            }
            else
            {
                WriteLine($"It is a completely different number: {randNum}");    
            }
        }

        private static void ImprimiendoColeccionesLista(Escuela escuela)
        {
            Console.WriteLine("---Imprimiendo cursos de una lista generica---");
            var lista = escuela.CursosLista;
            foreach (var e in lista)
            {
                Console.WriteLine(e);
            }
        }

        private static void AgregarElementosALista(List<Curso> cursosLista)
        {
            cursosLista.Add(new Curso()
            {
                Nombre = "402",
                Jornada = TiposJornadas.Tarde
            });
            
            // usando add range para agregar mas cursos a la vez
            var cursosAdicionales = new List<Curso>()
            {
                new Curso (){
                    Nombre = "502",
                    Jornada = TiposJornadas.Tarde
                },
                new Curso (){
                    Nombre = "602",
                    Jornada = TiposJornadas.Noche
                },
                new Curso (){
                    Nombre = "702",
                    Jornada = TiposJornadas.Mañana
                },
            };
            
            // con add range podemos meter una lista 
            // generica dentro de otra lista generica, pero
            // solamente introducioendo los elementos que la
            // conforman
            cursosLista.AddRange(cursosAdicionales);
        }

        private static void EliminarElementosDeLista(List<Curso> cursosLista)
        {
            WriteLine("Eliminando todos los elementos de la lista");
            // remover todos los elementos de la lista
            cursosLista.Clear();
        }

        private static void EliminarUnElementoDeLista(List<Curso> cursosLista)
        {
            WriteLine("Eliminando un elemento especifico de la lista.");
            // removiendo un objecto especifico dentro de una lista
            // generica

            // como parametro es el objeto a ser eliminado
            cursosLista.Remove(cursosLista[0]);
        }

         private static void EliminarElementosDeListaEspecificos(List<Curso> cursosLista)
        {
            //
            WriteLine("Eliminar todos los elementos que cumplan con cierto criterio");

            // eliminar elementos de la lista que cumplan con
            // criterios especificados o satisfagan condiciones
            // dentro de una funcion que se le pasa.
            cursosLista.RemoveAll(Predicado);
        }

        private static bool Predicado(Curso curobj)
        {
            // funcion que entra en los parametros de RemoveAll
            // para listas genericas, este devolvera los objectos
            // de clase curso que devuelvan Tipos de Jornada
            // de la enumeracion TiposJornadas exactamente: Noche
            return curobj.Jornada == TiposJornadas.Noche;
        }
    }
}