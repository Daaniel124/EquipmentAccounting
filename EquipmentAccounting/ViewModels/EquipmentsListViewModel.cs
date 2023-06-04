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
        private int totalEquipmentsCount;
        public int TotalEquipmentsCount
        {
            get { return totalEquipmentsCount; }
            set
            {
                if (totalEquipmentsCount != value)
                {
                    totalEquipmentsCount = value;
                    OnPropertyChanged("TotalEquipmentsCount");
                }
            }
        }

        private int readEquipmentsCount;
        public int ReadEquipmentsCount
        {
            get { return readEquipmentsCount; }
            set
            {
                if (readEquipmentsCount != value)
                {
                    readEquipmentsCount = value;
                    OnPropertyChanged("ReadEquipmentsCount");
                }
            }
        }

        private int unreadEquipmentsCount;
        public int UnreadEquipmentsCount
        {
            get { return unreadEquipmentsCount; }
            set
            {
                if (unreadEquipmentsCount != value)
                {
                    unreadEquipmentsCount = value;
                    OnPropertyChanged("UnreadEquipmentsCount");
                }
            }
        }
        private void UpdateEquipmentsCounts()
        {
            TotalEquipmentsCount = App.DataBase.GetItems().Count();
        }

        public ObservableCollection<EquipmentViewModel> Equipments { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateEquipmentCommand { protected set; get; }
        public ICommand DeleteEquipmentCommand { protected set; get; }
        public ICommand SaveEquipmentCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        EquipmentViewModel selectedEquipment;
        public INavigation Navigation { get; set; }
        public EquipmentsListViewModel()
        {
            Equipments = new ObservableCollection<EquipmentViewModel>();
            CreateEquipmentCommand = new Command(CreateEquipment);
            DeleteEquipmentCommand = new Command(DeleteEquipment);
            SaveEquipmentCommand = new Command(SaveEquipment);
            BackCommand = new Command(Back);
        }
        public EquipmentViewModel SelectedEquipment
        {
            get { return selectedEquipment; }
            set
            {
                if (selectedEquipment != value)
                {
                    EquipmentViewModel tempEquipment = value;
                    selectedEquipment = null;
                    OnPropertyChanged("SelectedEquipment");
                    Navigation.PushAsync(new EquipmentPage(tempEquipment));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void CreateEquipment()
        {
            Navigation.PushAsync(new EquipmentPage(new EquipmentViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveEquipment(object equipmentObject)
        {
            EquipmentViewModel equipment = equipmentObject as EquipmentViewModel;
            if (equipment != null && equipment.IsValid && !Equipments.Contains(equipment))
            {
                Equipments.Add(equipment);
            }

            Back();
        }

        
        private void DeleteEquipment(object equipmentObject)
        {
            EquipmentViewModel equipment = equipmentObject as EquipmentViewModel;
            if (equipment != null)
            {
                Equipments.Remove(equipment);
            }
            Back();
        }
    }
}
