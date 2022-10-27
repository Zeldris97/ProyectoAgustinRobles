using Proyecto_final;
using Proyecto_final.Models; 
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


public class ProductoVendido
{
    

    private List<Proyecto_final.Models.ProductoVendido> _ProductoVendido;


    public ProductoVendido()
    {
        _ProductoVendido = new List<Proyecto_final.Models.ProductoVendido>();

    }

    public List<Proyecto_final.Models.ProductoVendido> TraerProductoVendidoPorUsuario(int idUsuario)
    {

        AccesoDatos ds = new AccesoDatos();
        var Parametro = new SqlParameter();

        var prov = new Proyecto_final.Models.ProductoVendido();


        Parametro.ParameterName = "IdUser";
        Parametro.SqlDbType = SqlDbType.BigInt;
        Parametro.Value = idUsuario;


        SqlDataReader reader = ds.EjecutarConsulta("select * from ProductoVendido pv inner join Producto p  on pv.IdProducto = p.id where p.IdUsuario = @idUser", Parametro);

        if (reader.HasRows)
        {

            while (reader.Read())
            {


                prov.id = Convert.ToInt32(reader.GetValue(0));
                prov.Stock = Convert.ToInt32(reader.GetValue(1));
                prov.IdProducto = Convert.ToInt32(reader.GetValue(2));
                prov.IdVenta = Convert.ToInt32(reader.GetValue(3));



                _ProductoVendido.Add(prov);



            }



            reader.Close();
            ds.CerrarConexion();
            


        }
        return _ProductoVendido;
    }
    public List<Proyecto_final.Models.ProductoVendido> DevolverProductosVendidos()
    {
        AccesoDatos ds = new AccesoDatos();
        var productoVendido = new Proyecto_final.Models.ProductoVendido();
        SqlDataReader reader = ds.EjecutarConsultaSinPar("Select * from ProductoVendido");
        var prov = new Proyecto_final.Models.ProductoVendido();

        if (reader.HasRows)
        {

            while (reader.Read())
            {



                prov.id = Convert.ToInt32(reader.GetValue(0));
                prov.Stock = Convert.ToInt32(reader.GetValue(1));
                prov.IdProducto = Convert.ToInt32(reader.GetValue(2));
                prov.IdVenta = Convert.ToInt32(reader.GetValue(3));


                _ProductoVendido.Add(prov);



            }
            reader.Close();
            ds.CerrarConexion();



        }
        return _ProductoVendido;
    }



}