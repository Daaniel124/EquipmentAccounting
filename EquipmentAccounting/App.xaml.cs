using EquipmentAccounting.Models;
using EquipmentAccounting.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EquipmentAccounting
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "accounting.db";
        public static EquipmentRepository database;
        public static EquipmentRepository DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new EquipmentRepository
                        (Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
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
