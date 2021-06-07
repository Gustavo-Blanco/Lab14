using System.Windows.Input;
using Lab14.Views;
using Xamarin.Forms;

namespace Lab14.ViewModels
{
    public class MenuOptionViewModel
    {
        #region Attributes
        public int Id { get; set; }
        public string Option { get; set; }
        #endregion Attributes
        
        #region Commands
        public ICommand SelectMenuItemCommand => new Command(SelectMenuItemExecute);
        #endregion Commands
        
        #region Methods
        private void SelectMenuItemExecute()
        {
            if(this.Id == 1)
                Application.Current.MainPage.Navigation.PushAsync(new AddUserPage());
            else
                Application.Current.MainPage.Navigation.PushAsync(new UsersPage());
        }
        #endregion Methods
    }
}