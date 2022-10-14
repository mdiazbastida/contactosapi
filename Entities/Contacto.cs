using System;
using System.Collections.Generic;

namespace ContactoApi.Entities
{
    public partial class Contacto
    {
        public int ContactoId { get; set; }
        public string Contacto1 { get; set; }
        public int? Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
