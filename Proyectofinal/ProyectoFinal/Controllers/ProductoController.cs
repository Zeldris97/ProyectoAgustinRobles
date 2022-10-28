using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Models;
using Proyecto_final.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyectoFinal
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("GetProductos")]
        public List<Proyecto_final.Models.Producto> Get()
        {

            return Proyecto_final.Repository.Producto.DevolverProductos();

        }

        // GET api/<ValuesController>/5
        [HttpGet]
        public Proyecto_final.Models.Producto Get(Int32 id)
        {
            return Proyecto_final.Repository.Producto.TraerProductoPorId(id);
        }

        // POST api/<ValuesController>
      
        [HttpPost]
        public void Crear([FromBody] Proyecto_final.Models.Producto prod)
        {
            Proyecto_final.Repository.Producto.CrearProducto(prod);
        }
        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Modificar([FromBody] Proyecto_final.Models.Producto prod)
        {
             Proyecto_final.Repository.Producto.ModificarProducto (prod);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public void Eliminar([FromBody]  long idProducto)
        {
            Proyecto_final.Repository.Producto.EliminarProducto(idProducto);
        }
    }
}
