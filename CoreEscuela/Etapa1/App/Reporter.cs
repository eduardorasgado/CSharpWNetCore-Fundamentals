using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporter
    {
        private readonly Dictionary<ValuesOfKeyDiccionario,
            IEnumerable<EscuelaBase>> _diccionario;
        
        public Reporter
            (Dictionary<ValuesOfKeyDiccionario,
                    IEnumerable<EscuelaBase>> dict)
        {
            // si dict es null se levanta una exception
            _diccionario = dict ?? throw new ArgumentException(nameof(dict));
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {  
            // manera segura de buscar un dato
            return (_diccionario.TryGetValue(
                ValuesOfKeyDiccionario.Evaluacion,
                out IEnumerable<EscuelaBase> lista))
                // retornando una lista con todas las evalauciones
                ? lista.ToList().Cast<Evaluacion>() 
                // otherwise: retornando una lista vacia
                : new List<Evaluacion>();
            
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            // sobrecarga parametro vacio
            return GetListaAsignaturas(out IEnumerable<Evaluacion> dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(
            out IEnumerable<Evaluacion>listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();
            // linq query
            return (from ev in listaEvaluaciones
                where ev.Nota >= 4.0
                select ev.Asignatura.Nombre).Distinct();
            // investigar comparer o comparison
            // Distinct permite traer nombres una unica vez
        }
        
        /// <summary>
        ///evaluaciones por asignatura
        ///asignatura: lista de evaluaciones
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<Evaluacion>> 
            GetEvaluacionesPorAsignatura()
        {
            var evaluacionesxAs = new Dictionary<string, IEnumerable<Evaluacion>>();
            
            var listaAsignaturas = GetListaAsignaturas(
                // para no hacer doble trabajo de llamar a GetListaEvaluaciones
                out var listaEvaluaciones);
            
            foreach (var asignatura in listaAsignaturas)
            {
                var listaTemp = from ev in listaEvaluaciones
                    where ev.Asignatura.Nombre == asignatura
                    select ev;
                evaluacionesxAs.Add(asignatura, listaTemp);
            }

            return evaluacionesxAs;
        }

        /// <summary>
        /// Devuelve un diccionario con la estructura de
        /// Asignatura: [Alumno y promedio] total
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<AlumnoPromedio>> 
            GetPromedioAlumnosxAsignatura()
        {
            // devolvemos: <Alumno, Promedio>
            var response = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            
            var dicEvalPorAsignatura = GetEvaluacionesPorAsignatura();
            foreach (var asignaturaConEvaluaciones in dicEvalPorAsignatura)
            {
                var promAlumnosTemp = from ev in asignaturaConEvaluaciones.Value
                    // agrupamiento de datos
                    group ev by new
                    {
                        ev.Alumno.UniqueId,
                        ev.Alumno.Nombre
                    }// por alumno
                    into grupoEvalsAlumno
                    // tipos anonimos
                    select new AlumnoPromedio
                    {
                        // valor del UniqueId es Key
                        AlumnoId = grupoEvalsAlumno.Key.UniqueId,
                        AlumnoNombre = grupoEvalsAlumno.Key.Nombre,
                        Promedio = grupoEvalsAlumno
                            // average toma un delegate o lambda y se le
                            // especifica el campo a promediar
                            .Average((evaluacion) => evaluacion.Nota)
                    };
               
                // agregando elementos al diccionario
                // asignatura, promedios
                response.Add(asignaturaConEvaluaciones.Key, promAlumnosTemp);   
            }
            return response;
        }
        
        /// <summary>
        /// RETO:
        /// Crear un reporte que muestre solo los mejores x promedios por asignatura
        /// X debe ser pasado como parametro
        /// El reporte contiene la asignatura y una lista de los Top X alumnos
        /// con su promedio
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<AlumnoPromedio>> mejoresPromediosPorAs(int X)
        {
            //
            var mejoresPromedios = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            /*
             * implementacion del reto aqui
             */
            return mejoresPromedios;
        }
        
    }
}