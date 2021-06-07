using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Lab14.Models;
using Lab14.Services;
using Xamarin.Forms;

namespace Lab14.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        #region Services
        private readonly DBDataAccess<User> _dataServiceUsers;
        #endregion Services
        
        #region Attributes
        private ObservableCollection<User> _users;
        private string _username;
        private string _password;
        private DateTime _dateBirth;
        private bool _authenticated;
        #endregion Attributes
        
        #region Properties

        public ObservableCollection<User> Users
        {
            get => this._users;
            set => SetValue(ref this._users, value);
        }

        public string Username
        {
            get => this._username;
            set => SetValue(ref this._username, value);
        }

        public string Password
        {
            get => this._password;
            set => SetValue(ref this._password, value);
        }

        public DateTime DateBirth
        {
            get => this._dateBirth;
            set => SetValue(ref this._dateBirth, value);
        }

        public bool Authenticated
        {
            get => this._authenticated;
            set => SetValue(ref this._authenticated, value);
        }

        #endregion Properties
        
        #region Constructor

        public UsersViewModel()
        {
            this._dataServiceUsers = new DBDataAccess<User>();
            this.LoadUsers();
        }
        
        #endregion Constructor
        #region Commands

        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newUser = new User()
                    {
                        Username = this._username,
                        Password = this._password,
                        DateBirth = this._dateBirth,
                        Authenticated = this._authenticated
                    };

                    if (this._dataServiceUsers.Create(newUser))
                    {
                        await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                            $"Usuario " +
                            $"creado correctamente en la base de datos",
                            "Ok");

                        this.Username = "";
                        this.Password = "";
                        this.DateBirth = new DateTime();
                        this.Authenticated = false;
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                            $"Error al crear el Usuario en la base de datos",
                            "Ok");
                });
            }
        }
        #endregion Commands
        
        #region Methods

        private void LoadUsers()
        {
            var usersDb = this._dataServiceUsers.Get().ToList() as List<User>;
            this._users = new ObservableCollection<User>(usersDb);
        }

        #endregion
    }
}