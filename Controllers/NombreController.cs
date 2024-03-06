using CoderHouseProyectoFinal.Business;
using CoderHouseProyectoFinal.models;
using Microsoft.AspNetCore.Mvc;

namespace CoderHouseProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {
        [HttpGet("TraerNombre")]
        public string obtenerNombre()
        {
            string nombreEcommerce = "E-commerce by Matias Zaragoza";
            return nombreEcommerce;
        }
    }
}
