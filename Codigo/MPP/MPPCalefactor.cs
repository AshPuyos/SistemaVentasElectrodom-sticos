using System;
using System.Collections.Generic;
using System.Data;
using BE;
using DAL;

namespace MPP
{
    public class MPPCalefactor
    {
        private Acceso oDatos = new Acceso();

        public List<BECalefactor> ListarTodo()
        {
            List<BECalefactor> ListaCalefactores = new List<BECalefactor>();
            DataSet Ds = oDatos.Leer2("SELECT * FROM Calefactor");

            foreach (DataRow fila in Ds.Tables[0].Rows)
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
                oBECalefactor.Precio = Convert.ToInt32(fila["Precio"]);
                oBECalefactor.oBEProveedor = new BEProveedor
                {
                    Codigo = Convert.ToInt32(fila["CodProveedor"]),
                    RazonSocial = "" 
                };

                ListaCalefactores.Add(oBECalefactor);
            }

            return ListaCalefactores;
        }

        public bool Guardar(BECalefactor oBECal)
        {
            string Consulta_SQL;
            if (oBECal.Codigo != 0)
            {
                if (oBECal is BEElectrica electrica)
                {
                    Consulta_SQL = $"UPDATE Calefactor SET Nombre = '{oBECal.Nombre}', Calorias = '{oBECal.Calorias}', Modelo = '{oBECal.Modelo}', Cantidad = {oBECal.Cantidad}, Estado = '{oBECal.Estado}', Precio = {oBECal.Precio}, CodProveedor = {oBECal.oBEProveedor.Codigo}, Eficiencia = '{electrica.Eficiencia}' WHERE Codigo = {oBECal.Codigo}";
                }
                else if (oBECal is BEGas gas)
                {
                    Consulta_SQL = $"UPDATE Calefactor SET Nombre = '{oBECal.Nombre}', Calorias = '{oBECal.Calorias}', Modelo = '{oBECal.Modelo}', Cantidad = {oBECal.Cantidad}, Estado = '{oBECal.Estado}', Precio = {oBECal.Precio}, CodProveedor = {oBECal.oBEProveedor.Codigo}, TiroBalanceado = '{gas.TiroBalanceado}' WHERE Codigo = {oBECal.Codigo}";
                }
                else
                {
                    throw new Exception("Tipo de calefactor desconocido");
                }
            }
            else
            {
                if (oBECal is BEElectrica electrica)
                {
                    Consulta_SQL = $"INSERT INTO Calefactor (Nombre, Calorias, Modelo, Cantidad, Estado, Precio, CodProveedor, Eficiencia) VALUES ('{oBECal.Nombre}', '{oBECal.Calorias}', '{oBECal.Modelo}', {oBECal.Cantidad}, '{oBECal.Estado}', {oBECal.Precio}, {oBECal.oBEProveedor.Codigo}, '{electrica.Eficiencia}')";
                }
                else if (oBECal is BEGas gas)
                {
                    Consulta_SQL = $"INSERT INTO Calefactor (Nombre, Calorias, Modelo, Cantidad, Estado, Precio, CodProveedor, TiroBalanceado) VALUES ('{oBECal.Nombre}', '{oBECal.Calorias}', '{oBECal.Modelo}', {oBECal.Cantidad}, '{oBECal.Estado}', {oBECal.Precio}, {oBECal.oBEProveedor.Codigo}, '{gas.TiroBalanceado}')";
                }
                else
                {
                    throw new Exception("Tipo de calefactor desconocido");
                }
            }

            return oDatos.Escribir(Consulta_SQL);
        }

        public bool Baja(BECalefactor oBECal)
        {
            string Consulta_SQL = $"DELETE FROM Calefactor WHERE Codigo = {oBECal.Codigo}";
            return oDatos.Escribir(Consulta_SQL);
        }
    }
}
