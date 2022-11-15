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

        public static void AgregarVenta(Proyecto_final.Models.ProductoVenta vta, int IdUs)
        {
            long id;
         
            AccesoDatos ds = new AccesoDatos();
            SqlConnection cn = ds.ObtenerConexion();
            
            var proVenta = new Proyecto_final.Models.ProductoVendido();

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Venta] (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario); Select scope_identity();", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value = vta.Comentarios;
            cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = IdUs;
            id = Convert.ToInt64(cmd.ExecuteScalar());

           

            foreach (Proyecto_final.Models.ProductoVendido pro in vta.ProductosVendidos)
            {
                cmd = new SqlCommand("INSERT INTO dbo.ProductoVendido (Stock,idProducto,idVenta) VALUES (@Stock,@IdProducto, @IdVenta)", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = proVenta.Stock;
                cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.Int)).Value = proVenta.IdProducto;
                cmd.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.Int)).Value = proVenta.IdVenta;



                cmd = new SqlCommand("UPDATE Producto SET Stock = Stock - @Stock WHERE idProducto = @IdProducto", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = proVenta.IdVenta;
                cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = proVenta.Stock;
                cmd.ExecuteNonQuery();
            }

            ds.CerrarConexion();
            
        }


        public static void EliminarVenta(int IdV)
        {
            int filasEliminadas;
            int sum;
            var listaPV = new List<Proyecto_final.Models.ProductoVendido>();
            var Parametro = new SqlParameter();
         

            AccesoDatos ds = new AccesoDatos();
            SqlConnection cn = ds.ObtenerConexion();

            Parametro.ParameterName = "IdVenta";
            Parametro.SqlDbType = SqlDbType.BigInt;
            Parametro.Value = IdV;

         


         
           

            SqlDataReader reader = ds.EjecutarConsulta("SELECT * FROM ProductoVendido Where IdVenta =@IdVenta",Parametro);
          

            if(reader.HasRows)
            {
                ds.EjecutarConsulta("Delete FROM Venta WHERE Id = @IdVenta", Parametro);
                ds.EjecutarConsulta("Delete from ProductoVendido where IdVenta = @IdVenta", Parametro);
                while (reader.Read())
                {
                    var pv = new Proyecto_final.Models.ProductoVendido();

                    pv.id = Convert.ToInt32(reader.GetValue(0));
                    pv.Stock = Convert.ToInt32(reader.GetValue(1));
                    pv.IdProducto = Convert.ToInt32(reader.GetValue(2));
                    pv.IdVenta = Convert.ToInt32(reader.GetValue(3));

                    listaPV.Add(pv);
                }


                foreach (Proyecto_final.Models.ProductoVendido pv in listaPV) {
                  
                    
                    SqlCommand cmd = new SqlCommand("UPDATE Producto SET Stock = Stock + @Stock WHERE Id = @IdProducto", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = pv.Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = pv.IdProducto;
                    cmd.ExecuteNonQuery();

                }
                      

            }

            ds.CerrarConexion();


        }
            

    }

 }





