using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
//referecnia a la capa abstraccion
using Abstraccion;

namespace BLL
{
    public class BLLProveedor: IGestor<BEProveedor>
    {
        #region "Metodos Proveedor BLL"

        public BLLProveedor()
        {
            oMMPro = new MPPProveedor();
        }

        MPPProveedor oMMPro;
        public List<BEProveedor> ListarTodo()
        {
            return oMMPro.ListarTodo();
        }

        //Metodo para guardar si es alta o modificacion
        public bool Guardar(BEProveedor oBEProveedor)
        {
            if (oMMPro.ExisteProveedorConCuit(oBEProveedor.Cuit))
            {
                throw new Exception("Ya existe un proveedor con el mismo CUIT");
            }
            return oMMPro.Guardar(oBEProveedor);
        }
        public bool Baja(BEProveedor oBEProveedor)
        {
            return oMMPro.Baja(oBEProveedor);
        }

        public BEProveedor ListarObjeto(BEProveedor Objeto)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
