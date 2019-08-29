using Acr.UserDialogs;
using DLL.Model;
using DLL.Pattern;
using GalaSoft.MvvmLight.Command;
using Proxy.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proxy.ViewModel
{
    public class MenuPViewModel
    {
        #region Atributos
        private Persona _Persona;
        #endregion
        #region Propiedades
        
        #endregion
        #region Constructor
        public MenuPViewModel(Persona item)
        {
            _Persona = item;
        }
        #endregion
        #region Comandos
        public ICommand Eliminar
        {
            get
            {
                return new RelayCommand(Delete);
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
        public async void Delete()
        {
            ConfirmConfig conf = new ConfirmConfig();
            conf.CancelText = "NO WAY";
            conf.OkText = "JUST DO IT!!";
            conf.Message = "R U SURE??";
            conf.Title = "SNAP IT??!!";

            var resp =await UserDialogs.Instance.ConfirmAsync(conf);
            if (resp)
            {
                SingletonRepository.Instancia.Repository.PersonOperation(_Persona, Facade.Operacion.Delete);
                UserDialogs.Instance.Toast(new ToastConfig("El registro ha sido eliminado").SetIcon("ghost.png"));
                await PopupNavigation.PopAllAsync();
                App.Current.MainPage = new NavigationPage(new MainPage());
                
            }
            else
            {
                PopupNavigation.PopAllAsync();
                UserDialogs.Instance.Toast(new ToastConfig("Operacion Cancelada").SetIcon("ghost32.png").SetPosition(ToastPosition.Bottom));
            }
            
        }
        public void Put()
        {
            PopupNavigation.PushAsync(new Edit(_Persona));
        }
        #endregion
    }
}
