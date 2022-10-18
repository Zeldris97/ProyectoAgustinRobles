using Proyecto_final;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainMenu
{

    static void Main(string[] args)
    {
        Usuario cs = new Usuario();
        Producto pr = new Producto();
        ProductoVendido pv = new ProductoVendido();
        Venta v = new Venta();
        InicioSesion i = new InicioSesion();

        cs.TraerUsuario("tcasazza");

        pr.TraerProductoPorUsuario(1);

        pv.TraerProductoVendidoPorUsuario(1);

        v.TraerVenta(1);

        i.IniciarSesion ("tcasazza", "SoyTobiasCasazza");


    }
}