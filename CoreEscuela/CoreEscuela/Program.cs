using System;

namespace CoreEscuela
{
    public class Escuela
    {
        // propiedades de la escuela
        public string nombre;
        public string direccion;
        // la ñ es permitida
        public int añoFundacion;
        // puede haber inicializacion por default
        public string ceo = "Eduardo Rasgado";
        
        public void Timbrar()
        {
            // 1000 MHz, 1 second
            Console.WriteLine("Beeep");

        }
        
    }

class Program
    {
        static void Main(string[] args)
        {
            // instancia de la clase Escuela
            var miEscuela = new Escuela();
            miEscuela.nombre = "Cpp Aacademy";
            miEscuela.direccion = "Cr 9 Calle 45";
            miEscuela.añoFundacion = 2016;
            Console.WriteLine("La escuela va a timbrar");
            miEscuela.Timbrar();
        }
    }
}
