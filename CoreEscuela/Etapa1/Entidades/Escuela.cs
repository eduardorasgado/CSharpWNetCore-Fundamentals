using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        // atributos
        private string nombre;
        // propiedades de nombre
        public string Nombre
        {
            get { return "Copia: " + nombre; }
            // value es una keyword que tiene nombre por default
            set { nombre = value.ToUpper(); }
        }

        // cuando no hay cambios en el I/O de la variable
        // podemos hacer las propiedades con la siguiente estructura
        private int AñoCreacion { get; set; }
        
        public string Pais { get; set; }
        public string Ciudad { set; get; }
        
        // del TipoEscuelas que es un ENUM y se encuentra en entidades tambien
        public TiposEscuelas TipoEscuela { get; set; }
        
        // array de objectos de la clase curso
        public Curso[] CursosPrimitive { get; set; }
        
        // coleccion de arreglos pero dentro de una lista generica
        public List<Curso> CursosLista { get; set; }
        
        // Constructor de la escuela
        //public Escuela(string nombre, int año)
        //{
        //    this.nombre = nombre;
        //    this.AñoCreacion = año;
        //}

        // Constructor de tipo igualacion por tupla
        public Escuela(string nombre, int año) 
            => (Nombre, AñoCreacion) = (nombre, año);

        // Segundo constructor posible parametros por defecto
        public Escuela(string nombre, int año, TiposEscuelas tipo,
            string pais="Mexico", string ciudad = "")
            => (Nombre, AñoCreacion, TipoEscuela, Pais, Ciudad)
                = (nombre, año, tipo, pais, ciudad);
        
        // sobreescrbiendo el metodo de Escuela: sobrecarga
        public override string ToString()
        {
            // concatenacion 
            return $"Nombre: \"{Nombre.Split(": ")[1]}\"," +
                   $" Tipo: {TipoEscuela}{Environment.NewLine}" +
                   $" Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}