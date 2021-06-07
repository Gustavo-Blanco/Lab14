using System;
using System.IO;
using Lab14.Interfaces;
using Lab14.iOS.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigDataBase))]
namespace Lab14.iOS.Implementations
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", 
                databaseFileName);
        }
    }
}