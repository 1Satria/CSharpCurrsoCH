using CoderHouseProyectoFinal.Business;
using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.Mapper;
using CoderHouseProyectoFinal.models;
using Microsoft.AspNetCore.Mvc;

namespace CoderHouseProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentumController : Controller
    {
        [HttpGet("listarVentas")]
        public List<Ventum> obtenerListaVentas()
        {
            return VentaBusiness.GetAllVentum();
        }
        [HttpGet("GetVenta/{id}")]
        public Ventum obtenerVentaId(int id)
        {
            return VentaBusiness.GetVentum(id);
        }
        [HttpPost("AgregarVenta")]
        public IActionResult agregarVenta([FromBody] VentumDTO VentaDTO)
        {
            Ventum VentaMapeado = VentumMapper.MappearAVentum(VentaDTO);
            if (VentaBusiness.CreateVentum(VentaMapeado))
            {
                return Ok(new { Menssaje = "Se creo la Venta" });
            }
            else
            {
                return base.Conflict(new { Mensaje = "No se creo la Venta" });
            }
        }
        [HttpDelete("BorrarVenta/{id}")]
        public IActionResult borrarVenta(int id)
        {

            if (VentaBusiness.DeleteVentum(id))
            {
                return Ok(new { Mensaje = "Se elimino la Venta" });
            }
            else
            {
                return base.Conflict(new { Mensaje = "No se pudo eliminar la Venta" });
            }
        }
        [HttpPut("ActualizarVenta/{id}")]
        public IActionResult ActualizarVenta(VentumDTO VentaDTO, int id)
        {
            if (id > 0)
            {
                Ventum VentaMapeado = VentumMapper.MappearAVentum(VentaDTO);
                if (VentaBusiness.UpdateVentum(VentaMapeado, id))
                {
                    return base.Ok(new { Mensaje = "Venta Actualizada" });
                }
                return base.Conflict(new { Mensaje = "No se pudo Actualizar la Venta" });

            }
            return base.BadRequest(new { Mensaje = "El id no puede ser negativo" });
        }
    }
}
