using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final.Models
{

    public class Venta
    {
        public int id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta()
        {
            id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;

        }
    }

}