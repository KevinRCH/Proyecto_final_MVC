using System;
using System.Collections.Generic;

#nullable disable

namespace BliotecaApp.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            PrestamoLibros = new HashSet<PrestamoLibro>();
        }

        public int PrestamoId { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int ClienteId { get; set; }
        public int? PrestamoLibro { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<PrestamoLibro> PrestamoLibros { get; set; }
    }
}
