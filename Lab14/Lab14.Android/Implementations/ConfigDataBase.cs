using System.IO;
using Lab14.Droid.Implementations;
using Lab14.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigDataBase))]
namespace Lab14.Droid.Implementations
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), 
                databaseFileName);
        }
    }
}