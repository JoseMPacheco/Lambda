using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Modelo
{
    public class Producto
    {
        public string CodProd { get; set; }
        public string Descrip { get; set; }
        public string Descrip2 { get; set; }
        public string Descrip3 { get; set; }
        public string Refere { get; set; }
        public int CodInst { get; set; }
        public string Unidad { get; set; }
        public string UndEmpaq { get; set; }
        public decimal CantEmpaq { get; set; }
        public int EsEmpaque { get; set; }
        public int DEsLote { get; set; }
        public decimal PrecioI1 { get; set; }
        public decimal PrecioI2 { get; set; }
        public decimal PrecioI3 { get; set; }
        public decimal PrecioIU1 { get; set; }
        public decimal PrecioIU2 { get; set; }
        public decimal PrecioIU3 { get; set; }

        public int esExento { get; set; }

        public decimal Costo { get; set; }
        public Producto() { }

        public Producto(string codProd, string descrip, string descrip2, string descrip3, string refere, int codInst, string unidad, string undEmpaq, decimal cantEmpaq, int esEmpaque, int dEsLote, decimal precioI1, decimal precioI2, decimal precioI3, decimal precioIU1, decimal precioIU2, decimal precioIU3, int esexento, decimal costo)
        {
            CodProd = codProd;
            Descrip = descrip;
            Descrip2 = descrip2;
            Descrip3 = descrip3;
            Refere = refere;
            CodInst = codInst;
            Unidad = unidad;
            UndEmpaq = undEmpaq;
            CantEmpaq = cantEmpaq;
            EsEmpaque = esEmpaque;
            DEsLote = dEsLote;
            PrecioI1 = precioI1;
            PrecioI2 = precioI2;
            PrecioI3 = precioI3;
            PrecioIU1 = precioIU1;
            PrecioIU2 = precioIU2;
            PrecioIU3 = precioIU3;
            esExento = esexento;
            Costo = costo;
        }
    }
}
