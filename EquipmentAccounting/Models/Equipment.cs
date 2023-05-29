using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentAccounting.Models
{
    [Table("Equipments")]
    public class Equipment
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string EquipmentNumber { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentPlace { get; set; }
        public string Commentary { get; set; }
    }
}
