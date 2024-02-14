using CoderHouseProyectoFinal.models;
using CoderHouseProyectoFinal.service;

namespace CoderHouseProyectoFinal.Business
{
    public class ProductoVendidoBusiness
    {

        public static List<ProductoVendido> GetAllSoldProducts() 
        {
            return ProductoService.GetAllProducts();
        }

        public static ProductoVendido GetSoldProduct(int id) 
        {
            return ProductoVendidoService.GetSoldProduct(id);
        }
        public static bool CreateSoldProduct(ProductoVendido productoCreado) 
        {
            return ProductoVendidoService.CreateSoldProduct(productoCreado);
        }
        public static bool DeleteSoldProduct(int id) 
        {
            return ProductoVendidoService.DeleteSoldProduct(id);
        }
        public static bool UpdateSoldProduct(ProductoVendido p, int id) 
        {
            return ProductoVendidoService.UpdateSoldProduct(p, id);
        }
    }
}
