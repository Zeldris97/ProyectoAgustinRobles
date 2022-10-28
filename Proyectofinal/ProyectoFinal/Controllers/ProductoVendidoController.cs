using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("GetProductosVendidos")]
        public List<Proyecto_final.Models.ProductoVendido> Get()
        {
            return Proyecto_final.Repository.ProductoVendido.DevolverProductosVendidos();
        }

        [HttpGet]
        public List<Proyecto_final.Models.ProductoVendido> Get(Int32 id)
        {
            return Proyecto_final.Repository.ProductoVendido.TraerProductoVendidoPorUsuario(id);
        }


    }
}
