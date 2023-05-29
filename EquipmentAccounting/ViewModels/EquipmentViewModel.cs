using EquipmentAccounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EquipmentAccounting.ViewModels
{
    public class EquipmentViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        EquipmentsListViewModel lvm;
        public Equipment Book { get; private set; }
        public EquipmentViewModel()
        {
            Book = new Equipment();
        }
        public EquipmentsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string EquipmentNumber
        {
            get { return Book.EquipmentNumber; }
            set
            {
                if (Book.EquipmentNumber != value)
                {
                    Book.EquipmentNumber = value;
                    OnPropertyChanged("EquipmentNumber");
                }
            }
        }
        public string EquipmentType
        {
            get { return Book.EquipmentType; }
            set
            {
                if (Book.EquipmentType != value)
                {
                    Book.EquipmentType = value;
                    OnPropertyChanged("EquipmentType");
                }
            }
        }

        public string EquipmentPlace
        {
            get { return Book.EquipmentPlace; }
            set
            {
                if (Book.EquipmentPlace != value)
                {
                    Book.EquipmentPlace = value;
                    OnPropertyChanged("EquipmentPlace");
                }
            }
        }

        public string Commentary
        {
            get { return Book.Commentary; }
            set
            {
                if (Book.Commentary != value)
                {
                    Book.Commentary = value;
                    OnPropertyChanged("wasRead");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(EquipmentNumber.Trim())) ||
                     (!string.IsNullOrEmpty(EquipmentType.Trim())) ||
                     (!string.IsNullOrEmpty(EquipmentPlace.Trim())) ||
                     (!string.IsNullOrEmpty(Commentary.Trim())));

            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
