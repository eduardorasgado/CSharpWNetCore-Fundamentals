using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporter
    {
        private Dictionary<ValuesOfKeyDiccionario,
            IEnumerable<EscuelaBase>> _diccionario;
        
        public Reporter
            (Dictionary<ValuesOfKeyDiccionario,
                    IEnumerable<EscuelaBase>> dict)
        {
            // si dict es null se levanta una exception
            _diccionario = dict ?? throw new ArgumentException(nameof(dict));
        }
    }
}