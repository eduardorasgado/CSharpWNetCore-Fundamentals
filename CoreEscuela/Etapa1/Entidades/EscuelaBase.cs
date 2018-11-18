using System;

namespace CoreEscuela.Entidades
{
    public class EscuelaBase
    {
        public string Nombre { set; get; }
        public string UniqueId { private set; get; }

        public EscuelaBase() => UniqueId = Guid.NewGuid().ToString();
    }
}