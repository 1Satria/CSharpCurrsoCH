using CoderHouseProyectoFinal.Business;
using CoderHouseProyectoFinal.database;
using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.Mapper;
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
                Producto prodAux = new Producto();
                Ventum ventaABorrar = context.Venta.Include(u => u.ProductoVendidos).Where(u => u.Id == id).FirstOrDefault();
                List<ProductoVendido> prodvendidos = context.ProductoVendidos.Where(u => u.IdVenta == id).ToList();

                
                if (ventaABorrar is not null)
                {
                    foreach (var p in prodvendidos)
                    {

                        prodAux = ProductoBusiness.GetProduct((int)p.IdProducto);
                        prodAux.Stock = prodAux.Stock + p.Stock;
                        ProductoBusiness.UpdateProduct(prodAux, (int)p.IdProducto);
                    }
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
                ventaACambiar.IdUsuario = v.IdUsuario;
                context.Venta.Update(ventaACambiar);
                context.SaveChanges();
                return true;

            }
        }
        public static bool CreateVentum(VentumDTO ventaDTO)
        {
            using (CoderContext context = new CoderContext()) 
            {
                Ventum ventaMapeada = VentumMapper.MappearAVentum(ventaDTO);
                context.Venta.Add(ventaMapeada);
                context.SaveChanges();

                foreach (var lst in ventaDTO.listaProductos) 
                {
                    ProductoVendido productSold = new ProductoVendido();
                    productSold.IdVenta = (long)ventaMapeada.Id;
                    productSold.IdProducto = lst[0];
                    productSold.Stock = lst[1];
                    context.ProductoVendidos.Add(productSold);

                    Producto PAux = context.Productos.Where(u => u.Id == productSold.IdProducto).FirstOrDefault();
                    PAux.Stock = PAux.Stock - productSold.Stock;
                    context.SaveChanges();
                }
                
                return true;
            }
        }
    }
}
