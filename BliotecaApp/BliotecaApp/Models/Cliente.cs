using System;
using System.Collections.Generic;

#nullable disable

namespace BliotecaApp.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
