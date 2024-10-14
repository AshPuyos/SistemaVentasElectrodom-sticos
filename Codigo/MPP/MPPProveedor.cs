using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace MPP
{
    public class MPPProveedor:IGestor<BEProveedor>
    {
        Acceso oDatos;

        public List<BEProveedor> ListarTodo()
        {
            DataTable Tabla;
            oDatos = new Acceso();
            Tabla = oDatos.Leer("Select Codigo, RazonSocial, Cuit From Proveedor");
            List<BEProveedor> ListaProveedor = new List<BEProveedor>();

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEProveedor oBEPro = new BEProveedor();
                    oBEPro.Codigo = Convert.ToInt32(fila["Codigo"]);
                    oBEPro.RazonSocial = fila["RazonSocial"].ToString();
                    oBEPro.Cuit = Convert.ToInt32(fila["Cuit"]);
                    ListaProveedor.Add(oBEPro);
                }
            }
            else
            {
                ListaProveedor = null;
            }
            return ListaProveedor;
        }

        public bool Existe_Proveedor_Asociado(BEProveedor oBEPro)
        {
            oDatos = new Acceso();
            return oDatos.LeerScalar("select count(CodProveedor) from Calefactor where CodProveedor =" + oBEPro.Codigo + "");
        }

        public bool Guardar(BEProveedor oBEProveedor)
        {
            try
            {
                if (ExisteProveedorConCuit(oBEProveedor.Cuit))
                {
                    throw new Exception("Ya existe un proveedor con el mismo CUIT.");
                }

                string consultaSQL = "INSERT INTO Proveedor (RazonSocial, Cuit) VALUES ('" + oBEProveedor.RazonSocial + "', " + oBEProveedor.Cuit + ")";
                return oDatos.Escribir(consultaSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el Proveedor", ex);
            }

        }

        public bool Baja(BEProveedor Objeto)
        {
            throw new NotImplementedException();
        }

        public BEProveedor ListarObjeto(BEProveedor Objeto)
        {
            throw new NotImplementedException();
        }

        public bool ExisteProveedorConCuit(int cuit)
        {
            string consulta = $"SELECT COUNT(*) FROM Proveedor WHERE Cuit = {cuit}";
            return oDatos.LeerScalar(consulta);
        }
    }
}
