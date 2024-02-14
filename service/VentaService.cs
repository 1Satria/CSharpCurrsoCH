using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.models;
using Microsoft.EntityFrameworkCore;

namespace CoderHouseProyectoFinal.service
{
    public static class VentaService
    {
        public static List<Ventum> GetAllVentum()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Venta.ToList();
            }
        }

        public static Ventum GetVentum(int idUser)
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Venta.Where(u => u.Id == idUser).FirstOrDefault();
            }
        }

        public static bool DeleteVentum(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Ventum ventaABorrar = context.Venta.Include(u => u.ProductoVendidos).Where(u => u.Id == id).FirstOrDefault();


                if (ventaABorrar is not null)
                {
                    context.Venta.Remove(ventaABorrar);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public static bool UpdateVentum(Ventum v, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Ventum ventaACambiar = context.Venta.Where(u => u.Id == id).FirstOrDefault();

                ventaACambiar.Comentarios = v.Comentarios;
                context.Venta.Update(ventaACambiar);
                context.SaveChanges();
                return true;

            }
        }
        public static bool CreateVentum(Ventum v)
        {
            using (CoderContext context = new CoderContext()) 
            {
                context.Venta.Add(v);
                context.SaveChanges();
                return true;
            }
        }
    }
}
