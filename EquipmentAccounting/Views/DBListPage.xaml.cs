using EquipmentAccounting.Models;
using EquipmentAccounting.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EquipmentAccounting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var viewModel = new EquipmentsListViewModel();
            viewModel.TotalEquipmentsCount = App.DataBase.GetItems().Count();

            BindingContext = viewModel;
            equipmentsList.ItemsSource = App.DataBase.GetItems();

            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Equipment selectedEquipment = (Equipment)e.SelectedItem;
            DBEquipmentPage equipmentPage = new DBEquipmentPage();
            equipmentPage.BindingContext = selectedEquipment;
            await Navigation.PushAsync(equipmentPage);
        }

        private async void CreateEquipment(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            DBEquipmentPage equipmentPage = new DBEquipmentPage();
            equipmentPage.BindingContext = equipment;

            await Navigation.PushAsync(equipmentPage);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var equipment = cell?.BindingContext as Equipment;

            if (equipment != null)
                cell.View.BackgroundColor = Color.Green;
            else
                cell.View.BackgroundColor = Color.Red;

            cell.ForceUpdateSize();
        }
    }
}