using EquipmentAccounting.ViewModels;
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
    public partial class BooksListPage : ContentPage
    {
        public BooksListPage()
        {
            InitializeComponent();
            BindingContext = new EquipmentsListViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}