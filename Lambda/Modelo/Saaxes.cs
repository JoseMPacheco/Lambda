using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Modelo
{
    public class SAAXES
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
    }
}
