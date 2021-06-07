using System;
using Lab14.DataCenter;
using Lab14.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab14
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage(new Views.MainPage());
        }
        
        public static AppDbContext GetContext()
        {
            string dbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("efCore.db");

            return new AppDbContext(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
        }
    }
}
