using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambda.Modelo
{
    public class Documento
    {
        public string Numerod { get; set; }

        public string CodItem { get; set; }

        public string NroLote { get; set; }

        public int Cantidad { get; set; }

        public int EsUnid { get; set; }

        public decimal Costo { get; set; }

        public decimal Precio { get; set; }

        public Documento()
        {

        }

        public Documento(string numerod, string codItem, string nroLote,
            int cantidad, int esUnid, decimal costo, decimal precio) 
        {
            Numerod = numerod;
            CodItem = codItem;
            NroLote = nroLote;
            Cantidad = cantidad;
            EsUnid = esUnid;
            Costo = costo;
            Precio = precio;
        }

    

        //SELECT NUMEROD, CodItem, NroLote, Cantidad, EsUnid, Costo, Precio FROM SAITEMFAC
    }
}
