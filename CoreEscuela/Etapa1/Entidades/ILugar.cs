namespace CoreEscuela.Entidades
{
    /// <summary>
    /// Una interfaz es una definicion de la estructura que
    /// debe tener un objeto
    /// </summary>
    public interface ILugar
    {
        // usualmente los atributos de las interfaces son
        // publicos
        string Direccion { set; get; }

        // En una interfaz solo se declaran los metodos
        // No se definen
        void LimpiarLugar();
    }
}