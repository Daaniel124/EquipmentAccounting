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
        public Equipment equipment { get; private set; }
        public EquipmentViewModel()
        {
            equipment = new Equipment();
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
            get { return equipment.EquipmentNumber; }
            set
            {
                if (equipment.EquipmentNumber != value)
                {
                    equipment.EquipmentNumber = value;
                    OnPropertyChanged("EquipmentNumber");
                }
            }
        }
        public string EquipmentType
        {
            get { return equipment.EquipmentType; }
            set
            {
                if (equipment.EquipmentType != value)
                {
                    equipment.EquipmentType = value;
                    OnPropertyChanged("EquipmentType");
                }
            }
        }

        public string EquipmentPlace
        {
            get { return equipment.EquipmentPlace; }
            set
            {
                if (equipment.EquipmentPlace != value)
                {
                    equipment.EquipmentPlace = value;
                    OnPropertyChanged("EquipmentPlace");
                }
            }
        }

        public string Commentary
        {
            get { return equipment.Commentary; }
            set
            {
                if (equipment.Commentary != value)
                {
                    equipment.Commentary = value;
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
