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


public class Usuario
{
    AccesoDatos ds = new AccesoDatos();

    private List<Proyecto_final.Models.Usuario> _User;
  




    public Usuario()
    {
        _User = new List<Proyecto_final.Models.Usuario>();
     
      
    }

    public Proyecto_final.Models.Usuario TraerUsuario(string NombreUsuario)
    {

        var Parametro = new SqlParameter();

        var Us = new Proyecto_final.Models.Usuario();

        Parametro.ParameterName = "UserName";
        Parametro.SqlDbType = SqlDbType.VarChar;
        Parametro.Value = NombreUsuario;


        SqlDataReader reader = ds.EjecutarConsulta("Select * from Usuario where NombreUsuario = @UserName", Parametro);

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
            Console.WriteLine("---- USUARIO ----- ");
            foreach (var us in _User)
            {

                Console.WriteLine("--------------");
                Console.WriteLine("id = " + us.id);
                Console.WriteLine("Nombre = " + us.Nombre);
                Console.WriteLine("Apellido = " + us.Apellido);
                Console.WriteLine("Contraseña = " + us.Contraseña);
                Console.WriteLine("Nombre de usuario = " + us.NombreUsuario);
                Console.WriteLine("Mail = " + us.Mail);

                Console.WriteLine("--------------");
            }


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
