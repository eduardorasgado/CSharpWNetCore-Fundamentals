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
            CargarAlumnos();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            //throw new System.NotImplementedException();
        }

        private void CargarAsignaturas()
        {   
            foreach (var c in Escuela.CursosLista)
            {
                // cargando las asignaturas para cada curso
                var listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{ Nombre="Programación Básica" },
                    new Asignatura{ Nombre="Cálculo Diferencial" },
                    new Asignatura{ Nombre="Electrónica Digital" },
                    new Asignatura{ Nombre = "Lenguajs de Programación" }
                };
                c.Asignaturas.AddRange(listaAsignaturas);
            }
        }

        private IEnumerable<Alumno> CargarAlumnos()
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
            return listaAlumnos;
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
    }
}