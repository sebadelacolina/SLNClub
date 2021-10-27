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
    public static class AdmJugador
    {
        public static List<Jugador> Listar()
        {
            string consulta = "SELECT Id, Nombre, Apellido, FechaNacimiento, Puesto FROM dbo.Jugador";

            SqlCommand comando = new SqlCommand(consulta, AdmDB.ConectarBase());

            SqlDataReader reader = comando.ExecuteReader();

            List<Jugador> list = new List<Jugador>();

            while (reader.Read())
            {
                list.Add
                (
                new Jugador()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = Convert.ToString(reader["Nombre"]),
                    Apellido = Convert.ToString(reader["Apellido"]),
                    FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                    Puesto= Convert.ToString(reader["Puesto"])
                }
                );
            }
            AdmDB.ConectarBase().Close();
            reader.Close();
            return list;
        }

        public static DataTable Listar(string puesto)
        {
            string consulta = "SELECT Id, Nombre, Apellido, FechaNacimiento, Puesto FROM dbo.Jugador WHERE Puesto=@Puesto";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdmDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = puesto;

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "Jugador");

            return dataSet.Tables["Jugador"];
        }

        public static int Insertar(Jugador jugador)
        {
            string insertSQL = "INSERT dbo.Jugador (Nombre, Apellido, FechaNacimiento, Puesto) VALUES(@Nombre, @Apellido, @FechaNacimiento, @Puesto)";

            SqlCommand command = new SqlCommand(insertSQL, AdmDB.ConectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = jugador.Apellido;
            command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
            command.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = jugador.Puesto;

            int filasAfectadas = command.ExecuteNonQuery();

            AdmDB.ConectarBase().Close();
            return filasAfectadas;
        }

        public static int Eliminar(int id)
        {
            string insertSQL = "DELETE FROM dbo.Jugador WHERE Id = @Id";

            SqlCommand command = new SqlCommand(insertSQL, AdmDB.ConectarBase());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdmDB.ConectarBase().Close();

            return filasAfectadas;
        }

        public static int Modificar(Jugador jugador)
        {
            string insertSQL = "UPDATE dbo.Jugador SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Puesto = @Puesto WHERE Id = @Id ";

            SqlCommand command = new SqlCommand(insertSQL, AdmDB.ConectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = jugador.Apellido;
            command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = jugador.Id;
            command.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = jugador.Puesto;

            int filasAfectadas = command.ExecuteNonQuery();

            AdmDB.ConectarBase().Close();

            return filasAfectadas;
        }




    }
}
