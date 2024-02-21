namespace CoderHouseProyectoFinal.DTOs
{
    public class ProductoVendidoDTO
    {
        public long Id { get; set; }
        public int Stock { get; set; }
        public long IdProducto { get; set; }
        public long IdVenta { get; set; }
    }
}
