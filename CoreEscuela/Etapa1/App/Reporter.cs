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

        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            IEnumerable<Escuela> response;
            
            // manera segura de buscar un dato
            if (_diccionario.TryGetValue(
                    ValuesOfKeyDiccionario.Escuela,
                    out IEnumerable<EscuelaBase> lista))
            {
                response = lista.Cast<Escuela>();
                return response;
            }
            
            return null;
        }
    }
}