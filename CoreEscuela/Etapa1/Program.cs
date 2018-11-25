﻿// para poder usar WriteLine por si solo

using System;
// list, queue, stack, hashset, dictionary
using System.Collections.Generic;
using CoreEscuela.Entidades; // Escuela, Curso
using CoreEscuela.App; // EscuelaEngine
using CoreEscuela.Utilidades; // para el uso de Printer
using static System.Console; // shortcut para WriteLine
using System.Linq;


namespace CoreEscuela
{
    // la clase programa solo inicializa la ejecucion del programa
    class Program
    {
        static void Main(string[] args)
        {
            // multicast delegate
            // puede tomar cuantos delegados le demos ->AppDomain...
            // evento llamado cuando termina el programa
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            // en la funcion lambda debemos enviarle en objeto y el sender de
            // el evento o marcará error
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.PrintTitle("Segundo evento agregado.");
            // Podemos remover el primer evento
            //AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;
            
            //inicializando una instancia principal
            var engine = new EscuelaEngine();
            engine.Inicializar();
            
            WriteLine($"BIENVENIDO A {engine.Escuela.Nombre}");
            MostrarCursosEscuela(engine.Escuela);

            var todosEscuelaBases = engine.GetDiccionarioEscuelaBases();
            // filtros opcionales al traer el diccionario
            engine.MostrarDiccionario(todosEscuelaBases, impEval:true, impAl:false, impEsc:false);

            // end main

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            // evento puede ser trabajado como un delegado
            Printer.PrintTitle("Evento llamado... Saliendo. beeep...beeeep...");
        }
        
        /// <summary>
        /// Mostrar en pantalla unn titulo referente a mostrar CUrsos
        /// de la escuela pero de forma decorada
        /// </summary>
        /// <param name="escuela"></param>
        private static void MostrarCursosEscuela(Escuela escuela)
        {
            Printer.PrintTitle("cursos de la Escuela");

            var lista = escuela.CursosLista;
            foreach (var e in lista)
            {
                WriteLine(e);
            }
        }

        #region Métodos de Elementos de Lista
        
        /// <summary>
        /// Agrega elementos de tipo Curso a la lista generica
        /// Para probar los métodos Add y AddRange
        /// </summary>
        /// <param name="cursosLista"></param>
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
                new Curso (){
                    Nombre = "802",
                    Jornada = TiposJornadas.Mañana
                },
                new Curso (){
                    Nombre = "902",
                    Jornada = TiposJornadas.Mañana
                },
                new Curso (){
                    Nombre = "1002",
                    Jornada = TiposJornadas.Noche
                },
                new Curso()
                {
                    Nombre = "1102",
                    Jornada = TiposJornadas.Weekend
                }
            };
            
            // con add range podemos meter una lista 
            // generica dentro de otra lista generica, pero
            // solamente introducioendo los elementos que la
            // conforman
            cursosLista.AddRange(cursosAdicionales);
        }

        /// <summary>
        /// Eliminamos todos los elementos dentro de la lista genérica
        /// Con ello liberamos espacio dentro de una Escuela dada en su
        /// campo CursosLista
        /// </summary>
        /// <param name="cursosLista"></param>
        private static void EliminarElementosDeLista(List<Curso> cursosLista)
        {
            WriteLine("Eliminando todos los elementos de la lista");
            // remover todos los elementos de la lista
            cursosLista.Clear();
        }

        /// <summary>
        /// Eliminamos un elemento de la lista generica especificando
        /// para ello, el objeto específico a eliminar, solo usada
        /// cuando tenemos disponible el objeto de la lista a ser
        /// eliminado
        /// </summary>
        /// <param name="cursosLista"></param>
        private static void EliminarUnElementoDeLista(List<Curso> cursosLista)
        {
            WriteLine("Eliminando un elemento especifico de la lista.");
            // removiendo un objecto especifico dentro de una lista
            // generica

            // como parametro es el objeto a ser eliminado
            cursosLista.Remove(cursosLista[0]);
        }

        /// <summary>
        /// Vemos como eliminar de la lista de cursos, ciertos cursos
        /// que cumplan con un criterio especifico dado, con ello
        /// tenemos una eliminacion rapida de elementos. De igual manera
        /// se ponen a prueba Predicate, delegate y expresiones lambda.
        /// </summary>
        /// <param name="cursosLista"></param>
         private static void EliminarElementosDeListaEspecificos(List<Curso> cursosLista)
        {
            //
            WriteLine("Eliminar todos los elementos que cumplan con cierto criterio");
     
            // same as above but using a delegate
            // elimina todos los que coinciden con un tipo de 
            // jornada: Mañana
            // lo mismo pero con una expresion tipo lambda
            cursosLista.RemoveAll(
                (Curso cur) => cur.Jornada == TiposJornadas.Weekend);
        }

        #endregion
    }
}