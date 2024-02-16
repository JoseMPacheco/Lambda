using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambda.Controlador
{
    internal class ConexionBd
    {

        public SqlConnection GetSQLConnection()
        {
            try
            {
                string ruta = "C:\\lambda\\conex.txt";

                // Use FileStream to open the file with exclusive access
                using (FileStream fileStream = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        string[] lineas = sr.ReadToEnd().Split('\n');

                        foreach (string line in lineas)
                        {
                            string[] partes = line.Split(';');

                            string server = partes[0];
                            string bd = partes[1];
                            string user = partes[2];
                            string pass = partes[3];
                            int estado = int.Parse(partes[4]);

                            SqlConnection connection = null;

                            switch (estado)
                            {
                                case 1:
                                    string connectionsql = $"Data Source={server};Initial Catalog={bd};User ID={user};Password={pass};TrustServerCertificate=True;";
                                    connection = new SqlConnection(connectionsql);
                                    break;
                                case 2:
                                    string connectionwindows = $"Data Source=.;Initial Catalog={bd};Integrated Security=True;TrustServerCertificate=True;";
                                    connection = new SqlConnection(connectionwindows);
                                    break;
                            }

                            if (connection != null)
                            {
                                return connection;
                            }
                            sr.Close();
                        }
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                return null;
            }
        }
    }
}
