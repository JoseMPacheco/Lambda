using Lambda.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO.Compression;
using System.Windows.Forms;
using System.Data;
using System.Linq.Expressions;

namespace Lambda.Controlador
{
    internal class JsonControlador
    {

        ConexionBd conn = new ConexionBd();
        Encriptador encriptador = new Encriptador();


        //obtiene un string de un archivo dentro de un zip
        public string ObtenerContenidoArchivoZIP(string nombreArchivo)
        {
            try
            {
                OpenFileDialog dialogo = new OpenFileDialog();
                dialogo.Filter = "Archivos ZIP|*.zip";
                dialogo.Title = "Seleccionar archivo ZIP";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivoZIP = dialogo.FileName;

                    try
                    {
                        using (ZipArchive archivoZIP = ZipFile.OpenRead(rutaArchivoZIP))
                        {
                            ZipArchiveEntry entrada = archivoZIP.GetEntry(nombreArchivo);
                            if (entrada != null)
                            {
                                using (StreamReader lector = new StreamReader(entrada.Open()))
                                {
                                    return lector.ReadToEnd();
                                }
                            }
                            else
                            {
                                return "El archivo especificado no se encuentra en el archivo ZIP.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Error al leer el archivo ZIP: " + ex.Message;
                    }
                }
                else
                {
                    return "No se seleccionó ningún archivo ZIP.";
                }
            }
            catch (Exception ex)
            {
                return "Error al abrir el archivo ZIP: " + ex.Message;
            }
        }


        //toma un string lo encripta y lo guarda
        public void SaveJsonToFile(string jtext, string nombre)
        {
            string jsonFilePath = "C:\\lambda\\facturas.json";

            // Guardar el JSON en un archivo
            // File.WriteAllText(jsonFilePath, json);

            // Crear un cuadro de diálogo para seleccionar la ubicación del archivo ZIP
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos ZIP (*.zip)|*.zip";
            saveFileDialog.Title = "Guardar archivo ZIP";
            saveFileDialog.FileName = "facturas.zip";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string zipFilePath = saveFileDialog.FileName;

                // Crear un archivo ZIP y agregar el JSON
                using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        ZipArchiveEntry jsonEntry = archive.CreateEntry(nombre + ".json");
                        using (StreamWriter writer = new StreamWriter(jsonEntry.Open()))
                        {
                            string json = encriptador.EncriptarTexto(jtext, "hphphphp");
                            writer.Write(json);
                        }
                    }
                }

