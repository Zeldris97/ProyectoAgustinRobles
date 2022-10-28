using Proyecto_final.Models;

namespace Proyecto_final.Models
{
    public class ProductoVenta :Venta
    {
        public List<Proyecto_final.Models.ProductoVendido> ProductosVendidos { get; set; }

    }
}
