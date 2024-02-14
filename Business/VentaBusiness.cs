using CoderHouseProyectoFinal.models;
using CoderHouseProyectoFinal.service;

namespace CoderHouseProyectoFinal.Business
{
    public static class VentaBusiness
    {
        public static List<Ventum> GetAllVentum() 
        {
            return VentaService.GetAllVentum();
        }
        public static Ventum GetVentum(int idUser) 
        {
            return VentaService.GetVentum(idUser);
        }
        public static bool DeleteVentum(int id) 
        {
            return VentaService.DeleteVentum(id);
        }
        public static bool UpdateVentum(Ventum v, int id) 
        {
            return VentaService.UpdateVentum(v, id);
        }
        public static bool CreateVentum(Ventum v) 
        {
            return VentaService.CreateVentum(v);
        }
    }
}
