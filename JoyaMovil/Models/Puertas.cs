using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JoyaMovil.Models
{
    public class Puertas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nameDoor { get; set; }
        public string formato { get; set; }
    }
}
