using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public abstract class BLLCalefactor
    {
        public abstract float DescuentoCalculado(BECalefactor oBECal);

    }
}
