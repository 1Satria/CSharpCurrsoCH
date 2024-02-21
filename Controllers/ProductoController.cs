using CoderHouseProyectoFinal.Business;
using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.Mapper;
using CoderHouseProyectoFinal.models;
using Microsoft.AspNetCore.Mvc;

namespace CoderHouseProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        [HttpGet("listarProducto")]
        public List<Producto> obtenerListaProducto()
        {
            return ProductoBusiness.GetAllProducts();
        }
        [HttpGet("GetProducto/{id}")]
        public Producto obtenerProductoId(int id)
        {
            return ProductoBusiness.GetProduct(id);
        }
        [HttpPost("AgregarProducto")]
        public IActionResult agregarProducto([FromBody] ProductoDTO prodDTO)
        {
            Producto ProductoMapeado = ProductoMapper.MappearAProducto(prodDTO);
            if (ProductoBusiness.CreateProduct(ProductoMapeado))
            {
                return Ok(new { Menssaje = "Se creo el Producto" });
            }
            else
            {
                return base.Conflict(new { Mensaje = "No se creo el Producto" });
            }
        }
        [HttpDelete("BorrarProducto/{id}")]
        public IActionResult borrarProducto(int id)
        {

            if (ProductoBusiness.DeleteProduct(id))
            {
                return Ok(new { Mensaje = "Se elimino al Producto" });
            }
            else
            {
                return base.Conflict(new { Mensaje = "No se pudo eliminar al Producto" });
            }
        }
        [HttpPut("ActualizarProducto/{id}")]
        public IActionResult ActualizarProducto(ProductoDTO prodDTO, int id)
        {
            if (id > 0)
            {
                Producto ProductoMapeado = ProductoMapper.MappearAProducto(prodDTO);
                if (ProductoBusiness.UpdateProduct(ProductoMapeado, id))
                {
                    return base.Ok(new { Mensaje = "Producto Actualizado" });
                }
                return base.Conflict(new { Mensaje = "No se pudo Actualizar el producto" });

            }
            return base.BadRequest(new { Mensaje = "El id no puede ser negativo" });
        }
    }
}
