using ConsoleApp.Class;
using DLL.Model;
using DLL.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static Persona persona;
        static int res, id;
        static bool per = true, resp;
        static char letra;
        static IRepository datos = new ProxyRepository();
        static List<Persona> listaPersonas;
        private static void GetMenu()
        {
            Console.WriteLine("*************MENU*************");
            Console.WriteLine("1-Consultar lista de personas");
            Console.WriteLine("2-Consultar persona por id");
            Console.WriteLine("3-Eliminar persona");
            Console.WriteLine("4-Agregar registro");
            Console.WriteLine("5-Actualizar registro");
            Console.WriteLine("6-Salir");
            Console.WriteLine("Ingrese su opcion:");
        }
        private static void MostrarInfo()
        {
            listaPersonas = datos.GetAll();
            foreach (Persona item in listaPersonas)
            {
                Console.WriteLine("Nombre: {0} {1}", item.nombre, item.apellido);
                Console.WriteLine("Direccion: {0}", item.direccion);
                Console.WriteLine("Edad: {0}", item.edad);
                Console.WriteLine("id: {0}", item.id);
                Console.WriteLine();
            }
           
        }
        private static void MostrarInfoP(Persona item)
        {
                Console.WriteLine("Nombre: {0} {1}", item.nombre, item.apellido);
                Console.WriteLine("Direccion: {0}", item.direccion);
                Console.WriteLine("Edad: {0}", item.edad);
                Console.WriteLine("id: {0}", item.id);
                Console.WriteLine();
        }
        static void Main(string[] args)
        {
           
            do
            {
                Console.Clear();
                GetMenu();
                res = Convert.ToInt16(Console.ReadLine());
                switch (res)
                {
                    case 1:
                        Console.Clear();
                        listaPersonas = datos.GetAll();
                        Console.WriteLine("===========================================");
                        Console.WriteLine("Listado de personas");
                        Console.WriteLine("===========================================");
                        MostrarInfo();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingrese el id del usuario que desea conocer");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        persona = datos.GetById(id);
                        if (persona != null)
                        {
                            MostrarInfoP(persona);

                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna persona registrada con ese id");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ingrese el id de la persona que desea eliminar:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        persona = datos.GetById(id);
                        if (persona != null)
                        {
                            resp = datos.PersonOperation(persona, Facade.Operacion.Delete);
                            if (resp)
                            {
                                Console.WriteLine("El registro se elimino con exito");
                                MostrarInfo();

                            }
                            else
                            {
                                Console.WriteLine("Error al eliminar el registro");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna persona registrada con ese id");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        persona = new Persona();
                        Console.WriteLine("Ingrese el nombre de la persona");
                        persona.nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido de la persona");
                        persona.apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese la direccion de la persona");
                        persona.direccion = Console.ReadLine();
                        Console.WriteLine("Ingrese la edad de la persona");
                        persona.edad = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();
                        resp = datos.PersonOperation(persona, Facade.Operacion.Save);
                        if (resp)
                        {
                            Console.WriteLine("El registro se agrego con exito");
                            MostrarInfo();

                        }
                        else
                        {
                            Console.WriteLine("hubo un error al guardar el registro");
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Ingrese el id de la persona que desea modificar");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        persona = datos.GetById(id);
                        if (persona != null)
                        {
                            Console.WriteLine("Nombre: {0} {1}", persona.nombre, persona.apellido);
                            Console.WriteLine("Direccion: {0}", persona.direccion);
                            Console.WriteLine("Edad: {0}", persona.edad);
                            Console.WriteLine("¿Desea actualizar esta persona? (s/n)");
                            letra = Convert.ToChar(Console.ReadLine().ToLower().Trim());
                            Console.Clear();
                            if (letra.Equals('s'))
                            {
                                Console.WriteLine("Ingrese el nombre de la persona");
                                persona.nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el apellido de la persona");
                                persona.apellido = Console.ReadLine();
                                Console.WriteLine("Ingrese la direccion de la persona");
                                persona.direccion = Console.ReadLine();
                                Console.WriteLine("Ingrese la edad de la persona");
                                persona.edad = Convert.ToInt16(Console.ReadLine());
                                resp = datos.PersonOperation(persona, Facade.Operacion.Update);
                                if (resp)
                                {
                                    Console.WriteLine("El registro se actualizo correctamente");
                                    MostrarInfo();
                                }
                                else
                                {
                                    Console.WriteLine("Hubo un error al actualizar el registro");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Operacion cancelada");
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna persona registrada con ese id");
                        }
                        break;
                    case 6:
                        per = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("La opcion seleccionada no existe");
                        Console.ReadKey();
                        break;
                }
            } while (per);
        }
    }
}
