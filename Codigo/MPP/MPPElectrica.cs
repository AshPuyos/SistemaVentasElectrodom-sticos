using System;
using System.Collections.Generic;
using System.Data;
using Abstraccion;
using BE;
using DAL;

namespace MPP
{
    public class MPPElectrica : IGestor<BEElectrica>
    {
        Acceso oDatos;

        public MPPElectrica()
        {
            oDatos = new Acceso();
        }

        public List<BEElectrica> ListarTodo()
        {
            try
            {
                DataTable tablaElectrica = oDatos.Leer("SELECT Calefactor.*, Proveedor.RazonSocial FROM Calefactor JOIN Proveedor ON Calefactor.CodProveedor = Proveedor.Codigo WHERE Eficiencia IS NOT NULL");


                List<BEElectrica> lista = new List<BEElectrica>();

                foreach (DataRow fila in tablaElectrica.Rows)
                {
                    BEElectrica oBEElectrica = new BEElectrica
                    {
                        Codigo = Convert.ToInt32(fila["Codigo"]),
                        Nombre = fila["Nombre"].ToString(),
                        Calorias = Convert.ToInt32(fila["Calorias"]),
                        Modelo = fila["Modelo"].ToString(),
                        Cantidad = Convert.ToInt32(fila["Cantidad"]),
                        Estado = fila["Estado"].ToString(),
                        Precio = Convert.ToInt32(fila["Precio"]),
                        Eficiencia = fila["Eficiencia"].ToString(),
                        oBEProveedor = new BEProveedor
                        {
                            Codigo = Convert.ToInt32(fila["CodProveedor"]),
                            RazonSocial = fila["RazonSocial"].ToString()
                        }
                    };

                    lista.Add(oBEElectrica);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los calefactores eléctricos", ex);
            }
        }

        public bool Guardar(BEElectrica oBEElectrica)
        {
            string consultaSql = string.Empty;
            try
            {
                if (oBEElectrica.Codigo != 0)
                {
                    consultaSql = $"UPDATE Calefactor SET Nombre = '{oBEElectrica.Nombre}', Calorias = {oBEElectrica.Calorias}, Modelo = '{oBEElectrica.Modelo}', Cantidad = {oBEElectrica.Cantidad}, Estado = '{oBEElectrica.Estado}', Precio = {oBEElectrica.Precio}, Eficiencia = '{oBEElectrica.Eficiencia}', CodProveedor = {oBEElectrica.oBEProveedor.Codigo} WHERE Codigo = {oBEElectrica.Codigo}";
                }
                else
                {
                    consultaSql = $"INSERT INTO Calefactor (Nombre, Calorias, Modelo, Cantidad, Estado, Precio, Eficiencia, CodProveedor) VALUES ('{oBEElectrica.Nombre}', {oBEElectrica.Calorias}, '{oBEElectrica.Modelo}', {oBEElectrica.Cantidad}, '{oBEElectrica.Estado}', {oBEElectrica.Precio}, '{oBEElectrica.Eficiencia}', {oBEElectrica.oBEProveedor.Codigo})";
                }

                oDatos = new Acceso();
                return oDatos.Escribir(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el calefactor eléctrico", ex);
            }
        }

        public bool Baja(BEElectrica oBEElectrica)
        {
            try
            {
                string consultaSql = $"DELETE FROM Calefactor WHERE Codigo = {oBEElectrica.Codigo}";
                oDatos = new Acceso();
                return oDatos.Escribir(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el calefactor eléctrico", ex);
            }
        }

        public BEElectrica ListarObjeto(BEElectrica oBEElectrica)
        {
            try
            {
                DataTable tabla = oDatos.Leer($"SELECT Calefactor.*, Proveedor.RazonSocial FROM Calefactor JOIN Proveedor ON Calefactor.CodProveedor = Proveedor.Codigo WHERE Calefactor.Codigo = {oBEElectrica.Codigo}");
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    oBEElectrica = new BEElectrica
                    {
                        Codigo = Convert.ToInt32(fila["Codigo"]),
                        Nombre = fila["Nombre"].ToString(),
                        Calorias = Convert.ToInt32(fila["Calorias"]),
                        Modelo = fila["Modelo"].ToString(),
                        Cantidad = Convert.ToInt32(fila["Cantidad"]),
                        Estado = fila["Estado"].ToString(),
                        Precio = Convert.ToInt32(fila["Precio"]),
                        Eficiencia = fila["Eficiencia"].ToString(),
                        oBEProveedor = new BEProveedor
                        {
                            Codigo = Convert.ToInt32(fila["CodProveedor"]),
                            RazonSocial = fila["RazonSocial"].ToString()
                        }
                    };

                    return oBEElectrica;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el calefactor eléctrico", ex);
            }
        }

        public List<BEElectrica> ObtenerCalefactoresElectricosMenosSolicitados()
        {
            List<BEElectrica> listaCalefactoresElectricosMenosSolicitados = new List<BEElectrica>();
            DataTable tabla = oDatos.Leer("SELECT C.Codigo, C.Nombre, 'Eléctrico' AS Tipo, COUNT(CC.CodCal) AS Solicitudes " +
                                          "FROM Cliente_Calefactor CC " +
                                          "JOIN Calefactor C ON CC.CodCal = C.Codigo " +
                                          "WHERE C.Eficiencia IS NOT NULL " +
                                          "GROUP BY C.Codigo, C.Nombre " +
                                          "ORDER BY Solicitudes ASC");

            foreach (DataRow fila in tabla.Rows)
            {
                BEElectrica calefactor = new BEElectrica
                {
                    Codigo = Convert.ToInt32(fila["Codigo"]),
                    Nombre = fila["Nombre"].ToString(),
                };
                listaCalefactoresElectricosMenosSolicitados.Add(calefactor);
            }
            return listaCalefactoresElectricosMenosSolicitados;
        }
    }
}
