using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyectoaviones.Models
{
    public class Ventas
    {
        [PrimaryKey]
        public string _id { get; set; }
        public string idvuelo { get; set; }
        public string cliente { get; set; }
        public string cantidad { get; set; }
        public string precio { get; set; }
        public string total { get; set; }

    }
}
