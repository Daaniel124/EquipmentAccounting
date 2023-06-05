using EquipmentAccounting.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;
using static System.Net.Mime.MediaTypeNames;

namespace EquipmentAccounting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBEquipmentPage : ContentPage
    {
        public DBEquipmentPage()
        {
            InitializeComponent();
        }
        private async void SaveBook(object sender, EventArgs e)
        {
            var equipment = (Equipment)BindingContext;
            if (!String.IsNullOrEmpty(equipment.EquipmentNumber))
            {
                App.DataBase.SaveItem(equipment);
            }

            var client = new HttpClient();
            var uri = "https://script.google.com/macros/s/AKfycbwY5fvBZVjN3w-vbYYjp8Nuqfze-maQu-UJtjLMGk-u5OEjY56XPB1YrKGe-qBOuJ8/exec";
            var jsonString = JsonConvert.SerializeObject(equipment);
            var requestContent = new StringContent(jsonString);
            //var content = 
            var result = await client.PostAsync(uri, requestContent);
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel>(resultContent);
            ProcessResponse(response);

            this.Navigation.PopAsync();
        }
        private async void DeleteBook(object sender, EventArgs e)
        {
            var equipment = (Equipment)BindingContext;
            App.DataBase.DeleteItem(equipment.Id);

            /*var client = new HttpClient();
            var uri = "https://script.google.com/macros/s/AKfycbwY5fvBZVjN3w-vbYYjp8Nuqfze-maQu-UJtjLMGk-u5OEjY56XPB1YrKGe-qBOuJ8/exec";
            var jsonString = JsonConvert.SerializeObject(equipment);
            var requestContent = new StringContent(jsonString);

            var parameters = $"?jsonString={Uri.EscapeDataString(jsonString)}";
            var requestUrl = uri + parameters;
            var result = await client.DeleteAsync(requestUrl);
            //var result = await client.DeleteAsync(uri, requestContent);
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel>(resultContent);
            ProcessResponse(response);*/

            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void ProcessResponse(ResponseModel responseModel)
        {
            ResultLabel.IsVisible = true;
            ResultLabel.Text = responseModel.Message;
            /*if (responseModel.Status == "SUCCESS")
                ResultLabel.TextColor = Color.Black;
            else
                ResultLabel.TextColor = Color.Red;*/
            DisplayAlert("Статус: " + responseModel.Status, responseModel.Message, "Ok");
        }
    }
}