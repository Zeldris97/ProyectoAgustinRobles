using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Proyecto_final
{
    public class AccesoDatos
    {
        private String RutaBD = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaGestion2;Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(RutaBD);

            cn.Open();
            return cn;

        }

         public SqlConnection CerrarConexion()
        {
            SqlConnection cn = new SqlConnection(RutaBD);

            cn.Close();
            return cn;

        }
       

        public SqlDataReader EjecutarConsulta(String consulta, SqlParameter par)
        {
            
            SqlConnection conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.Add(par);
            SqlDataReader datos = cmd.ExecuteReader();
         
            return datos;

        }
        public SqlDataReader EjecutarConsultaSinPar(String consulta)
        {

            SqlConnection conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            SqlDataReader datos = cmd.ExecuteReader();

            return datos;

        }


        public SqlDataReader EjecutarConsulta2Parametros(String consulta, SqlParameter par1, SqlParameter par2)
        {
       
            SqlConnection conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            SqlDataReader datos = cmd.ExecuteReader();
           
            return datos;

        }

      

    }


}

