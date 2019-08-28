namespace DLL.Pattern
{
    using DLL.Model;
    using System.Collections.Generic;

    public class Repository : IRepository
    {
        #region Atributos
        private int index;
        static int personas = 3;
        #endregion
        #region Constructor
        public Repository()
        {
            Persona.dbPersonas = new List<Persona>();
            Persona persona1 = new Persona
            {
                id = 1,
                nombre="Jose",
                apellido="Perez",
                direccion="Santana",
                edad=25                
            };
            Persona persona2= new Persona
            {
                id = 2,
                nombre="Juan",
                apellido="Perez",
                direccion="Santana",
                edad=23                
            };
            Persona.dbPersonas.Add(persona1);
            Persona.dbPersonas.Add(persona2);
        }
        #endregion
        #region MetodosInterfaz
        public List<Persona> GetAll()
        {
            return Persona.dbPersonas;
        }

        public Persona GetById(int id)
        {
            return Persona.dbPersonas.Find(p => p.id.Equals(id));
        }

        public bool PersonOperation(Persona item, Facade.Operacion operacion)
        {
            try
            {
                switch (operacion)
                {
                    case Facade.Operacion.Save:
                        item.id = personas;
                        Persona.dbPersonas.Add(item);
                        personas++;
                        break;
                    case Facade.Operacion.Update:
                        index = Persona.dbPersonas.FindIndex(p => p.id.Equals(item.id));
                        Persona.dbPersonas[index] = item;
                        break;
                    case Facade.Operacion.Delete:
                        index = Persona.dbPersonas.FindIndex(p => p.id.Equals(item.id));
                        Persona.dbPersonas.RemoveAt(index);
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
