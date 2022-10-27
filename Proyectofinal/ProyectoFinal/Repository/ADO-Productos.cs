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
    public class Producto
    {


        public static List<Proyecto_final.Models.Producto> DevolverProductos()
        {
            AccesoDatos ds = new AccesoDatos();
            List<Proyecto_final.Models.Producto> _Producto = new List<Proyecto_final.Models.Producto>();
            var producto = new Proyecto_final.Models.Producto();
            SqlDataReader reader = ds.EjecutarConsultaSinPar("Select * from Producto");
            var pro = new Proyecto_final.Models.Producto();
          
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
                reader.Close();
                ds.CerrarConexion();



            }
            return _Producto;
        }

       

        public static Proyecto_final.Models.Producto TraerProductoPorId(int id)
        {
            AccesoDatos ds = new AccesoDatos();
           
            var Parametro = new SqlParameter();

            var pro = new Proyecto_final.Models.Producto();


            Parametro.ParameterName = "IdPro";
            Parametro.SqlDbType = SqlDbType.BigInt;
            Parametro.Value = id;


            SqlDataReader reader = ds.EjecutarConsulta("Select * from Producto where id = @IdPro", Parametro);

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

                   



                }
            }


            reader.Close();
            ds.CerrarConexion();

            return pro;


        }
        public static long CrearProducto(Proyecto_final.Models.Producto prod)
        {
            AccesoDatos ds = new AccesoDatos();
           

            SqlConnection cn = ds.ObtenerConexion();
            long id;


            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES (@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario); Select scope_identity()", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.NVarChar)).Value = prod.Descripcion;
            cmd.Parameters.Add(new SqlParameter("Costo", SqlDbType.Float)).Value = prod.Costo;
            cmd.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Float)).Value = prod.PrecioVenta;
            cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = prod.Stock;
            cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = prod.IdUsuario;
            id = Convert.ToInt64(cmd.ExecuteScalar());

            ds.CerrarConexion();

            return id;

        }
        public static Int32 ModificarProducto(Proyecto_final.Models.Producto prod)
        {
            AccesoDatos ds = new AccesoDatos();
    
            int filasCambiadas;
           
            SqlConnection cn = ds.ObtenerConexion();

            SqlCommand cmd = new SqlCommand("UPDATE Producto  SET Descripciones = @Descripciones ,Costo = @Costo ,PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @idUsuario WHERE id = @id ", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt)).Value = prod.id;
            cmd.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.NVarChar)).Value = prod.Descripcion;
            cmd.Parameters.Add(new SqlParameter("Costo", SqlDbType.Float)).Value = prod.Costo;
            cmd.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Float)).Value = prod.PrecioVenta;
            cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = prod.Stock;
            cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = prod.IdUsuario;
            filasCambiadas = Convert.ToInt32(cmd.ExecuteNonQuery());

            ds.CerrarConexion();

            return filasCambiadas;
        }

        public static Int32 EliminarProducto(long idProducto)

        {
            AccesoDatos ds = new AccesoDatos();
          
            int filasEliminadas;
           
            SqlConnection cn = ds.ObtenerConexion();
            cn.Open();

            //Eliminar de tabla Productos
            SqlCommand cmd = new SqlCommand("Delete FROM Producto WHERE Id = @idProducto", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("idProducto", SqlDbType.BigInt)).Value = idProducto;
            filasEliminadas = Convert.ToInt32(cmd.ExecuteNonQuery());
            cn.Close();

            //Eliminar productos vendidos
            cmd = new SqlCommand("Delete FROM ProductoVendido WHERE Id = @idProducto", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("idProducto", SqlDbType.BigInt)).Value = idProducto;
            cmd.ExecuteNonQuery();



            return filasEliminadas;
        }
    }
}