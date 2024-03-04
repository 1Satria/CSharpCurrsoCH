using CoderHouseProyectoFinal.DTOs;
using CoderHouseProyectoFinal.models;

namespace CoderHouseProyectoFinal.Mapper
{
    public static class VentumMapper
    {
        //IdUsuario Comentarios Id
        public static Ventum MappearAVentum(VentumDTO ventaDTO) 
        {
            Ventum venta = new Ventum();
            venta.Comentarios = ventaDTO.Comentarios;
            venta.Id = null;
            venta.IdUsuario = ventaDTO.IdUsuario;
            return venta;
        }
        public static VentumDTO MappearAVentumDTO(Ventum venta) 
        {
            VentumDTO ventaDTO = new VentumDTO();
            ventaDTO.Comentarios=venta.Comentarios;
            ventaDTO.Id=null;
            ventaDTO.IdUsuario =venta.IdUsuario;
            return ventaDTO;
        }
    }
}
