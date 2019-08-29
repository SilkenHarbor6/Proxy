using Acr.UserDialogs;
using DLL.Model;
using DLL.Pattern;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proxy.ViewModel
{
    public class addPageViewModel :BaseViewModel
    {
        #region Atributos
        private String nombre, apellido, direccion;
        private int edad;
        private Persona p;
        #endregion
        #region Propiedades
        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;OnPropertyChanged("Nombre");
            }
        }
        public String Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;OnPropertyChanged("Apellido");
            }
        }
        public String Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;OnPropertyChanged("Direccion");
            }
        }
        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                edad = value;OnPropertyChanged("Edad");
            }
        }
        #endregion
        #region Constructor
        public addPageViewModel()
        {
        }
        #endregion
        #region Comandos
        public ICommand Agregar
        {
            get
            {
                return new RelayCommand(Add);
            }
        }
        #endregion
        #region Metodos
        public async void Add()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                await UserDialogs.Instance.AlertAsync(new AlertConfig().SetTitle("Error").SetMessage("Todos los campos son requeridos").SetOkText("Aceptar"));
                return;
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                await UserDialogs.Instance.AlertAsync(new AlertConfig().SetTitle("Error").SetMessage("Todos los campos son requeridos").SetOkText("Aceptar"));
                return;
            }
            if (string.IsNullOrEmpty(Direccion))
            {
                await UserDialogs.Instance.AlertAsync(new AlertConfig().SetTitle("Error").SetMessage("Todos los campos son requeridos").SetOkText("Aceptar"));
                return;
            }
            if (Edad <= 0)
            {
                await UserDialogs.Instance.AlertAsync(new AlertConfig().SetTitle("Error").SetMessage("La edad es invalida").SetOkText("Aceptar"));
                return;
            }
            if (Edad >= 110)
            {
                await UserDialogs.Instance.AlertAsync(new AlertConfig().SetTitle("Error").SetMessage("La edad es invalida").SetOkText("Aceptar"));
                return;
            }
            p = new Persona()
            {
                nombre = this.Nombre,
                apellido = this.Apellido,
                direccion = this.Direccion,
                edad = this.Edad
            };
            var resp=SingletonRepository.Instancia.Repository.PersonOperation(p, Facade.Operacion.Save);
            if (resp)
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
                UserDialogs.Instance.Toast(new ToastConfig("Registro agregado").SetIcon("ghost32"));
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
                UserDialogs.Instance.Toast(new ToastConfig("Error al agregar el registro").SetIcon("ghost32"));
            }
        }
        #endregion
    }
}
