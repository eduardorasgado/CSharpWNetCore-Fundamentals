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
        
        // Constructor de la escuela
        //public Escuela(string nombre, int año)
        //{
        //    this.nombre = nombre;
        //    this.AñoCreacion = año;
        //}

        // Constructor de tipo igualacion por tupla
        public Escuela(string nombre, int año) => (Nombre, AñoCreacion) = (nombre, año);

    }
}