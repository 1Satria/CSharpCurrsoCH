using System;
using System.Collections.Generic;

namespace CoderHouseProyectoFinal.models
{
    public partial class Ventum
    {
        public Ventum()
        {
            ProductoVendidos = new HashSet<ProductoVendido>();
        }

        public long Id { get; set; }
        public string? Comentarios { get; set; }
        public long IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<ProductoVendido> ProductoVendidos { get; set; }
    }
}
