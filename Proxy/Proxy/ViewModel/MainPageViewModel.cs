using DLL.Model;
using DLL.Pattern;
using GalaSoft.MvvmLight.Command;
using Proxy.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Proxy.ViewModel
{
    public class MainPageViewModel:BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Persona> _Lpersonas;
        private bool isRefresh;
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
                return Persona;
            }
            set
            {
                Persona = value;OnPropertyChanged("Persona");
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
        #endregion
    }
}
