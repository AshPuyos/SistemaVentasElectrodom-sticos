using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProveedor:Entidad
    {
        public string RazonSocial { get; set; }
        public int Cuit { get; set; }

        public override string ToString()
        {
            return Codigo + " " + RazonSocial;
        }
    }
}
