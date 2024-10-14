using System;
using System.Collections.Generic;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLGas : BLLCalefactor, IGestor<BEGas>
    {
        MPPGas oMPPGas = new MPPGas();

        public override float DescuentoCalculado(BECalefactor oBECal)
        {
            return oBECal.Precio * 0.75f;
        }

        public List<BEGas> ListarTodo()
        {
            var lista = oMPPGas.ListarTodo();
            foreach (var item in lista)
            {
                item.PrecioConDescuento = DescuentoCalculado(item);
            }
            return lista;
        }

        public bool Guardar(BEGas oBEGas)
        {
            return oMPPGas.Guardar(oBEGas);
        }

        public bool Baja(BEGas oBEGas)
        {
            return oMPPGas.Baja(oBEGas);
        }

        public BEGas ListarObjeto(BEGas oBEGas)
        {
            return oMPPGas.ListarObjeto(oBEGas);
        }

        public List<BEGas> ObtenerCalefactoresGasMasSolicitados()
        {
            return oMPPGas.ObtenerCalefactoresGasMasSolicitados();
        }
    }
}
