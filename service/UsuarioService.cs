using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.models;
using Microsoft.EntityFrameworkCore;

namespace CoderHouseProyectoFinal.service
{
    public static class UsuarioService
    {
        public static List<Usuario> GetAllUsers() 
        {
            using (CoderContext context = new CoderContext()) 
            {
                return context.Usuarios.ToList();
            }
        }

        public static Usuario GetUser(int idUser) 
        {
            using (CoderContext context = new CoderContext()) 
            {
                return context.Usuarios.Where(u => u.Id == idUser).FirstOrDefault();
            }
        }
        public static bool CreateUser(Usuario v)
        {
            using (CoderContext context = new CoderContext())
            {
                context.Usuarios.Add(v);
                context.SaveChanges();
                return true;
            }
        }

        public static bool DeleteUser(int id)
        {
            using (CoderContext context = new CoderContext()) 
            {
                Usuario usuarioABorrar = context.Usuarios.Include(u => u.Venta).Include(u => u.Productos).Where(u => u.Id == id).FirstOrDefault();


                if (usuarioABorrar is not null) 
                {
                    context.Productos.RemoveRange(usuarioABorrar.Productos);
                    context.Venta.RemoveRange(usuarioABorrar.Venta);
                    context.Usuarios.Remove(usuarioABorrar);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public static bool UpdateProduct(Usuario u, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Usuario usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

                usuarioBuscado.Nombre = u.Nombre;
                usuarioBuscado.Apellido = u.Apellido;
                usuarioBuscado.NombreUsuario = u.NombreUsuario;
                usuarioBuscado.Mail = u.Mail;
                context.Usuarios.Update(usuarioBuscado);
                context.SaveChanges();
                return true;

            }
        }

        




    }
}
