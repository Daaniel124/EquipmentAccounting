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
            viewModel.TotalBooksCount = App.DataBase.GetItems().Count();

            BindingContext = viewModel;
            booksList.ItemsSource = App.DataBase.GetItems();

            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Equipment selectedBook = (Equipment)e.SelectedItem;
            DBBookPage bookPage = new DBBookPage();
            bookPage.BindingContext = selectedBook;
            await Navigation.PushAsync(bookPage);
        }

        private async void CreateBook(object sender, EventArgs e)
        {
            Equipment book = new Equipment();
            DBBookPage bookPage = new DBBookPage();
            bookPage.BindingContext = book;

            await Navigation.PushAsync(bookPage);
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var book = cell?.BindingContext as Equipment;

            if (book != null)
                cell.View.BackgroundColor = Color.Green;
            else
                cell.View.BackgroundColor = Color.Red;

            cell.ForceUpdateSize();
        }
    }
}