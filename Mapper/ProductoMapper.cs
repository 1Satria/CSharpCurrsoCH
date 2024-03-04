using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.models;

namespace CoderHouseProyectoFinal.Mapper
{
    public static class ProductoMapper
    {
        public static ProductoDTO MappearAProductoDTO(Producto prod) 
        {
            ProductoDTO productoDTO = new ProductoDTO();
            productoDTO.Descripciones = prod.Descripciones;
            productoDTO.PrecioVenta = prod.PrecioVenta;
            productoDTO.Costo = prod.Costo;
            productoDTO.Stock = prod.Stock;
            productoDTO.IdUsuario = prod.IdUsuario;
            return productoDTO;
        }
        public static Producto MappearAProducto(ProductoDTO productoDTO) 
        {
            Producto producto = new Producto();
            producto.Descripciones = productoDTO.Descripciones;
            producto.PrecioVenta = productoDTO.PrecioVenta;
            producto.Costo = productoDTO.Costo;
            producto.Stock= productoDTO.Stock;
            producto.IdUsuario= productoDTO.IdUsuario;
            return producto;
        } 
    }
}
