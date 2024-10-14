using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

public class MPPCliente : IGestor<BECliente>
{
    Acceso oDatos = new Acceso();

    public bool Guardar(BECliente oBECli)
    {
        string Consulta_SQL;

        if (oBECli.Codigo != 0)
        {
            Consulta_SQL = $"UPDATE Cliente SET Nombre = '{oBECli.Nombre}', Apellido = '{oBECli.Apellido}', Dni = {oBECli.Dni} WHERE Codigo = {oBECli.Codigo}";
        }
        else
        {
            Consulta_SQL = $"INSERT INTO Cliente (Nombre, Apellido, Dni) VALUES ('{oBECli.Nombre}', '{oBECli.Apellido}', {oBECli.Dni})";
        }

        return oDatos.Escribir(Consulta_SQL);
    }

    public bool Baja(BECliente oBECli)
    {
        string Consulta_SQL = $"DELETE FROM Cliente WHERE Codigo = {oBECli.Codigo}";
        return oDatos.Escribir(Consulta_SQL);
    }

    public List<BECliente> ListarTodo()
    {
        DataTable Tabla = oDatos.Leer("SELECT * FROM Cliente");
        List<BECliente> ListaCliente = new List<BECliente>();

        if (Tabla.Rows.Count > 0)
        {
            foreach (DataRow fila in Tabla.Rows)
            {
                BECliente oBECli = new BECliente
                {
                    Codigo = Convert.ToInt32(fila["Codigo"]),
                    Nombre = fila["Nombre"].ToString(),
                    Apellido = fila["Apellido"].ToString(),
                    Dni = Convert.ToInt32(fila["Dni"]),
                    ListaCalefactores = ListarCalefactoresPorCliente(Convert.ToInt32(fila["Codigo"])),
                    TotalDescuento = CalcularTotalDescuento(Convert.ToInt32(fila["Codigo"]))
                };
                ListaCliente.Add(oBECli);
            }
        }

        return ListaCliente;
    }

    private float CalcularTotalDescuento(int clienteCodigo)
    {
        DataTable Tabla = oDatos.Leer($"SELECT SUM(CASE WHEN C.Eficiencia IS NOT NULL THEN C.Precio * 0.15 ELSE C.Precio * 0.25 END) AS TotalDescuento " +
                                      $"FROM Cliente_Calefactor CC " +
                                      $"JOIN Calefactor C ON CC.CodCal = C.Codigo " +
                                      $"WHERE CC.CodCli = {clienteCodigo} AND CC.Estado = 'Pagado'");

        if (Tabla.Rows.Count > 0 && Tabla.Rows[0]["TotalDescuento"] != DBNull.Value)
        {
            return Convert.ToSingle(Tabla.Rows[0]["TotalDescuento"]);
        }

        return 0;
    }

    public BECliente ListarObjeto(BECliente oBECli)
    {
        DataTable Tabla = oDatos.Leer($"SELECT * FROM Cliente WHERE Codigo = {oBECli.Codigo}");
        if (Tabla.Rows.Count > 0)
        {
            DataRow fila = Tabla.Rows[0];
            oBECli.Nombre = fila["Nombre"].ToString();
            oBECli.Apellido = fila["Apellido"].ToString();
            oBECli.Dni = Convert.ToInt32(fila["Dni"]);
            oBECli.ListaCalefactores = ListarCalefactoresPorCliente(oBECli.Codigo);
            oBECli.TotalDescuento = CalcularTotalDescuento(oBECli.Codigo);
        }
        return oBECli;
    }

    public List<BECalefactor> ListarCalefactoresPorCliente(int clienteCodigo)
    {
        DataTable Tabla = oDatos.Leer($"SELECT C.Codigo, C.Nombre, C.Calorias, C.Modelo, C.Cantidad, CC.Estado, C.Precio, C.Eficiencia, C.TiroBalanceado " +
                                      $"FROM Cliente_Calefactor CC " +
                                      $"JOIN Calefactor C ON CC.CodCal = C.Codigo " +
                                      $"WHERE CC.CodCli = {clienteCodigo}");
        List<BECalefactor> ListaCalefactores = new List<BECalefactor>();

        if (Tabla.Rows.Count > 0)
        {
            foreach (DataRow fila in Tabla.Rows)
            {
                BECalefactor oBECalefactor;
                if (fila["Eficiencia"] != DBNull.Value)
                {
                    oBECalefactor = new BEElectrica
                    {
                        Eficiencia = fila["Eficiencia"].ToString()
                    };
                }
                else
                {
                    oBECalefactor = new BEGas
                    {
                        TiroBalanceado = fila["TiroBalanceado"] != DBNull.Value && Convert.ToBoolean(fila["TiroBalanceado"])
                    };
                }

                oBECalefactor.Codigo = Convert.ToInt32(fila["Codigo"]);
                oBECalefactor.Nombre = fila["Nombre"].ToString();
                oBECalefactor.Calorias = Convert.ToInt32(fila["Calorias"]);
                oBECalefactor.Modelo = fila["Modelo"].ToString();
                oBECalefactor.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                oBECalefactor.Estado = fila["Estado"].ToString();
                oBECalefactor.Precio = Convert.ToSingle(fila["Precio"]);
                oBECalefactor.PrecioConDescuento = oBECalefactor is BEElectrica ?
                    oBECalefactor.Precio * 0.85f :
                    oBECalefactor.Precio * 0.75f;

                ListaCalefactores.Add(oBECalefactor);
            }
        }

        return ListaCalefactores;
    }

    public bool AgregarCalefactor(BECliente oBECliente, BECalefactor oBECalefactor)
    {
        
        ActualizarStockCalefactor(oBECalefactor.Codigo, -1);

        
        string Consulta_SQL = $"INSERT INTO Cliente_Calefactor (CodCli, CodCal, Estado) VALUES ({oBECliente.Codigo}, {oBECalefactor.Codigo}, 'Asociado')";
        return oDatos.Escribir(Consulta_SQL);
    }

    public bool DesasociarCalefactor(int clienteCodigo, int calefactorCodigo)
    {
        
        ActualizarStockCalefactor(calefactorCodigo, 1);

        
        string Consulta_SQL = $"DELETE FROM Cliente_Calefactor WHERE CodCli = {clienteCodigo} AND CodCal = {calefactorCodigo}";
        return oDatos.Escribir(Consulta_SQL);
    }

    public bool ActualizarEstadoCalefactor(int clienteCodigo, int calefactorCodigo, string nuevoEstado)
    {
        string Consulta_SQL = $"UPDATE Cliente_Calefactor SET Estado = '{nuevoEstado}' WHERE CodCli = {clienteCodigo} AND CodCal = {calefactorCodigo}";
        return oDatos.Escribir(Consulta_SQL);
    }

    private void ActualizarStockCalefactor(int calefactorCodigo, int cantidad)
    {
        string Consulta_SQL = $"UPDATE Calefactor SET Cantidad = Cantidad + ({cantidad}) WHERE Codigo = {calefactorCodigo}";
        oDatos.Escribir(Consulta_SQL);
    }
}
