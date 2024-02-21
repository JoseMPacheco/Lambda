using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambda.Controlador
{
    public class Vistas
    {

        ConexionBd op = new ConexionBd();

       

        public void llenarListReporte(ListView listView)
        {
            string consulta = @"select itemname from SAITRE";
            try
            {
                using (SqlConnection connection = op.GetSQLConnection())
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(consulta, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    listView.Clear();
                    listView.View = View.Details;
                    listView.GridLines = true;
                    listView.FullRowSelect = true;

                    // Agregar columnas al ListView
                    listView.Columns.Add("Descripción", 200);



                    while (reader.Read())
                    {
                        string[] row = new string[1];
                        ListViewItem item;


                        row[0] = reader.GetString(0);




                        item = new ListViewItem(row);

                        listView.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        public void llenarListItemsCargo(ListView listView)
        {
            string consulta = @"select NUMEROD, CODITEM,p.descrip,  NROLOTE, cast(cast(CANTIDAD as int) as varchar) , 
CASE WHEN ESUNID=1 THEN P.UndEmpaq WHEN ESUNID=0 THEN P.Unidad END AS 'ESUNID' from saaxes2 S
INNER JOIN SAPROD P ON S.CODITEM=P.CodProd";
            try
            {
                using (SqlConnection connection = op.GetSQLConnection())
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(consulta, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    listView.Clear();
                    listView.View = View.Details;
                    listView.GridLines = true;
                    listView.FullRowSelect = true;

                    // Agregar columnas al ListView
                    listView.Columns.Add("Nro. Documento", 100);
                    listView.Columns.Add("Codigó", 100);
                    listView.Columns.Add("Descripción", 200);
                    listView.Columns.Add("Nro. Lote", 100);
                    listView.Columns.Add("Cantidad", 75);
                    listView.Columns.Add("Tipo de Unid", 70);


                    while (reader.Read())
                    {
                        string[] row = new string[6];
                        ListViewItem item;


                        row[0] = reader.GetString(0);
                        row[1] = reader.GetString(1);
                        row[2] = reader.GetString(2);
                        row[3] = reader.GetString(3);
                        row[4] = reader.GetString(4);
                        row[5] = reader.GetString(5);
         




                        item = new ListViewItem(row);

                        listView.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        public void llenarListProducto(ListView listView)
        {
            string consulta = @" SELECT CodProd,Descrip, Descrip2, Descrip3,Refere, cast(CodInst as varchar),Unidad,UndEmpaq, cast(CantEmpaq as varchar),
                                cast(EsEmpaque as varchar), cast(DEsLote as varchar), 
                                cast(PrecioI1 as varchar),cast(PrecioI2 as varchar),
                                cast(PrecioI3 as varchar), cast(PrecioIU1 as varchar),
                                cast(PrecioIU2 as varchar),cast(PrecioIU3 as varchar)
                                FROM SAPROD ";
            try
            {
                using (SqlConnection connection = op.GetSQLConnection())
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(consulta, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    listView.Clear();
                    listView.View = View.Details;
                    listView.GridLines = true;
                    listView.FullRowSelect = true;

                    // Agregar columnas al ListView
                    listView.Columns.Add("codigo", 60);
                    listView.Columns.Add("descripción", 120);
                    listView.Columns.Add("descripción 2", 120);
                    listView.Columns.Add("descripción 3", 120);
                    listView.Columns.Add("referencia ", 80);
                    listView.Columns.Add("instacia", 50);
                    listView.Columns.Add("Unidad", 50);
                    listView.Columns.Add("UndEmpaq", 50);
                    listView.Columns.Add("Cant. Empaq", 50);
                    listView.Columns.Add("Usa Empaque", 50);
                    listView.Columns.Add("Usa Lote", 50);
                    listView.Columns.Add("Precio 1", 60);
                    listView.Columns.Add("Precio 2", 60);
                    listView.Columns.Add("Precio 3", 60);
                    listView.Columns.Add("Precio Und 1", 60);
                    listView.Columns.Add("Precio Und 2", 60);
                    listView.Columns.Add("Precio Und 3", 60);


                    while (reader.Read())
                    {
                        string[] row = new string[17];
                        ListViewItem item;


                        row[0] = reader.GetString(0);
                        row[1] = reader.GetString(1);
                        row[2] = reader.GetString(2);
                        row[3] = reader.GetString(3);
                        row[4] = reader.GetString(4);
                        row[5] = reader.GetString(5);
                        row[6] = reader.GetString(6);
                        row[7] = reader.GetString(7);
                        row[8] = reader.GetString(8);
                        row[9] = reader.GetString(9);
                        row[10] = reader.GetString(10);
                        row[11] = reader.GetString(11);
                        row[12] = reader.GetString(12);
                        row[13] = reader.GetString(13);
                        row[14] = reader.GetString(14);
                        row[15] = reader.GetString(15);
                        row[16] = reader.GetString(16);



                        item = new ListViewItem(row);

                        listView.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        public void LlenarListView(ListView listView, string desde, string hasta)
        {

            string consulta = $@"SELECT NUMEROD, 'N/E', CODCLIE, 
                                DESCRIP, cast(MONTO as varchar), cast(cast(FECHAE as date) as varchar) FROM SAFACT
                                where tipofac='C' 
                                and cast(fechae as date) >= cast('{desde}' as date) and
                                cast(fechae as date) <= cast('{hasta}' as date) ";

            try
            {
                using (SqlConnection connection = op.GetSQLConnection())
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(consulta, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    listView.Clear();
                    listView.View = View.Details;
                    listView.GridLines = true;
                    listView.FullRowSelect = true;

                    // Agregar columnas al ListView
                    listView.Columns.Add("Documento", 75);
                    listView.Columns.Add("Tipo", 40);
                    listView.Columns.Add("Cliente", 80);
                    listView.Columns.Add("Descripcion", 120);
                    listView.Columns.Add("Monto", 70);
                    listView.Columns.Add("Fecha", 70);

                    while (reader.Read())
                    {
                        string[] row = new string[6];
                        ListViewItem item;


                        row[0] = reader.GetString(0);
                        row[1] = reader.GetString(1);
                        row[2] = reader.GetString(2);
                        row[3] = reader.GetString(3);
                        row[4] = reader.GetString(4);
                        row[5] = reader.GetString(5);


                        item = new ListViewItem(row);

                        listView.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    } 
  
}
