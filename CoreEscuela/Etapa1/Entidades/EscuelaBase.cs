using System;

namespace CoreEscuela.Entidades
{
    /// <summary>
    /// La clase es abstracta: Podemos heredar de ella pero no
    /// podemos crear instancias de ella
    /// </summary>
    public abstract class EscuelaBase
    {
        public string Nombre { set; get; }
        public string UniqueId { private set; get; }

        public EscuelaBase() => UniqueId = Guid.NewGuid().ToString();
    }
}