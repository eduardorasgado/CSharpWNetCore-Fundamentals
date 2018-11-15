using System;

using static System.Console;

namespace CoreEscuela.Utilidades
{
    /// <summary>
    /// Donde encontramos utilidades para impresion por
    /// consola, para incrementar la facilidad de lectura
    /// de la clase program
    /// La clase es de tipo estatica, esto es que no se puede
    /// crear instancias de ella
    /// </summary>
    public static class Printer
    {
        public static void PrintLine(int size = 20)
        {
            // '=' debe ser asi por ser de tipo caracter
            // y no "=" de tipo string
            var chain = "".PadLeft(size, '=');
            WriteLine(chain);
        }
    }
}