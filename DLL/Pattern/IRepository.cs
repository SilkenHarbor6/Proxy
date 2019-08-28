using DLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Pattern
{
    public interface IRepository
    {
        #region Metodos

        List<Persona> GetAll();//Obtener todas las personas
        Persona GetById(int id);
        bool PersonOperation(Persona item, Facade.Operacion operacion);

        #endregion
    }
}
