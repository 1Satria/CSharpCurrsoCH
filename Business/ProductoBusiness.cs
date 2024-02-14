using CoderHouseProyectoFinal.models;
using CoderHouseProyectoFinal.service;

namespace CoderHouseProyectoFinal.Business
{
    public static class ProductoBusiness
    {

        public static List<Producto> GetAllProducts() 
        {
            return ProductoService.GetAllProducts();
        }
        public static Producto GetProduct(int id) 
        {
            return ProductoService.GetProduct(id);
        }
        public static bool CreateProduct(Producto productoCreado) 
        {
            return ProductoService.CreateProduct(productoCreado);
        }
        public static bool DeleteProduct(int id) 
        {
            return ProductoService.DeleteProduct(id);
        }
        public static bool UpdateProduct(Producto p, int id) 
        {
            return ProductoService.UpdateProduct(p, id);
        }
    }
}
