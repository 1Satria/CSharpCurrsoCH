using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.models;

namespace CoderHouseProyectoFinal.Mapper
{
    public static class UsuarioMapper
    {

        public static UsuarioDTO MappearAUsuarioDTO(Usuario usuario) 
        {
            UsuarioDTO userDTO = new UsuarioDTO();
            userDTO.NombreUsuario = usuario.NombreUsuario;
            userDTO.Nombre = usuario.Nombre;
            userDTO.Contraseña = usuario.Contraseña;
            userDTO.Apellido = usuario.Apellido;
            userDTO.Mail = usuario.Mail;
            return userDTO;
        }

        public static Usuario MappearAUsuario(UsuarioDTO userDTO) 
        {
            Usuario user = new Usuario();
            user.NombreUsuario = userDTO.NombreUsuario;
            user.Nombre = userDTO.Nombre;
            user.Contraseña = userDTO.Contraseña;
            user.Apellido = userDTO.Apellido;
            user.Mail = userDTO.Mail;
            return user;
        }
    }
}
