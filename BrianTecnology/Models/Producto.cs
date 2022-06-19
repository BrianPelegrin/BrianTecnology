using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrianTecnology.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "El campo marca es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "El campo Stock es obligatorio")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "El campo Categoria es obligatorio")]
        public int? IdCategoria { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
    }
}
