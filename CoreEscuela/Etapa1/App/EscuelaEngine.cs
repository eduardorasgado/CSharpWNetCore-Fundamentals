using System.Collections.Generic;
using CoreEscuela.Entidades;

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
            throw new System.NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var c in Escuela.CursosLista)
            {
                // cargando las asignaturas para cada curso
                List<Asignatura> listaAsignaturas = null;
                c.Asignaturas.AddRange(listaAsignaturas);
            }
        }

        private void CargarAlumnos()
        {
            throw new System.NotImplementedException();
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