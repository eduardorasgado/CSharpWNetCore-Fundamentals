// para poder usar WriteLine por si solo

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
            //
            //inicializando una instancia principal
            var engine = new EscuelaEngine();
            engine.Inicializar();
            
            WriteLine($"BIENVENIDO A {engine.Escuela.Nombre}");
            MostrarCursosEscuela(engine.Escuela);
            
            Printer.PrintTitle("Pruebas de polimorfismo");
            Printer.PrintTitle("Alumno");
            
            var alumnoTest = new Alumno{Nombre = "Alan Smith"};

            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");
            
            EscuelaBase obj = alumnoTest;
            WriteLine($"EB Alumno: {obj.Nombre}");
            WriteLine($"EB Alumno: {obj.UniqueId}");
            WriteLine($"EB Alumno: {obj.GetType()}");
            // no se puede hacer esto:
            //obj.Evaluaciones;

            Printer.PrintTitle("Evaluación");
            var evaluacion = new Evaluacion
                {Nombre = "Mates #1", Nota = 5.0f,
                    Asignatura = new Asignatura{Nombre = "Mates"}};
            WriteLine($"Evaluacion: {evaluacion.Nombre}");
            WriteLine($"Evaluacion: {evaluacion.Nota}");
            WriteLine($"Evaluacion: {evaluacion.Asignatura.Nombre}");
            WriteLine($"Evaluacion: {evaluacion.GetType()}");

            EscuelaBase obj2 = evaluacion;
            // solo podemos acceder a los campos que aloja el objeto
            // escuela
            WriteLine($"Obj evaluacion: {obj2.Nombre}");
            WriteLine($"Obj evaluacion: {obj2.GetType()}");
            
            // Este es un casting incorrecto
            //alumnoTest = (Alumno) (EscuelaBase) evaluacion;

            //obj = evaluacion;
            Printer.PrintLine();
            // manejando posibles errores con comprobacion de polimorfismo
            if (obj is Alumno)
            {
                var alumnoRecover = (Alumno) obj;
                WriteLine($"Alumno {alumnoRecover.Nombre} recuperado");
            }

            //si se deduce que objeto es transformado en Evaluacion
            // devolvera la evaluacion, si no, devuelve nulo
            Evaluacion evalRecover = obj2 as Evaluacion;
            // devuelve null, ejemplo:
            //Alumno evalRecover = obj2 as Alumno;
            if (evalRecover != null)
            {
                WriteLine($"Evaluación Recuperada: {evalRecover.Nombre}");
            }else { WriteLine("La conversión no es posible."); }
            
            Printer.PrintTitle("Todos los objetos de EscuelaBase");

            var allFromBase = engine.GetObjectosEscuelaBases
                (out var ccursos,
                out var casignaturas,
                out var callumnos,
                out var cevaluacion);    
            //(traerEvaluaciones:false);
            
            WriteLine($"Numero de datos: {allFromBase.Count}");
            WriteLine($"Numero de cursos: {ccursos}");
            WriteLine($"Numero de asignaturas: {casignaturas}");
            WriteLine($"Numero de alumnos: {callumnos}");
            WriteLine($"Numero de evaluaciones: {cevaluacion}");
            WriteLine($"{allFromBase}");
            
            foreach (var ob in allFromBase)
            {
                //WriteLine(ob);
            }
            
            Printer.PrintLine();
            
            // elemento implementado con una interfaz
            engine.Escuela.LimpiarLugar();
            
            // traer todos los objetos que tienen implementado
            // la interfaz ILugar con un Linq
            var listaILugar = from objeto in allFromBase
                where objeto is ILugar
                select objeto;
            
            WriteLine(listaILugar.Count());
            
            foreach (var e in listaILugar)
            {
                WriteLine(e);
            }
            
            // end main
            
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