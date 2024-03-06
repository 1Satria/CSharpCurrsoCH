using CoderHouseProyectoFinal.Business;
using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

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
        public static Usuario GetUserByUsername(string userName) 
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Usuarios.Where(u => u.NombreUsuario == userName).FirstOrDefault();
            }
        }
        public static Usuario ObtenerUsuarioPorUsuarioYPassword(string UserName, string password) 
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Usuarios.Where(u => u.NombreUsuario == UserName).Where(u => u.Contraseña == password).FirstOrDefault();
            }
        }
        public static bool CreateUser(Usuario v)
        {
            using (CoderContext context = new CoderContext())
            {
                if (GetUserByUsername(v.NombreUsuario) == null)
                {
                    context.Usuarios.Add(v);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool DeleteUser(int id)
        {
            using (CoderContext context = new CoderContext()) 
            {
                List<int> IdsVentas = new List<int> {};
                Usuario usuarioABorrar = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                List<Producto> productosABorrar = context.Productos.Include(u => u.ProductoVendidos).Where(u => u.IdUsuario == id).ToList();
                List<Ventum> ventasaborrar = context.Venta.Include(u => u.ProductoVendidos).Where(u => u.IdUsuario == id).ToList();
                
                if (usuarioABorrar is not null) 
                {
                    
                    context.Productos.RemoveRange(productosABorrar);
                    context.Venta.RemoveRange(ventasaborrar);
                    context.Usuarios.Remove(usuarioABorrar);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public static bool UpdateUser(Usuario u, int id)
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
