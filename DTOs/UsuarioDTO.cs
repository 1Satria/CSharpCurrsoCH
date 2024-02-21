﻿namespace CoderHouseProyectoFinal.DTOs
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Mail { get; set; } = null!;
    }
}