using CoderHouseProyectoFinal.Business;
using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.Mapper;
using CoderHouseProyectoFinal.models;
using Microsoft.AspNetCore.Mvc;

namespace CoderHouseProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        [HttpGet("listarProductoVendido")]
        public List<ProductoVendido> obtenerListaProductoVendido()
        {
            return ProductoVendidoBusiness.GetAllSoldProducts();
        }
        [HttpGet("GetProductoVendido/{id}")]
        public ProductoVendido obtenerProductoVendidoId(int id)
        {
            return ProductoVendidoBusiness.GetSoldProduct(id);
        }
        [HttpPost("AgregarProductoVendido")]
        public IActionResult agregarProductoVendido([FromBody] ProductoVendidoDTO prodVendidoDTO)
        {
            ProductoVendido ProductoVendidoMapeado = ProductoVendidoMapper.MappearAProductoVendido(prodVendidoDTO);
            if (ProductoVendidoBusiness.CreateSoldProduct(ProductoVendidoMapeado))
            {
                return Ok(new { Menssaje = "Se creo el Producto Vendido" });
            }
            else
            {
                return base.Conflict(new { Mensaje = "No se creo el Producto Vendido" });
            }
        }
        [HttpDelete("BorrarProductoVendido/{id}")]
        public IActionResult borrarProductoVendido(int id)
        {

            if (ProductoVendidoBusiness.DeleteSoldProduct(id))
            {
                return Ok(new { Mensaje = "Se elimino al Producto Vendido" });
            }
            else
            {
                return base.Conflict(new { Mensaje = "No se pudo eliminar al Producto Vendido" });
            }
        }
        [HttpPut("ActualizarProductoVendido/{id}")]
        public IActionResult ActualizarProductoVendido(ProductoVendidoDTO prodVendidoDTO, int id)
        {
            if (id > 0)
            {
                ProductoVendido ProductoVendidoMapeado = ProductoVendidoMapper.MappearAProductoVendido(prodVendidoDTO);
                if (ProductoVendidoBusiness.UpdateSoldProduct(ProductoVendidoMapeado, id))
                {
                    return base.Ok(new { Mensaje = "Producto Vendido Actualizado" });
                }
                return base.Conflict(new { Mensaje = "No se pudo Actualizar el Producto Vendido" });

            }
            return base.BadRequest(new { Mensaje = "El id no puede ser negativo" });
        }
    }
}
