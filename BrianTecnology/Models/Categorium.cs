using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrianTecnology.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
