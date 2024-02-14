using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.models;
using Microsoft.EntityFrameworkCore;

namespace CoderHouseProyectoFinal.service
{
    public static class ProductoVendidoService
    {

        public static List<ProductoVendido> GetAllSoldProducts()
        {
            using (CoderContext context = new CoderContext())
            {
                return context.ProductoVendidos.ToList();
            }
        }
        public static ProductoVendido GetSoldProduct(int id)
        {

            using (CoderContext context = new CoderContext())
            {

                return context.ProductoVendidos.Where(u => u.Id == id).FirstOrDefault();
            }
        }

        public static bool CreateSoldProduct(ProductoVendido productoCreado)
        {
            using (CoderContext context = new CoderContext())
            {
                context.ProductoVendidos.Add(productoCreado);
                context.SaveChanges();
                return true;

            }
        }

        public static bool DeleteSoldProduct(int id)
        {
            using (CoderContext context = new CoderContext())
            {
                ProductoVendido productoVendidoABorrar = context.ProductoVendidos.Where(u => u.Id == id).FirstOrDefault();


                if (productoVendidoABorrar is not null)
                {
                    context.ProductoVendidos.Remove(productoVendidoABorrar);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool UpdateSoldProduct(ProductoVendido p, int id)
        {
            using (CoderContext context = new CoderContext())
            {
                ProductoVendido productoVendidoBuscado = context.ProductoVendidos.Where(u => u.Id == id).FirstOrDefault();

                productoVendidoBuscado.IdProducto = p.IdProducto;
                productoVendidoBuscado.Stock = p.Stock;
                productoVendidoBuscado.IdVenta = p.IdVenta;


                context.ProductoVendidos.Update(productoVendidoBuscado);
                context.SaveChanges();
                return true;

            }
        }
    }
}
