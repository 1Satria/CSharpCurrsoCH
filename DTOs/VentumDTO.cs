using CoderHouseProyectoFinal.models;

namespace CoderHouseProyectoFinal.DTOs
{
    public class VentumDTO
    {
        public long Id { get; set; }
        public string? Comentarios { get; set; }
        public long IdUsuario { get; set; }
    }
}
