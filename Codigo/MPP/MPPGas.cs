using System;
using System.Collections.Generic;
using System.Data;
using Abstraccion;
using BE;
using DAL;

namespace MPP
{
    public class MPPGas : IGestor<BEGas>
    {
        Acceso oDatos;

        public MPPGas()
        {
            oDatos = new Acceso();
        }

        public List<BEGas> ListarTodo()
        {
            try
            {
                DataTable tablaGas = oDatos.Leer("SELECT Calefactor.*, Proveedor.RazonSocial FROM Calefactor JOIN Proveedor ON Calefactor.CodProveedor = Proveedor.Codigo WHERE Eficiencia IS NULL");

                List<BEGas> lista = new List<BEGas>();

                foreach (DataRow fila in tablaGas.Rows)
                {
                    BEGas oBEGas = new BEGas
                    {
                        Codigo = Convert.ToInt32(fila["Codigo"]),
                        Nombre = fila["Nombre"].ToString(),
                        Calorias = Convert.ToInt32(fila["Calorias"]),
                        Modelo = fila["Modelo"].ToString(),
                        Cantidad = Convert.ToInt32(fila["Cantidad"]),
                        Estado = fila["Estado"].ToString(),
                        Precio = Convert.ToInt32(fila["Precio"]),
                        TiroBalanceado = Convert.ToBoolean(fila["TiroBalanceado"]),
                        oBEProveedor = new BEProveedor
                        {
                            Codigo = Convert.ToInt32(fila["CodProveedor"]),
                            RazonSocial = fila["RazonSocial"].ToString()
                        }
                    };

                    lista.Add(oBEGas);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los calefactores de gas", ex);
            }
        }

        public bool Guardar(BEGas oBEGas)
        {
            string consultaSql = string.Empty;
            try
            {
                if (oBEGas.Codigo != 0)
                {
                    consultaSql = $"UPDATE Calefactor SET Nombre = '{oBEGas.Nombre}', Calorias = {oBEGas.Calorias}, Modelo = '{oBEGas.Modelo}', Cantidad = {oBEGas.Cantidad}, Estado = '{oBEGas.Estado}', Precio = {oBEGas.Precio}, TiroBalanceado = '{oBEGas.TiroBalanceado}', CodProveedor = {oBEGas.oBEProveedor.Codigo} WHERE Codigo = {oBEGas.Codigo}";
                }
                else
                {
                    consultaSql = $"INSERT INTO Calefactor (Nombre, Calorias, Modelo, Cantidad, Estado, Precio, TiroBalanceado, CodProveedor) VALUES ('{oBEGas.Nombre}', {oBEGas.Calorias}, '{oBEGas.Modelo}', {oBEGas.Cantidad}, '{oBEGas.Estado}', {oBEGas.Precio}, '{oBEGas.TiroBalanceado}', {oBEGas.oBEProveedor.Codigo})";
                }

                oDatos = new Acceso();
                return oDatos.Escribir(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el calefactor de gas", ex);
            }
        }

        public bool Baja(BEGas oBEGas)
        {
            try
            {
                string consultaSql = $"DELETE FROM Calefactor WHERE Codigo = {oBEGas.Codigo}";
                oDatos = new Acceso();
                return oDatos.Escribir(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el calefactor de gas", ex);
            }
        }

        public BEGas ListarObjeto(BEGas oBEGas)
        {
            try
            {
                DataTable tabla = oDatos.Leer($"SELECT Calefactor.*, Proveedor.RazonSocial FROM Calefactor JOIN Proveedor ON Calefactor.CodProveedor = Proveedor.Codigo WHERE Calefactor.Codigo = {oBEGas.Codigo}");
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    oBEGas = new BEGas
                    {
                        Codigo = Convert.ToInt32(fila["Codigo"]),
                        Nombre = fila["Nombre"].ToString(),
                        Calorias = Convert.ToInt32(fila["Calorias"]),
                        Modelo = fila["Modelo"].ToString(),
                        Cantidad = Convert.ToInt32(fila["Cantidad"]),
                        Estado = fila["Estado"].ToString(),
                        Precio = Convert.ToInt32(fila["Precio"]),
                        TiroBalanceado = Convert.ToBoolean(fila["TiroBalanceado"]),
                        oBEProveedor = new BEProveedor
                        {
                            Codigo = Convert.ToInt32(fila["CodProveedor"]),
                            RazonSocial = fila["RazonSocial"].ToString()
                        }
                    };

                    return oBEGas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el calefactor de gas", ex);
            }
        }

        public List<BEGas> ObtenerCalefactoresGasMasSolicitados()
        {
            List<BEGas> listaCalefactoresGasMasSolicitados = new List<BEGas>();
            DataTable tabla = oDatos.Leer("SELECT C.Codigo, C.Nombre, 'Gas' AS Tipo, COUNT(CC.CodCal) AS Solicitudes " +
                                          "FROM Cliente_Calefactor CC " +
                                          "JOIN Calefactor C ON CC.CodCal = C.Codigo " +
                                          "WHERE C.Eficiencia IS NULL " +
                                          "GROUP BY C.Codigo, C.Nombre " +
                                          "ORDER BY Solicitudes DESC");

            foreach (DataRow fila in tabla.Rows)
            {
                BEGas calefactor = new BEGas
                {
                    Codigo = Convert.ToInt32(fila["Codigo"]),
                    Nombre = fila["Nombre"].ToString(),
                    
                };
                listaCalefactoresGasMasSolicitados.Add(calefactor);
            }
            return listaCalefactoresGasMasSolicitados;
        }
    }
}

