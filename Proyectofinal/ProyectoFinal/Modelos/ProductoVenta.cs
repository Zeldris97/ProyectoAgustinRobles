using Proyecto_final.Models;

namespace Proyecto_final.Modelos
{
    public class ProductoVenta :Venta
    {
        public List<Proyecto_final.Models.ProductoVendido> ProductosVendidos { get; set; }

    }
}
