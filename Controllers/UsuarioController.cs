using CoderHouseProyectoFinal.Business;
using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.Mapper;
using CoderHouseProyectoFinal.models;
using CoderHouseProyectoFinal.service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoderHouseProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet("listarUsuarios")]
        public List<Usuario> obtenerListaUsuarios()
        {
            return UsuarioBusiness.GetAllUsers();
        }

        [HttpGet("GetUsuario/{id}")]
        public Usuario obtenerUsuarioId(int id) 
        {
            return UsuarioBusiness.GetUser(id);
        }

        [HttpGet("GetUsuario/{Username}")]
        public Usuario obtenerUsuarioId(string Username)
        {
            return UsuarioBusiness.GetUserByUsername(Username);
        }

        [HttpPost("AgregarUsuario")]
        public IActionResult agregarUsuario([FromBody]UsuarioDTO userDTO) 
        {
            Usuario usuarioMapeado = UsuarioMapper.MappearAUsuario(userDTO);
            if (UsuarioBusiness.CreateUser(usuarioMapeado))
            {
                return Ok(new { Menssaje = "Se creo el usuario" });
            }
            else 
            {
                return base.Conflict(new { Mensaje = "No se creo el usuario" });
            }
        }
        [HttpGet("{usuario}/{password}")]

        public ActionResult<Usuario> ObtenerUsuarioPorNombreYPassword(string usuario, string password)
        {
            try
            {

                return UsuarioService.ObtenerUsuarioPorUsuarioYPassword(usuario, password);
            }
            catch (Exception ex)
            {
                return base.Conflict(new { error = ex.Message, status = HttpStatusCode.InternalServerError });
            }
            
            


        }
        [HttpDelete("BorrarUsuario/{id}")]
        public IActionResult borrarUsuario(int id) 
        {

            if (UsuarioBusiness.DeleteUser(id))
            {
                return Ok(new { Mensaje = "Se elimino al usuario" });
            }
            else 
            {
                return base.Conflict(new { Mensaje = "No se pudo eliminar al usuario" });
            }
        }
        [HttpPut("ActualizarUsuario/{id}")]
        public IActionResult ActualizarUsuario(UsuarioDTO userDTO,int id)
        {
            if (id > 0)
            {
                Usuario usuarioMapeado = UsuarioMapper.MappearAUsuario(userDTO);
                if (UsuarioBusiness.UpdateUser(usuarioMapeado,id))
                {
                    return base.Ok(new { Mensaje = "Usuario Actualizado" });
                }
                return base.Conflict(new { Mensaje = "No se pudo Actualizar el Usuario" });

            }
            return base.BadRequest(new { Mensaje = "El id no puede ser negativo" });
        }




    }
}


