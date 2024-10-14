using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECalefactor:Entidad
    {
        //propiedades de la clase Calefactor

        public string Nombre { get; set; }
        public int Calorias { get; set; }
        public string Modelo { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public float Precio { get; set; }
        public float PrecioConDescuento { get; set; }

        //relacion 1 a 1
        public BEProveedor oBEProveedor { get; set; }
    }
}
