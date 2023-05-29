using EquipmentAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EquipmentAccounting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBBookPage : ContentPage
    {
        public DBBookPage()
        {
            InitializeComponent();
        }
        private void SaveBook(object sender, EventArgs e)
        {
            var book = (Equipment)BindingContext;
            if (!String.IsNullOrEmpty(book.EquipmentNumber))
            {
                App.DataBase.SaveItem(book);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteBook(object sender, EventArgs e)
        {
            var book = (Equipment)BindingContext;
            App.DataBase.DeleteItem(book.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}