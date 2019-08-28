namespace DLL.Model
{
    using System.Collections.Generic;
    public class Persona
    {
        #region Propiedad
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int edad { get; set; }
        public static List<Persona> dbPersonas;

        #endregion
    }
}
