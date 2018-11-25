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
    }
}