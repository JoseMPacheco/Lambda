using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Lambda.Consulta;
using Lambda.Controlador;

namespace Lambda
{
    public partial class panel : Form
    {
        string numerod = null;

        List<string> listaOpciones = new List<string>();
        Encriptador encriptador = new Encriptador();
        JsonControlador json = new JsonControlador();
        Vistas v = new Vistas();
        SqlComand comaandos = new SqlComand();

        public panel()
        {
            try
            {
                InitializeComponent();


                listaOpciones.Add("Productos");
                listaOpciones.Add("Carga");
                //listaOpciones.Add("Reportes");




                cbTipo.DataSource = listaOpciones;

                btnCargo.Visible = false;
                btnCancelar.Visible = false;

                comaandos.LimpiarData();
            }
            catch (Exception e)
            {

            }

        }

        private void lvMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMain.SelectedItems.Count > 0)
            {
                numerod = lvMain.SelectedItems[0].SubItems[0].Text;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

       


        private void pictureBox3_Click(object sender, EventArgs e)
        {



        }

        private void cargarListView()
        {
            switch (cbTipo.Text)
            {
                case "Carga":
                    lbdesde.Visible = true;
                    lbhasta.Visible = true;
                    dpdesde.Visible = true;
                    dphasta.Visible = true;
                    v.LlenarListView(lvMain, dpdesde.Text, dphasta.Text);
                    break;
                case "Productos":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    v.llenarListProducto(lvMain);
                    break;
                case "Reportes":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    v.llenarListReporte(lvMain);
                    break;
                default:
                    break;
            }
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            cargarListView();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbTipo.Text)
            {
                case "Carga":
                    lbdesde.Visible = true;
                    lbhasta.Visible = true;
                    dpdesde.Visible = true;
                    dphasta.Visible = true;

                    v.LlenarListView(lvMain, dpdesde.Text, dphasta.Text);


                    if (numerod != null)
                    {
                        string archivoCarga = json.GetFacturasAsJson(numerod);
                        json.SaveJsonToFile(archivoCarga, "ne");
                    }
                    else
                    {
                        MessageBox.Show("Selecione una N/E");
                    }
                    break;
                case "Productos":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    v.llenarListProducto(lvMain);
                    string productos = json.GetProductos();
                    json.SaveJsonToFile(productos, "in");
                    break;
                case "Reportes":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    v.llenarListReporte(lvMain);
                    break;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cargarListView();
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                     "¿Esta seguro que quiero continuar la transacción? " +
                     "es un proceso IRREVERSIBLE",
                     "Confirmación",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show(
                     "Confirme que esta Totalmente deacuerdo que contnue la transacción" +
                     "es un proceso IRREVERSIBLE",
                     "Confirmación",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2);
                if (result2 == DialogResult.Yes)
                {
                    comaandos.updateCargo();
                    comaandos.LimpiarData();
                }
                else
                {

                }
            }
            else
            {

            }
        }
        private void Vista()
        {
            btnCancelar.Visible = false;
            btnCargo.Visible = false;
            btnGenerar.Visible = true;
            pcBuscar.Visible = true;
            cbTipo.Visible = true;

        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                     "¿Cancelar Transacción?",
                     "Confirmación",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                comaandos.LimpiarData();
                Vista();

            }
            else
            {

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (cbTipo.Text)
            {
                case "Carga":
                    lbdesde.Visible = true;
                    lbhasta.Visible = true;
                    dpdesde.Visible = true;
                    dphasta.Visible = true;
                    btnCargo.Visible = true;
                    btnCancelar.Visible = true;
                    btnGenerar.Visible = false;
                    pcBuscar.Visible = false;

                    string textoencriptado = json.ObtenerContenidoArchivoZIP("ne.json");
                    json.InsertJsonToSqlTableFac(textoencriptado);
                    v.llenarListItemsCargo(lvMain);
                    break;
                case "Productos":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    textoencriptado = json.ObtenerContenidoArchivoZIP("in.json");
                    json.InsertJsonToSqlTable(textoencriptado);
                    comaandos.updateProductos();
                    break;
                case "Reportes":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (cbTipo.Text)
            {
                case "Carga":
                    lbdesde.Visible = true;
                    lbhasta.Visible = true;
                    dpdesde.Visible = true;
                    dphasta.Visible = true;

                    v.LlenarListView(lvMain, dpdesde.Text, dphasta.Text);


                    if (numerod != null)
                    {
                        string archivoCarga = json.GetFacturasAsJson(numerod);
                        json.SaveJsonToFile(archivoCarga, "ne");
                    }
                    else
                    {
                        MessageBox.Show("Selecione una N/E");
                    }
                    break;
                case "Productos":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    v.llenarListProducto(lvMain);
                    string productos = json.GetProductos();
                    json.SaveJsonToFile(productos, "in");
                    break;
                case "Reportes":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    v.llenarListReporte(lvMain);
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "¿Cancelar Transacción?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
           );

            if (result == DialogResult.Yes)
            {
                comaandos.LimpiarData();
                Vista();

            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "¿Esta seguro que quiero continuar la transacción? " +
                    "es un proceso IRREVERSIBLE",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
           );

            if (result == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show(
                     "Confirme que esta Totalmente deacuerdo que contnue la transacción" +
                     "es un proceso IRREVERSIBLE",
                     "Confirmación",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button2);
                if (result2 == DialogResult.Yes)
                {
                    comaandos.updateCargo();
                    comaandos.LimpiarData();
                }
                else
                {

                }
            }
            else
            {

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
