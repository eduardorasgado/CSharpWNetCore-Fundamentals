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
            
            IEnumerable<Evaluacion> listaEvaluaciones;
            var listaAsignaturas = GetListaAsignaturas(out listaEvaluaciones);
            
            foreach (var asignatura in listaAsignaturas)
            {
                var listaTemp = from ev in listaEvaluaciones
                    where ev.Asignatura.Nombre == asignatura
                    select ev;
                evaluacionesxAs.Add(asignatura, listaTemp);
            }

            return evaluacionesxAs;
        }
    }
}