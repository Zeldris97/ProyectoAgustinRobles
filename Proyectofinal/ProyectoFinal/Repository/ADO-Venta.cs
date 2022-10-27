using Proyecto_final;
using Proyecto_final.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_final.Repository
{
    public class Venta
    {

       

        public static List<Proyecto_final.Models.Venta> TraerVenta(int idUsuario)
        {
            AccesoDatos ds = new AccesoDatos();
            List<Proyecto_final.Models.Venta> _Venta = new List<Proyecto_final.Models.Venta>();
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

        public static void CargarVenta(Proyecto_final.Models.Venta vta)
        {
            long id;
         
            AccesoDatos ds = new AccesoDatos();
            SqlConnection cn = ds.ObtenerConexion();
            var prov = new Proyecto_final.Repository.ProductoVendido();
            var proVenta = new Proyecto_final.Models.ProductoVendido();

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Venta] (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario); Select scope_identity();", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value = vta.Comentarios;
            cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = vta.IdUsuario;
            id = Convert.ToInt64(cmd.ExecuteScalar());

            //INSERT en tabla producto vendido con lista de productos enviados


           proVenta= prov.CargarProductoVendido(id);

                //Actualizar Stock en Productos
                cmd = new SqlCommand("UPDATE Producto SET Stock = Stock - @Stock WHERE idProducto = @IdProducto", cn);
                cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = proVenta.IdVenta;
            cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = proVenta.Stock;
                cmd.ExecuteNonQuery();

            ds.CerrarConexion();
            
        }

    }


}


