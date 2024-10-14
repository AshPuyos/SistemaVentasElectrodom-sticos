using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente:Entidad
    {
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public int Dni { get; set; }
        public float TotalDescuento { get; set; }

        public List<BECalefactor> ListaCalefactores { get; set; }

        public BECliente()
        {
            ListaCalefactores = new List<BECalefactor>();
        }

        public override string ToString()
        {
            return $"{Codigo} {Nombre}";
        }
    }
}