                Console.WriteLine("El JSON ha sido comprimido y guardado en el archivo ZIP en la ubicación seleccionada");
            }
        }


        //crea un json con datos de nota de entrega
        public string GetFacturasAsJson(string numerod)
        {
            List<Documento> documentos = new List<Documento>();

            using (SqlConnection connection = conn.GetSQLConnection())
            {
                string query = $@"SELECT NUMEROD, CodItem, NroLote, Cantidad, EsUnid, Costo, Precio FROM SAITEMFAC 
                          where tipofac='C' and numerod = '{numerod}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Realizar conversiones seguras a int y decimal
                            int cantidad;
                            if (!int.TryParse(reader["Cantidad"].ToString(), out cantidad))
                            {

                            }

                            int esUnid;
                            if (!int.TryParse(reader["EsUnid"].ToString(), out esUnid))
                            {

                            }

                            decimal costo;
                            if (!decimal.TryParse(reader["Costo"].ToString(), out costo))
                            {

                            }

                            decimal precio;
                            if (!decimal.TryParse(reader["Precio"].ToString(), out precio))
                            {

                            }


                            Documento documento = new Documento(reader["NUMEROD"].ToString(), reader["CodItem"].ToString(),
                                                                reader["NroLote"].ToString(), cantidad, esUnid, costo, precio);
                            documentos.Add(documento);
                        }
                    }
                }
            }

            return JsonConvert.SerializeObject(documentos);
        }

        //crea un json con datos de la bd
        public string GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = conn.GetSQLConnection())
            {
                string query = @"SELECT CodProd, Descrip, Descrip2, Descrip3, Refere, CodInst, Unidad, UndEmpaq, CantEmpaq, 
                        EsEmpaque, DEsLote, PrecioI1, PrecioI2, PrecioI3, PrecioIU1, PrecioIU2, PrecioIU3 , ESEXENTO, CostAct
                        FROM SAPROD ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Producto y agregarlo a la lista
                            Producto producto = new Producto
                            {
                                CodProd = reader["CodProd"].ToString(),
                                Descrip = reader["Descrip"].ToString(),
                                Descrip2 = reader["Descrip2"].ToString(),
                                Descrip3 = reader["Descrip3"].ToString(),
                                Refere = reader["Refere"].ToString(),
                                CodInst = Convert.ToInt32(reader["CodInst"]),
                                Unidad = reader["Unidad"].ToString(),
                                UndEmpaq = reader["UndEmpaq"].ToString(),
                                CantEmpaq = Convert.ToDecimal(reader["CantEmpaq"]),
                                EsEmpaque = Convert.ToInt32(reader["EsEmpaque"]),
                                DEsLote = Convert.ToInt32(reader["DEsLote"]),
                                PrecioI1 = Convert.ToDecimal(reader["PrecioI1"]),
                                PrecioI2 = Convert.ToDecimal(reader["PrecioI2"]),
                                PrecioI3 = Convert.ToDecimal(reader["PrecioI3"]),
                                PrecioIU1 = Convert.ToDecimal(reader["PrecioIU1"]),
                                PrecioIU2 = Convert.ToDecimal(reader["PrecioIU2"]),
                                PrecioIU3 = Convert.ToDecimal(reader["PrecioIU3"]),
                                Costo = Convert.ToDecimal(reader["CostAct"]),
                                esExento = Convert.ToInt32(reader["ESEXENTO"]),
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }


            return JsonConvert.SerializeObject(productos);
        }

        //lee un archivo encriptado y devuelve el string desencriptado
        public string ReadFileAndConvertToJSON(string textContent)
        {
            try
            {
                string texto = encriptador.DesencriptarTexto(textContent, "hphphphp");
                string t = texto;
                dynamic json = JsonConvert.DeserializeObject(texto);

                return JsonConvert.SerializeObject(json, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "Error al leer el archivo y convertirlo a JSON: " + ex.Message;
            }
        }


        //insert en tabla de actualizacion de productos
        public void InsertJsonToSqlTable(string path)
        {
            try { 
            string json = ReadFileAndConvertToJSON(path);
            Console.Write(json);
            List<SAAXES> saaxesList = JsonConvert.DeserializeObject<List<SAAXES>>(json);

            using (SqlConnection connection = conn.GetSQLConnection())
            {
                connection.Open();

                foreach (var saaxes in saaxesList)
                {
                    string insertQuery = "INSERT INTO SAAXES (CodProd, Descrip, Descrip2, Descrip3, Refere, CodInst, Unidad, UndEmpaq, CantEmpaq, EsEmpaque, DEsLote, PrecioI1, PrecioI2, PrecioI3, PrecioIU1, PrecioIU2, PrecioIU3, EXENTO,COSTO) " +
                                         "VALUES (@CodProd, @Descrip, @Descrip2, @Descrip3, @Refere, @CodInst, @Unidad, @UndEmpaq, @CantEmpaq, @EsEmpaque, @DEsLote, @PrecioI1, @PrecioI2, @PrecioI3, @PrecioIU1, @PrecioIU2, @PrecioIU3, @EXENTO,@COSTO)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@CodProd", saaxes.CodProd);
                    command.Parameters.AddWithValue("@Descrip", saaxes.Descrip);
                    command.Parameters.AddWithValue("@Descrip2", saaxes.Descrip2);
                    command.Parameters.AddWithValue("@Descrip3", saaxes.Descrip3);
                    command.Parameters.AddWithValue("@Refere", saaxes.Refere);
                    command.Parameters.AddWithValue("@CodInst", saaxes.CodInst);
                    command.Parameters.AddWithValue("@Unidad", saaxes.Unidad);
                    command.Parameters.AddWithValue("@UndEmpaq", saaxes.UndEmpaq);
                    command.Parameters.AddWithValue("@CantEmpaq", saaxes.CantEmpaq);
                    command.Parameters.AddWithValue("@EsEmpaque", saaxes.EsEmpaque);
                    command.Parameters.AddWithValue("@DEsLote", saaxes.DEsLote);
                    command.Parameters.AddWithValue("@PrecioI1", saaxes.PrecioI1);
                    command.Parameters.AddWithValue("@PrecioI2", saaxes.PrecioI2);
                    command.Parameters.AddWithValue("@PrecioI3", saaxes.PrecioI3);
                    command.Parameters.AddWithValue("@PrecioIU1", saaxes.PrecioIU1);
                    command.Parameters.AddWithValue("@PrecioIU2", saaxes.PrecioIU2);
                    command.Parameters.AddWithValue("@PrecioIU3", saaxes.PrecioIU3);
                    command.Parameters.AddWithValue("@COSTO", saaxes.Costo);
                    command.Parameters.AddWithValue("@EXENTO", saaxes.esExento);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Los datos del archivo JSON han sido insertados en la tabla de SQL");
            }
            }
            catch(Exception e)
            { MessageBox.Show("Archivo no valido"); }

        }
    
        //inserta en tabla de cargo
    public void InsertJsonToSqlTableFac(string path)
    {
            try
            {

                string json = ReadFileAndConvertToJSON(path);
                List<SAAXES2> saaxesList = JsonConvert.DeserializeObject<List<SAAXES2>>(json);

                using (SqlConnection connection = conn.GetSQLConnection())
                {
                    connection.Open();

                    foreach (var saaxes2 in saaxesList)
                    {
                        string insertQuery = @"INSERT INTO [dbo].[SAAXES2]
           ([NUMEROD]
           ,[CODITEM]
           ,[NROLOTE]
           ,[CANTIDAD]
           ,[ESUNID]
           ,[COSTO]
           ,[PRECIO]) VALUES (@numerod, @coditem,@nrolote, @cantidad,@esunid, @costo, @precio)";
                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@numerod", saaxes2.NUMEROD);
                        command.Parameters.AddWithValue("@coditem", saaxes2.CODITEM);
                        command.Parameters.AddWithValue("@nrolote", saaxes2.NROLOTE);
                        command.Parameters.AddWithValue("@cantidad", saaxes2.CANTIDAD);
                        command.Parameters.AddWithValue("@esunid", saaxes2.ESUNID);
                        command.Parameters.AddWithValue("@costo", saaxes2.COSTO);
                        command.Parameters.AddWithValue("@precio", saaxes2.PRECIO);



                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Los datos del archivo JSON han sido insertados en la tabla de SQL");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Archivo no valido");
            }
    }
}


}
