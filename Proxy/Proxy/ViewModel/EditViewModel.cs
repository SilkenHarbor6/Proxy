using Acr.UserDialogs;
using DLL.Model;
using DLL.Pattern;
using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proxy.ViewModel
{
    public class EditViewModel : BaseViewModel
    {
        #region Atributos
        private Persona _Persona;
        private String nombre, apellido, direccion;
        private int edad;
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
                nombre = value; OnPropertyChanged("Nombre");
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
                apellido = value; OnPropertyChanged("Apellido");
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
                direccion = value; OnPropertyChanged("Direccion");
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
                edad = value; OnPropertyChanged("Edad");
            }
        }
        #endregion
        #region Constructor
        public EditViewModel(Persona item)
        {
            _Persona = item;
            Nombre = _Persona.nombre;
            Apellido = _Persona.apellido;
            Direccion = _Persona.direccion;
            Edad = _Persona.edad;
        }
        #endregion
        #region Comandos
        public ICommand Close
        {
            get
            {
                return new RelayCommand(dispose);
            }
        }
        public ICommand Editar
        {
            get
            {
                return new RelayCommand(Put);
            }
        }
        #endregion
        #region Metodos
        public async void Put()
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
            _Persona.nombre = Nombre;
            _Persona.apellido = Apellido;
            _Persona.direccion = Direccion;
            _Persona.edad = Edad;
            var resp = SingletonRepository.Instancia.Repository.PersonOperation(_Persona, Facade.Operacion.Update);
            if (resp)
            {
                UserDialogs.Instance.Toast(new ToastConfig("El registro ha sido actualizado").SetIcon("ghost32"));
                await PopupNavigation.PopAllAsync();
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                UserDialogs.Instance.Toast(new ToastConfig("Ha ocurrido un error al actualizar el registro").SetIcon("ghost32"));
                await PopupNavigation.PopAllAsync();

            }
        }
        public async void dispose()
        {
            await PopupNavigation.PopAllAsync();
        }
        #endregion



    }
}
