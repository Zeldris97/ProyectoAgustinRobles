using Proyecto_final.Models;
using Proyecto_final.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


public class Venta
{
    AccesoDatos ds = new AccesoDatos();

    private List<Proyecto_final.Models.Venta> _Venta;


    public Venta()
    {
        _Venta = new List<Proyecto_final.Models.Venta>();

    }

    public List<Proyecto_final.Models.Venta> TraerVenta(int idUsuario)
    {


        var Parametro = new SqlParameter();

        var V = new Proyecto_final.Models.Venta();

        Parametro.ParameterName = "IdUser";
        Parametro.SqlDbType = SqlDbType.BigInt;
        Parametro.Value = idUsuario;


        SqlDataReader reader = ds.EjecutarConsulta("select * from Venta where IdUsuario = @idUser", Parametro);

        if (reader.HasRows)
        {
            while (reader.Read())
            {


                V.id = Convert.ToInt32(reader.GetValue(0));
                V.Comentarios = reader.GetValue(1).ToString();
                V.IdUsuario = Convert.ToInt32(reader.GetValue(2));




                _Venta.Add(V);



            }

            Console.WriteLine("---- Ventas de este usuario ----- ");
            foreach (var Ve in _Venta)
            {

                Console.WriteLine("--------------");
                Console.WriteLine("id = " + V.id);
                Console.WriteLine("Comentarios = " + V.Comentarios);
                Console.WriteLine("idUsuario = " + V.IdUsuario);


                Console.WriteLine("--------------");
            }
        }
        else
        {

            Console.WriteLine("No hay ventas");
        }


        reader.Close();
        ds.CerrarConexion();
        return _Venta;

    }

}


