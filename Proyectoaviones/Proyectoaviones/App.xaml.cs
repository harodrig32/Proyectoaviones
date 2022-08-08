using Proyectoaviones.Data;
using Proyectoaviones.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectoaviones
{
    public partial class App : Application
    {
        private static DatabaseContext context;

        public static DatabaseContext Context
        {
            get
            {
                if (context == null)
                {
                    var dbPath = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "HarryPotterDB.db3");

                    context = new DatabaseContext(dbPath);
                }

                return context;
            }
        }
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new Views.menu());
           MainPage = new menu();
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
