using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq; // para poder crear llamadas a database o querys

namespace CoreEscuela.App
{
    /// <summary>
    /// Clase principal para hacer la administración y gestión de
    /// toda la escuela
    /// </summary>
    public class EscuelaEngine
    {
        public Escuela Escuela { set; get; }

        // constructor por default
        public EscuelaEngine()
        {
            //
        }
        
        // metodo responsable de inicializar todos los valores
        // dentro de neuestro programa
        public void Inicializar()
        {
            Escuela = new Escuela("C# Academy", 2014,
                TiposEscuelas.Online, ciudad: "Monterrey",
                pais: "México");

            CargarCursos();
            CargarAsignaturas();
            CargarListaAlumnos();
            CargarEvaluaciones();

            TestingDeAleatoriedad();
        }

        private void CargarEvaluaciones()
        {
            //
        }

        private void CargarAsignaturas()
        {   
            foreach (var curso in Escuela.CursosLista)
            {
                // cargando las asignaturas para cada curso
                var listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{ Nombre="Programación Básica" },
                    new Asignatura{ Nombre="Cálculo Diferencial" },
                    new Asignatura{ Nombre="Electrónica Digital" },
                    new Asignatura{ Nombre = "Lenguajs de Programación" }
                };
                // no podemos usar AddRange hasta que definamos el contenido
                // de curso.Asignaturas, ya que esta por el momento está
                // nula, debemos agregarle por primera vez con =.
                curso.Asignaturas = listaAsignaturas;
            }
        }

        /// <summary>
        /// Toma como parametro cantidad de alumnos a generar
        /// hace un producto cartesiano con los arreglos de string
        /// y selecciona solo aquellos que no han sido seleccionado antes
        /// para devolverlos de forma mas natural sin truncar los casi 400
        /// alumnos que la listaAlumnos produce
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombres = {"Eduardo", "Mario", "Francisco", "Manuel", "Fabian", "Mariana", "Victor"};
            string[] apellido1 = {"Rasgado", "Guzman", "Olmedo", "Santiago", "Peña", "Jimenez", "Amampour", "Bartolo"};
            string[] apellido2 = {"Ruiz", "Mendoza", "Cabrera", "Manrriquez", "Torres", "Santiago", "Alvarado"};
            
            // Utilizamos linq para crear combinatorias random de nombres
            // linq son expresiones de consultas
            // Language-Integrated Query
            //
            // aqui estamos creando un producto cartesiano con los arrays de strings arriba escritos
            var listaAlumnos = from n in nombres
                from a1 in apellido1
                from a2 in apellido2
                select new Alumno{Nombre = $"{n} {a1} {a2}"};
            // retornamos para asignarlo a cada uno de los cursos
            // retorna cierta cantidad y en un orden basado en el UniqueId
            return listaAlumnos.ToList();
        }

        /// <summary>
        /// Carga cierto número de alumnos generado aleatoriamente
        /// cada vez que es llamado por la funcion o método
        /// CargarListaAlumnos
        /// </summary>
        /// <returns></returns>
        private List<Alumno> CargarAlumnos()
        {
            // generar un numero random de alumnos
            var randGenerator = new Random();
            
            var numeroDeSalto = randGenerator.Next(1, 300);
            // de 20 a 40 por curso
            var alumnosPorCurso = randGenerator.Next(20, 40);
            
            // devuelve desde [numSalto: numSalto+alumnoPorCurso]
            var alumni = GenerarAlumnosAlAzar().Skip(numeroDeSalto).Take(alumnosPorCurso).ToList();
            
            return alumni;
        }

        /// <summary>
        /// Agrega alumnos generados al azar al campo Alumnos
        /// de la clase Curso, en la inicializacion del objeto
        /// </summary>
        private void CargarListaAlumnos()
        {
            // gaurdando la misma lista de alumnos para cada
            // curso
            foreach (var curso in Escuela.CursosLista)
            {
                // estamos agregando por primera vez
                // Es preferible utilizar el operador de asig-
                // nacion en lugar de AddRange
                curso.Alumnos = CargarAlumnos();
            }
        }

        private void CargarCursos()
        {
            // de using System.Collections.Generic;
            var listaCursos = new List<Curso>()
            {
                new Curso {Nombre = "101", Jornada = TiposJornadas.Mañana},
                new Curso {Nombre = "201", Jornada = TiposJornadas.Tarde},
                new Curso {Nombre = "301", Jornada = TiposJornadas.Noche},
                new Curso {Nombre = "401", Jornada = TiposJornadas.Mañana},
                new Curso {Nombre = "501", Jornada = TiposJornadas.Weekend}
            };

            Escuela.CursosLista = listaCursos;
        }

        private void TestingDeAleatoriedad()
        {
            // testing de que ttodos los alumnos son generados
            // de forma aleatoria
            foreach (var c in Escuela.CursosLista)
            {
                Console.WriteLine(c.Alumnos.Count);
                
                foreach (var a in c.Alumnos)
                {
                    Console.WriteLine(a.Nombre);
                }
            }
        }
    }
}