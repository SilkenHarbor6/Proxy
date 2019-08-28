using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Pattern
{
    public class SingletonRepository
    {
        #region Atributos
        private static SingletonRepository instancia;
        private Repository repository;
        #endregion

        #region Propiedades
        public static SingletonRepository Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new SingletonRepository();
                }
                return instancia;
            }
        }
        public Repository Repository
        {
            get
            {
                return this.repository;
            }
        }
        #endregion

        #region Constructor
        protected SingletonRepository()
        {
            this.repository = new Repository();
        }
        #endregion


    }
}
