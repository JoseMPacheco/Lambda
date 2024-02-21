using Lambda.Controlador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Consulta
{
    public class SqlComand
    {

        ConexionBd conn = new ConexionBd();
        SQL consultas = new SQL();

        public void updateProductos()
        {
            using (SqlConnection connection = conn.GetSQLConnection())
            {
                string consulta = consultas.UPDATE_PRODUCTOS();
                connection.Open();

                SqlCommand command = new SqlCommand(consulta, connection);
                command.ExecuteNonQuery();

                connection.Close();

            }

        }


        public void updateCargo()
        {
            using (SqlConnection connection = conn.GetSQLConnection())
            {
                string consulta = consultas.updateCargo();
                connection.Open();

                SqlCommand command = new SqlCommand(consulta, connection);
                command.ExecuteNonQuery();

                connection.Close();

            }

        }

        public void LimpiarData()
        {
            using (SqlConnection connection = conn.GetSQLConnection())
            {
                string consulta = consultas.limpiar();
                connection.Open();

                SqlCommand command = new SqlCommand(consulta, connection);
                command.ExecuteNonQuery();

                connection.Close();

            }

        }

    }
}
