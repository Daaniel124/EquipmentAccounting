using EquipmentAccounting.Models;
using EquipmentAccounting.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EquipmentAccounting.ViewModels
{
    public class EquipmentsListViewModel
    {
        private int totalBooksCount;
        public int TotalBooksCount
        {
            get { return totalBooksCount; }
            set
            {
                if (totalBooksCount != value)
                {
                    totalBooksCount = value;
                    OnPropertyChanged("TotalBooksCount");
                }
            }
        }

        private int readBooksCount;
        public int ReadBooksCount
        {
            get { return readBooksCount; }
            set
            {
                if (readBooksCount != value)
                {
                    readBooksCount = value;
                    OnPropertyChanged("ReadBooksCount");
                }
            }
        }

        private int unreadBooksCount;
        public int UnreadBooksCount
        {
            get { return unreadBooksCount; }
            set
            {
                if (unreadBooksCount != value)
                {
                    unreadBooksCount = value;
                    OnPropertyChanged("UnreadBooksCount");
                }
            }
        }
        private void UpdateBooksCounts()
        {
            TotalBooksCount = App.DataBase.GetItems().Count();
        }

        public ObservableCollection<EquipmentViewModel> Books { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateBookCommand { protected set; get; }
        public ICommand DeleteBookCommand { protected set; get; }
        public ICommand SaveBookCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        EquipmentViewModel selectedBook;
        public INavigation Navigation { get; set; }
        public EquipmentsListViewModel()
        {
            Books = new ObservableCollection<EquipmentViewModel>();
            CreateBookCommand = new Command(CreateBook);
            DeleteBookCommand = new Command(DeleteBook);
            SaveBookCommand = new Command(SaveBookAsync);
            BackCommand = new Command(Back);
        }
        public EquipmentViewModel SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (selectedBook != value)
                {
                    EquipmentViewModel tempBook = value;
                    selectedBook = null;
                    OnPropertyChanged("SelectedBook");
                    Navigation.PushAsync(new BookPage(tempBook));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateBook()
        {
            Navigation.PushAsync(new BookPage(new EquipmentViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveBookAsync(object bookObject)
        {
            EquipmentViewModel book = bookObject as EquipmentViewModel;
            if (book != null && book.IsValid && !Books.Contains(book))
            {
                Books.Add(book);
            }
            SendSheets(bookObject as EquipmentViewModel);

            Back();
        }

        async void SendSheets(object dataObject)
        {
            var client = new HttpClient();
            var model = dataObject;
            var uri = "https://script.google.com/macros/s/AKfycbzum_bRbjihAvEKnolsaT54csNtC0DMUQh0K6LIbN3HrF3L15Po/exec";
            var jsonString = JsonConvert.SerializeObject(model);
            var requestContent = new StringContent(jsonString);
            var result = await client.PostAsync(uri, requestContent);
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseModel>(resultContent);
        }
        private void DeleteBook(object bookObject)
        {
            EquipmentViewModel book = bookObject as EquipmentViewModel;
            if (book != null)
            {
                Books.Remove(book);
            }
            Back();
        }
    }
}
