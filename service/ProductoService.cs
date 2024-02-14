using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.models;

using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CoderHouseProyectoFinal.service
{
    public static class ProductoService
    {
        public static List<Producto> GetAllProducts()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.Productos.ToList();
            }
        }
        public static Producto GetProduct(int id) 
        {
            
            using (CoderContext context = new CoderContext()) 
            {
                
                return context.Productos.Where(u => u.Id == id).FirstOrDefault();
            }
        }

        public static bool CreateProduct(Producto productoCreado) 
        {
            using(CoderContext context = new CoderContext()) 
            {
                context.Productos.Add(productoCreado);
                context.SaveChanges();
                return true;

            }
        }

        public static bool DeleteProduct(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                Producto productoABorrar = context.Productos.Include(u => u.ProductoVendidos).Where(u => u.Id == id).FirstOrDefault();


                if (productoABorrar is not null)
                {
                    context.Productos.Remove(productoABorrar);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool UpdateProduct(Producto p,int id) 
        {
            using (CoderContext context = new CoderContext()) 
            {
                Producto productoBuscado = context.Productos.Where(u => u.Id == id).FirstOrDefault();

                productoBuscado.Descripciones = p.Descripciones;
                productoBuscado.Stock = p.Stock;
                productoBuscado.Costo = p.Costo;
                productoBuscado.PrecioVenta = p.PrecioVenta;

                context.Productos.Update(productoBuscado);
                context.SaveChanges();
                return true;

            }
        }
    }
}
