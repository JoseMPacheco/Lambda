using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lambda.Controlador;
using Lambda.Modelo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Lambda
{
    public partial class Main : Form
    {
        string numerod = null;


        Encriptador encriptador = new Encriptador();
        JsonControlador json = new JsonControlador();
        Vistas v = new Vistas();
        public Main()
        {
            InitializeComponent();

            List<string> listaOpciones = new List<string>();
            listaOpciones.Add("Productos");
            listaOpciones.Add("Carga");
            listaOpciones.Add("Reportes");

            cbTipo.DataSource = listaOpciones;
           


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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //encriptador.EncriptarTexto("hola", "C:\\pnp\\hola.txt", "hphphphp");
            string jsonText = json.GetFacturasAsJson("00000019");

           // encriptador.EncriptarTexto(jsonText, "C:\\lambda\\hola.txt", "hphphphp");
            json.SaveJsonToFile(jsonText, "factura.json");
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {


            switch (cbTipo.Text)
            {
                case "Carga":
                    lbdesde.Visible = true;
                    lbhasta.Visible = true;
                    dpdesde.Visible = true;
                    dphasta.Visible = true;
                    //v.LlenarListView(lvMain, dpdesde.Text, dphasta.Text);
                    string hola = json.ObtenerContenidoArchivoZIP("ne.json");
                    string chola = encriptador.DesencriptarTexto(hola, "hphphphp");

                    MessageBox.Show(chola);
                    break;
                case "Productos":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                    //v.llenarListProducto(lvMain);
                     hola = json.ObtenerContenidoArchivoZIP("in.json");
                  chola = encriptador.DesencriptarTexto(hola,"hphphphp");
                    
                    //MessageBox.Show(chola);
                    break;
                case "Reportes":
                    lbdesde.Visible = false;
                    lbhasta.Visible = false;
                    dpdesde.Visible = false;
                    dphasta.Visible = false;
                   // v.llenarListReporte(lvMain);
                    break;
            }


            /*
            string textContent = File.ReadAllText("C:\\lambda\\factura.json");
            MessageBox.Show(encriptador.DesencriptarTexto(textContent, "hphphphp"));
            if (dpdesde.Visible == true || dphasta.Visible == true)
            {
                v.LlenarListView(lvMain, dpdesde.Text, dphasta.Text);
            }*/
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
                    string productos=json.GetProductos();
                    json.SaveJsonToFile(productos,"in");
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

   

    }
}
