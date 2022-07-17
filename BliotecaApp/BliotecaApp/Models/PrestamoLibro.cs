using System;
using System.Collections.Generic;

#nullable disable

namespace BliotecaApp.Models
{
    public partial class PrestamoLibro
    {
        public int PrestamoLibroId { get; set; }
        public int PrestamoId { get; set; }
        public int LibroId { get; set; }

        public virtual Libro Libro { get; set; }
        public virtual Prestamo Prestamo { get; set; }
    }
}
