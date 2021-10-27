using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades.Datos
{
    public static class AdmDB
    {
        public static SqlConnection ConectarBase()
        {
            string cadena = Entidades.Properties.Settings.Default.KeyDBClub;

            SqlConnection conexion = new SqlConnection(cadena);

            conexion.Open();

            return conexion;
        }
    }
}
