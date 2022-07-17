using System;
using System.Collections.Generic;

#nullable disable

namespace BliotecaApp.Models
{
    public partial class Libro
    {
        public Libro()
        {
            PrestamoLibros = new HashSet<PrestamoLibro>();
        }

        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public int? Ejemplares { get; set; }
        public int? PrestamoLibro { get; set; }

        public virtual ICollection<PrestamoLibro> PrestamoLibros { get; set; }
    }
}
