using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.Models
{

    public class Usuario
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public Usuario()
        {
            id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            Mail = string.Empty;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int num)
        {
            id = num;
        }



        public string getNombre()
        {
            return Nombre;
        }

        public void setNombre(string s)
        {
            Nombre = s;
        }
        public string getApellido()
        {
            return Apellido;
        }

        public void setApellido(string s)
        {
            Apellido = s;
        }

        public string getNombreUsuario()
        {
            return NombreUsuario;
        }

        public void setNombreUsuario(string s)
        {
            NombreUsuario = s;
        }

        public string getContraseña()
        {
            return Contraseña;
        }


        public void setContraseña(string s)
        {
            Contraseña = s;
        }

        public string getmail()
        {
            return Mail;
        }

        public void setmail(string s)
        {
            Mail = s;
        }
    }


}






