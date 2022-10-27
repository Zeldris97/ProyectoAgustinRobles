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

    private List<Proyecto_final.Models.Usuario> _Usuario;


    public Usuario()
    {
        _Usuario = new List<Proyecto_final.Models.Usuario>();

    }

    public List<Proyecto_final.Models.Usuario> DevolverUsuarios()
    {


        var Us = new Proyecto_final.Models.Usuario();

        SqlDataReader reader = ds.EjecutarConsultaSinPar("Select * from Usuario");

        if (reader.HasRows)
        {

            while (reader.Read())
            {
                var us = new Proyecto_final.Models.Usuario();

                Us.id = Convert.ToInt32(reader.GetValue(0));
                Us.Nombre = reader.GetValue(1).ToString();
                Us.Apellido = reader.GetValue(2).ToString();
                Us.Contraseña = reader.GetValue(3).ToString();
                Us.NombreUsuario = reader.GetValue(4).ToString();
                Us.Mail = reader.GetValue(5).ToString();

                _Usuario.Add(Us);


            }


        }



        reader.Close();
        ds.CerrarConexion();

        return _Usuario;

    }
    public Proyecto_final.Models.Usuario TraerUsuarioPorNombre(string NombreUsuario)
    {

        var Parametro = new SqlParameter();

        var usuario = new Proyecto_final.Models.Usuario();
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Usuario WHERE NombreUsuario like @NombreUsuario", ds.ObtenerConexion());
        adapter.SelectCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar)).Value = NombreUsuario;
        DataTable tabla = new DataTable();
        adapter.Fill(tabla);
        if (tabla.Rows.Count > 0)
        {
            DataRow dr = tabla.Rows[0];
            usuario.id = Convert.ToInt32(dr["id"]);
            usuario.Apellido = dr["Apellido"].ToString();
            usuario.Nombre = dr["Nombre"].ToString();
            usuario.NombreUsuario = dr["NombreUsuario"].ToString();
            usuario.Contraseña = dr["Contraseña"].ToString();
            usuario.Mail = dr["Mail"].ToString();
        }


        ds.CerrarConexion();


        return usuario;

    }


    public Proyecto_final.Models.Usuario TraerUsuarioPorID(string IDUsuario)
    {

        var Parametro = new SqlParameter();

        var usuario = new Proyecto_final.Models.Usuario();
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Usuario WHERE =@IdUsuario", ds.ObtenerConexion());
        adapter.SelectCommand.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = IDUsuario;
        DataTable tabla = new DataTable();
        adapter.Fill(tabla);
        if (tabla.Rows.Count > 0)
        {
            DataRow dr = tabla.Rows[0];
            usuario.id = Convert.ToInt32(dr["id"]);
            usuario.Apellido = dr["Apellido"].ToString();
            usuario.Nombre = dr["Nombre"].ToString();
            usuario.NombreUsuario = dr["NombreUsuario"].ToString();
            usuario.Contraseña = dr["Contraseña"].ToString();
            usuario.Mail = dr["Mail"].ToString();
        }


        ds.CerrarConexion();


        return usuario;

    }

    public long CrearUsuario(Proyecto_final.Models.Usuario us)
    {
        AccesoDatos ds = new AccesoDatos();
        SqlConnection cn = ds.ObtenerConexion();
        long id;


        SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail); Select scope_identity()", cn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = us.Nombre;
        cmd.Parameters.Add(new SqlParameter("Apellido", SqlDbType.NVarChar)).Value = us.Apellido;
        cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.NVarChar)).Value = us.NombreUsuario;
        cmd.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.NVarChar)).Value = us.Contraseña;
        cmd.Parameters.Add(new SqlParameter("Mail", SqlDbType.NVarChar)).Value = us.Mail;
        id = Convert.ToInt64(cmd.ExecuteScalar());


        ds.CerrarConexion();

        return id;

    }


    public static Int32 ModificarUsuario(Proyecto_final.Models.Usuario us)
    {
        int filasCambiadas;
        AccesoDatos ds = new AccesoDatos();
        SqlConnection cn = ds.ObtenerConexion();

        SqlCommand cmd = new SqlCommand("UPDATE Usuario SET  Nombre = @Nombre, Apellido = @Apellido , NombreUsuario = @NombreUsuario , Contraseña = @Contraseña , Mail = @Mail WHERE id = @id", cn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("Id", SqlDbType.NVarChar)).Value = us.id;
        cmd.Parameters.Add(new SqlParameter("Nombre", SqlDbType.NVarChar)).Value = us.Nombre;
        cmd.Parameters.Add(new SqlParameter("Apellido", SqlDbType.NVarChar)).Value = us.Apellido;
        cmd.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.NVarChar)).Value = us.NombreUsuario;
        cmd.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.NVarChar)).Value = us.Contraseña;
        cmd.Parameters.Add(new SqlParameter("Mail", SqlDbType.NVarChar)).Value = us.Mail;
        filasCambiadas = Convert.ToInt32(cmd.ExecuteNonQuery());

        ds.CerrarConexion();
        return filasCambiadas;
    }

    public static int EliminarUsuario(long idUsuario)

    {
        int filasEliminadas;
        AccesoDatos ds = new AccesoDatos();
        SqlConnection cn = ds.ObtenerConexion();

        SqlCommand cmd = new SqlCommand("Delete FROM Usuario WHERE Id = @IdUsuario", cn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.BigInt)).Value = idUsuario;
        filasEliminadas = Convert.ToInt32(cmd.ExecuteNonQuery());

        ds.CerrarConexion();

        return filasEliminadas;
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

                _Usuario.Add(Us);



            }


            reader.Close();
            ds.CerrarConexion();



        }


        return Us;


    }
}
