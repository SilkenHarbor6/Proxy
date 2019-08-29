using Acr.UserDialogs;
using Android.Widget;
using DLL.Model;
using DLL.Pattern;
using GalaSoft.MvvmLight.Command;
using Proxy.Class;
using Proxy.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proxy.ViewModel
{
    public class MainPageViewModel:BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Persona> _Lpersonas;
        private bool isRefresh;
        private Persona p;
        #endregion
        #region Propiedades
        public ObservableCollection<Persona> Lpersonas
        {
            get
            {
                return _Lpersonas;
            }
            set
            {
                if (_Lpersonas==value)
                {
                    return;
                }
                _Lpersonas = value;
                OnPropertyChanged("Lpersonas");
            }
        }
        public Persona Persona
        {
            get
            {
                return p;
            }
            set
            {
                p = value;OnPropertyChanged("Persona");SendToMenu() ;
            }
        }
        public bool IsRefreshing
        {
            get
            {
                return isRefresh;
            }
            set
            {
                if (isRefresh==value)
                {
                    return;
                }
                isRefresh = value;OnPropertyChanged("IsRefreshing");
            }
        }
        #endregion
        #region Constructor
        public MainPageViewModel()
        {
            Lpersonas = new ObservableCollection<Persona>();
            getLista();
        }
        #endregion
        #region Comandos
        public ICommand Refresh
        {
            get
            {
                return new RelayCommand(getLista);
            }
        }
        public ICommand New
        {
            get
            {
                return new RelayCommand(SendToAdd);
            }
        }
        public ICommand Close
        {
            get
            {
                return new RelayCommand(dispose);
            }
        }
        #endregion
        #region Metodos
        public void getLista()
        {
            isRefresh = false;
            IRepository datos = new ProxyRepository();
            var tlista = new ObservableCollection<Persona>();
            datos.GetAll().ForEach(item=>tlista.Add(item));
            Lpersonas = tlista;

        }
        public void SendToAdd()
        {
            App.Current.MainPage.Navigation.PushAsync(new addPage());
        }
        public void SendToMenu()
        {
            PopupNavigation.PushAsync(new MenuP(Persona));
        }
        public async void dispose()
        {
            UserDialogs.Instance.Toast(new ToastConfig("La aplicacion se cerrara en 3 segundos"));
            await Task.Delay(1000);
            UserDialogs.Instance.Toast(new ToastConfig("La aplicacion se cerrara en 2 segundos"));
            await Task.Delay(1000);
            UserDialogs.Instance.Toast(new ToastConfig("La aplicacion se cerrara en 1 segundo"));
            await Task.Delay(1000);
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
        #endregion
    }
}
