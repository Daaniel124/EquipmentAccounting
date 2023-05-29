using EquipmentAccounting.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EquipmentAccounting
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /*async void SubmitButton_Pressed(System.Object sender, System.EventArgs e)
        {
            var client = new HttpClient();
            var model = new Equipment()
            {
                EquipmentNumber = EquipmentNumber.Text,
                EquipmentType = PhoneEntry.Text,
                EquipmentPlace = EmailEntry.Text,
                Commentary = FeedbackEntry.Text
            };
            var uri = "";
            var jsonString = JsonConvert.SerializeObject(model);
            var requestContent = new StringContent(jsonString);
            var result = await client.PostAsync(uri, requestContent);
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel>(resultContent);
        }*/

        /*private void ProcessResponse(ResponseModel responseModel)
        {
            ResultLabel.IsVisible = true;
            ResultLabel.Text = responseModel.Message;
            if (responseModel.Status == "SUCCESS")
                ResultLabel.TextColor = Color.Black;
            else
                ResultLabel.TextColor = Color.Red;
        }*/

        /*https://github.com/saamerm/Xamarin-GoogleSheetsDB/blob/master/XamarinGoogleSheetsDB/ResponseModel.cs
         https://medium.com/the-kickstarter/storedataingooglesheetsusingxamarin-ed8ba5c4b1bc*/
    }
}
