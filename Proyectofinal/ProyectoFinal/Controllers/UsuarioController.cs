using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       
        // GET api/<ValuesController>/5
        [HttpGet("GetUsuariosId")]
        public Proyecto_final.Models.Usuario Get(Int32 id)
        {
            return Proyecto_final.Repository.Usuario.TraerUsuarioPorID (id);
        }

        // POST api/<ValuesController>
        [HttpGet("GetUsuariosNombre")]
        public Proyecto_final.Models.Usuario Get(String nombre)
        {
            return Proyecto_final.Repository.Usuario.TraerUsuarioPorNombre(nombre);
        }

        // PUT api/<ValuesController>/5

        [HttpGet("GetInicioSesion")]
        public Proyecto_final.Models.Usuario Get(String nombre, String contraseña)
        {
            return Proyecto_final.Repository.Usuario.IniciarSesion(nombre, contraseña);
        }

        // DELETE api/<ValuesController>/5
        public long Crear([FromBody] Proyecto_final.Models.Usuario us)
        {
            return Proyecto_final.Repository.Usuario.CrearUsuario(us);

        }

        [HttpPut]
        public long Modificar([FromBody] Proyecto_final.Models.Usuario us)
        {
            return Proyecto_final.Repository.Usuario.ModificarUsuario(us);
        }


        [HttpDelete]
        public long Eliminar([FromBody] long idUsuario)
        {
            return Proyecto_final.Repository.Usuario.EliminarUsuario(idUsuario);
        }


    }
}
