using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyectoaviones.Models
{
    public class Vuelos
    {
        [PrimaryKey]
        public string _id { get; set; }
        public string aerolinea { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string hora { get; set; }
        public string fecha { get; set; }
        public string horallegada { get; set; }
        public string fechallegada { get; set; }
        public string numeroasientos { get; set; }
    }
}
