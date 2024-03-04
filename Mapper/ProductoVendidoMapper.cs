using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.models;

namespace CoderHouseProyectoFinal.Mapper
{
    public static class ProductoVendidoMapper
    {
        //Id  Stock IdProducto IdVenta
        public static ProductoVendido MappearAProductoVendido(ProductoVendidoDTO prodVendidoDTO)
        {
            ProductoVendido prodVendido = new ProductoVendido();
            prodVendido.IdProducto = prodVendidoDTO.IdProducto;
            prodVendido.Id = null;
            prodVendido.IdVenta = prodVendidoDTO.IdVenta;
            prodVendido.Stock = prodVendidoDTO.Stock;
            return prodVendido;
        }
        public static ProductoVendidoDTO MappearAProductoVeendidoDTO(ProductoVendido prodVendido) 
        {
            ProductoVendidoDTO prodVendidoDTO = new ProductoVendidoDTO();
            prodVendidoDTO.IdProducto = prodVendido.IdProducto;
            prodVendidoDTO.Id = null;
            prodVendidoDTO.IdVenta = prodVendido.IdVenta;
            prodVendidoDTO.Stock = prodVendido.Stock;
            
            return prodVendidoDTO;

        }
    }
}
