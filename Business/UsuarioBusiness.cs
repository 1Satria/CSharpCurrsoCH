using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.models;
using CoderHouseProyectoFinal.service;

namespace CoderHouseProyectoFinal.Business
{
    public static class UsuarioBusiness
    {
        public static List<Usuario> GetAllUsers() 
        {
            return UsuarioService.GetAllUsers();

        }
        public static Usuario GetUser(int idUser)
        {
            return UsuarioService.GetUser(idUser);
            
        }
        public static bool CreateUser(Usuario v) 
        {
            return UsuarioService.CreateUser(v); 
        }
        public static bool DeleteUser(int id)
        {
            return UsuarioService.DeleteUser(id);
        }
        public static bool UpdateUser(Usuario u, int id) 
        {
            return UsuarioService.UpdateUser(u, id);
        }
    }
}
