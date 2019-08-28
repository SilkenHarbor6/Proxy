namespace ConsoleApp.Class
{
    using DLL.Model;
    using DLL.Pattern;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    public class ProxyRepository: IRepository
    {
        public List<Persona> GetAll()
        {
            Loading();
            return SingletonRepository.Instancia.Repository.GetAll();
        }

        public Persona GetById(int id)
        {
            Loading();
            return SingletonRepository.Instancia.Repository.GetById(id);
        }

        public bool PersonOperation(Persona item, Facade.Operacion operacion)
        {
            Loading();
            return SingletonRepository.Instancia.Repository.PersonOperation(item, operacion);
        }

        private void Loading()
        {
            Console.WriteLine("Cargando...");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
