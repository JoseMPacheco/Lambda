using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
using System.Data.SqlClient;

namespace Conexion
{
    public partial class Form1 : Form
    {

        string consulta = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SAAXES')
BEGIN
    CREATE TABLE [dbo].[SAAXES](
        [CodProd] [varchar](25) NOT NULL,
        [Descrip] [varchar](40) NULL,
        [Descrip2] [varchar](40) NULL,
        [Descrip3] [varchar](40) NULL,
        [Refere] [varchar](25) NULL,
        [CodInst] [int] NULL,
        [Unidad] [varchar](3) NULL,
        [UndEmpaq] [varchar](3) NULL,
        [CantEmpaq] [int] NULL,
        [EsEmpaque] [int] NULL,
        [DEsLote] [int] NULL,
        [PrecioI1] [decimal](28, 4) NULL,
        [PrecioI2] [decimal](28, 4) NULL,
        [PrecioI3] [decimal](28, 4) NULL,
        [PrecioIU1] [decimal](28, 4) NULL,
        [PrecioIU2] [decimal](28, 4) NULL,
        [PrecioIU3] [decimal](28, 4) NULL,
        [exento] [int] NULL,
        [costo] [decimal](28, 4) NULL,
        PRIMARY KEY CLUSTERED 
        (
            [CodProd] ASC
        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
END
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SAAXES2')
BEGIN
CREATE TABLE [dbo].[SAAXES2](
	[NUMEROD] [varchar](25) NOT NULL,
	[CODITEM] [varchar](25) NOT NULL,
	[NROLOTE] [varchar](25) NULL,
	[CANTIDAD] [int] NULL,
	[ESUNID] [int] NULL,
	[COSTO] [decimal](28, 4) NULL,
	[PRECIO] [decimal](28, 4) NULL,
 CONSTRAINT [SAAXES2_IXO] PRIMARY KEY CLUSTERED 
(
	[NUMEROD] ASC,
	[CODITEM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
end




";
       
        public static String ReaderConnParam(String param)
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
                            switch (param)
                            {
                                case "server":
                                    return server;
                                    break;
                                case "bd":
                                    return bd;
                                    break;
                                case "user":
                                    return user;
                                    break;
                                case "pass":
                                    return pass;
                                    break;
                            }


                        }
                    }
                }
            }
            catch (Exception e)
            {

                return null;
            }

            return null;

        }


        String ruta = "C:\\pnp\\";
        String archivo = "conex.txt";
        String server = ReaderConnParam("server");
        String bd = ReaderConnParam("bd");
        String user = ReaderConnParam("user");
        String pass = ReaderConnParam("pass");
        Hashtable tablaHash = new Hashtable();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbServidor.Text = server;
            tbBd.Text = bd;
            tbUsuario.Text = user;
            tbPass.Text = pass;
            tablaHash.Add("Autenticacion de Windows", 2);
            tablaHash.Add("Autenticacion de sql Server", 1);

            cbTipoConn.DataSource = new BindingSource(tablaHash, null);
            cbTipoConn.DisplayMember = "Key";
            cbTipoConn.ValueMember = "Value";

        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            FileStream fs;
            // :::Validamos si la carpeta de ruta existe, si no existe la creamos
            try
            {
                if (File.Exists(ruta))
                {

                    // :::Si la carpeta existe creamos o sobreescribios el archivo txt
                    fs = File.Create(ruta + archivo);
                    fs.Close();
                    // :::Escribimos una linea en nuestro archivo TXT con el formato que este separado por coma (,)
                    StreamWriter escribir = new StreamWriter(ruta + archivo);
                    // :::Escribimos una linea en nuestro archivo TXT con el formato que este separado por coma (,)
                    int COMBO = (int)cbTipoConn.SelectedValue;
                    escribir.WriteLine(tbServidor.Text + ";" + tbBd.Text + ";" + tbUsuario.Text + ";" + tbPass.Text + ";" + COMBO.ToString());
                    escribir.Close();
                    MessageBox.Show("Registro guardado correctamente");
                    tbServidor.Clear();
                    tbBd.Clear();
                    tbUsuario.Clear();
                    tbPass.Clear();
                    MessageBox.Show("Archivo de conexion creado");
                }
                else
                {
                    // :::Si la carpeta no existe la creamos
                    Directory.CreateDirectory(ruta);
                    // :::Una vez creada la carpeta creamos o sobreescribios el archivo txt
                    fs = File.Create(ruta + archivo);
                    fs.Close();
                    StreamWriter escribir = new StreamWriter(ruta + archivo);
                    // :::Escribimos una linea en nuestro archivo TXT con el formato que este separado por coma (,)
                    int COMBO = (int)cbTipoConn.SelectedValue;
                    escribir.WriteLine(tbServidor.Text + ";" + tbBd.Text + ";" + tbUsuario.Text + ";" + tbPass.Text + ";" + COMBO.ToString());
                    escribir.Close();
                    server = tbServidor.Text;
                    bd = tbBd.Text;
                    user = tbUsuario.Text;
                    pass = tbPass.Text;
                    SqlConnection conex1;
                    conex1 = new SqlConnection("Data Source=" + server + ";Initial Catalog=" + bd + ";User ID=" + user + ";password=" + pass);
                    try
                    {
                        conex1.Open();
                        MessageBox.Show("conexion satisfactoria");
                        try
                        {
                            SqlCommand command = new SqlCommand(consulta, conex1);
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                            tbServidor.Clear();
                        tbBd.Clear();
                        tbUsuario.Clear();
                        tbPass.Clear();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un problema al momento de crear el archivo: " + ex);
            }

        }
    }
}
