using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Models;

namespace Entidades.Datos
{
    public static class AdmPuesto
    {
        public static DataTable Listar()
        {
            string consulta = "select Id, Nombre from dbo.Puesto";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdmDB.ConectarBase());

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "Puesto");

            return dataSet.Tables["Puesto"];
        }

    }
}
