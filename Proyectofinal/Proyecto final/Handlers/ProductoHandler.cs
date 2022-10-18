using Proyecto_final;
using Proyecto_final.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


public class Producto
{
    AccesoDatos ds = new AccesoDatos();

    private List<Proyecto_final.Models.Producto> _Producto;


    public Producto()
    {
        _Producto = new List<Proyecto_final.Models.Producto>();

    }

    public List<Proyecto_final.Models.Producto> TraerProductoPorUsuario(int idUsuario)
    {


        var Parametro = new SqlParameter();

        var pro = new Proyecto_final.Models.Producto();


        Parametro.ParameterName = "IdUsuario";
        Parametro.SqlDbType = SqlDbType.BigInt;
        Parametro.Value = idUsuario;


        SqlDataReader reader = ds.EjecutarConsulta("Select * from Producto where idUsuario = @IdUsuario", Parametro);

        if (reader.HasRows)
        {

            while (reader.Read())
            {


                pro.id = Convert.ToInt32(reader.GetValue(0));
                pro.Descripcion = reader.GetValue(1).ToString();
                pro.Costo = Convert.ToInt32(reader.GetValue(2));
                pro.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                pro.Stock = Convert.ToInt32(reader.GetValue(4));
                pro.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                _Producto.Add(pro);



            }

            Console.WriteLine("---- Productos cargados por este usuario ----- ");
            foreach (var pr in _Producto)
            {

                Console.WriteLine("--------------");
                Console.WriteLine("id = " + pr.id);
                Console.WriteLine("Descripcion = " + pr.Descripcion);
                Console.WriteLine("Costo = " + pr.Costo);
                Console.WriteLine("Precio de venta = " + pr.PrecioVenta);
                Console.WriteLine("Stock = " + pr.Stock);
                Console.WriteLine("IdUsuario = " + pr.IdUsuario);

                Console.WriteLine("--------------");
            }
        }

        else
        {

            Console.WriteLine("El producto no existe");
        }

        reader.Close();
        ds.CerrarConexion();

        return _Producto;


    }


}