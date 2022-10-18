using Proyecto_final;
using Proyecto_final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


public class InicioSesion
{
    AccesoDatos ds = new AccesoDatos();

    private List<Proyecto_final.Models.Usuario> _User;

    public InicioSesion()
    {
        _User = new List<Proyecto_final.Models.Usuario>();
    }


    public Proyecto_final.Models.Usuario IniciarSesion(string NombreUser, string Contraseña)
    {


        var Us = new Proyecto_final.Models.Usuario();


        var Parametro1 = new SqlParameter();
        var Parametro2 = new SqlParameter();


        Parametro1.ParameterName = "NombreUsuario";
        Parametro1.SqlDbType = SqlDbType.VarChar;
        Parametro1.Value = NombreUser;
        Parametro2.ParameterName = "Contraseña";
        Parametro2.SqlDbType = SqlDbType.VarChar;
        Parametro2.Value = Contraseña;

        SqlDataReader reader = ds.EjecutarConsulta2Parametros("select * from Usuario where NombreUsuario like @NombreUsuario and Contraseña like @Contraseña", Parametro1, Parametro2);

        if (reader.HasRows)
        {
            while (reader.Read())
            {



                Us.id = Convert.ToInt32(reader.GetValue(0));
                Us.Nombre = reader.GetValue(1).ToString();
                Us.Apellido = reader.GetValue(2).ToString();
                Us.Contraseña = reader.GetValue(3).ToString();
                Us.NombreUsuario = reader.GetValue(4).ToString();
                Us.Mail = reader.GetValue(5).ToString();

                _User.Add(Us);



            }

            Console.WriteLine("Bienvenido " + Us.NombreUsuario);
        }
        else
        {

            Console.WriteLine("El usuario no existe");
        }


        reader.Close();
        ds.CerrarConexion();
        return Us;


    }
}