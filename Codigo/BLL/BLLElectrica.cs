using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;

namespace BLL
{
    public class BLLElectrica : BLLCalefactor, IGestor<BEElectrica>
    {
        MPPElectrica oMPPElectrica = new MPPElectrica();

        public override float DescuentoCalculado(BECalefactor oBECal)
        {
            return oBECal.Precio * 0.85f;
        }

        public List<BEElectrica> ListarTodo()
        {
            var lista = oMPPElectrica.ListarTodo();
            foreach (var item in lista)
            {
                item.PrecioConDescuento = DescuentoCalculado(item);
            }
            return lista;
        }

        public bool Guardar(BEElectrica oBEElectrica)
        {
            return oMPPElectrica.Guardar(oBEElectrica);
        }

        public bool Baja(BEElectrica oBEElectrica)
        {
            return oMPPElectrica.Baja(oBEElectrica);
        }

        public BEElectrica ListarObjeto(BEElectrica oBEElectrica)
        {
            return oMPPElectrica.ListarObjeto(oBEElectrica);
        }

        public List<BEElectrica> ObtenerCalefactoresElectricosMenosSolicitados()
        {
            return oMPPElectrica.ObtenerCalefactoresElectricosMenosSolicitados();
        }
    }
}