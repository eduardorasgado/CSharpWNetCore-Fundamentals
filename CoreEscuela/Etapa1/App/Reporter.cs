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
        public Dictionary<string, IEnumerable<Evaluacion>> GetEvaluacionesPorAsignatura()
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
        /// Devuelve un diccionario con la estructura de Alumno y promedio total
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnosxAsignatura()
        {
            // devolvemos: <Alumno, Promedio>
            var response = new Dictionary<string, IEnumerable<object>>();
            
            var dicEvalPorAsignatura = GetEvaluacionesPorAsignatura();
            foreach (var asignaturaConEvaluaciones in dicEvalPorAsignatura)
            {
                var dummy = from ev in asignaturaConEvaluaciones.Value
                    // agrupamiento de datos
                    group ev by ev.Alumno.UniqueId // por alumno
                    into grupoEvalsAlumno
                    // tipos anonimos
                    select new
                    {
                        // valor del UniqueId es Key
                        AlumnoId = grupoEvalsAlumno.Key,
                        Promedio = grupoEvalsAlumno
                            // average toma un delegate o lambda y se le
                            // especifica el campo a promediar
                            .Average((evaluacion) => evaluacion.Nota)
                    };
                
                foreach (var item in dummy)
                {
                    Console.WriteLine($"{item.AlumnoId}: {item.Promedio}");
                }
                //var nombreAlumno =
                //response.Add();
            }
            
            return response;
        }
    }
}