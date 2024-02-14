using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.models;
using CoderHouseProyectoFinal.service;

namespace CoderHouseProyectoFinal.Business
{
    public static class UsuarioBusiness
    {
        public static Usuario GetUser(int idUser)
        {
            return UsuarioBusiness.GetUser(idUser);
            
        }
        public static bool CreateUser(Usuario v) 
        {
            return UsuarioService.CreateUser(v); 
        }
        public static bool DeleteUser(int id)
        {
            return UsuarioService.DeleteUser(id);
        }
        public static bool UpdateProduct(Usuario u, int id) 
        {
            return UsuarioService.UpdateProduct(u, id);
        }
}
