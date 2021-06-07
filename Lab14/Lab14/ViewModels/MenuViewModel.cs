using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lab14.Models;
using Lab14.Services;

namespace Lab14.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MenuOptionViewModel> _menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuOptionViewModel> Menu
        {
            get => this._menu;
            set => SetValue(ref this._menu, value);
        }
        #endregion Properties

        #region Constructor
        public MenuViewModel()
        {
            this.LoadMenu();
            //this.SaveUsersList();
        }
        #endregion Constructor

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuOptionViewModel>();

            this.Menu.Clear();
            this.Menu.Add(new MenuOptionViewModel { Id = 1, Option = "Crear" });
            this.Menu.Add(new MenuOptionViewModel { Id = 2, Option = "Lista de Registros" });
        }
        #endregion Methods
        
        // METIENDO DATOS DE PRUEBA PARA EL LISTADO
        DBDataAccess<User> dataService = new DBDataAccess<User>();
        private void SaveUsersList()
        {
            var users = new List<User>()
            {
                new User
                {
                    Username = "Gblanco", 
                    Password = "tecsup123", 
                    DateBirth = new DateTime(2002,1,14),
                    Authenticated = true
                },
            };

            dataService.SaveList(users);
        }
    }
}