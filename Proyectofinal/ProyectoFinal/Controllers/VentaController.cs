﻿using Microsoft.AspNetCore.Mvc;
using Proyecto_final.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public void CargarVenta([FromBody] Proyecto_final.Models.Venta vta)
        {
            Proyecto_final.Repository.Venta.CargarVenta(vta);
        }

        [HttpGet("GetVentas")]
        public List<Proyecto_final.Models.Venta> Get(Int32 id)
        {
            return Proyecto_final.Repository.Venta.TraerVenta(id);
        }
    }
}