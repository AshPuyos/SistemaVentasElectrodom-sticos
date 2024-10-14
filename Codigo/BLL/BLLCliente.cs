using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;

public class BLLCliente : IGestor<BECliente>
{
    MPPCliente oMPPCli = new MPPCliente();

    public List<BECliente> ListarTodo()
    {
        return oMPPCli.ListarTodo();
    }

    public bool Guardar(BECliente oBECli)
    {
        return oMPPCli.Guardar(oBECli);
    }

    public bool Baja(BECliente oBECli)
    {
        return oMPPCli.Baja(oBECli);
    }

    public BECliente ListarObjeto(BECliente Objeto)
    {
        throw new NotImplementedException();
    }

    public bool AgregarCalefactor(BECliente oBECliente, BECalefactor oBECalefactor)
    {
        return oMPPCli.AgregarCalefactor(oBECliente, oBECalefactor);
    }

    public bool DesasociarCalefactor(int clienteCodigo, int calefactorCodigo)
    {
        return oMPPCli.DesasociarCalefactor(clienteCodigo, calefactorCodigo);
    }

    public bool ActualizarEstadoCalefactor(int clienteCodigo, int calefactorCodigo, string nuevoEstado)
    {
        return oMPPCli.ActualizarEstadoCalefactor(clienteCodigo, calefactorCodigo, nuevoEstado);
    }

    public List<BECliente> ObtenerClientesConDescuentos()
    {
        List<BECliente> clientes = oMPPCli.ListarTodo();
        List<BECliente> clientesConDescuentos = new List<BECliente>();

        foreach (var cliente in clientes)
        {
            cliente.TotalDescuento = cliente.ListaCalefactores
                .Where(c => c.Estado == "Pagado")
                .Sum(c => c.Precio - c.PrecioConDescuento);

            if (cliente.TotalDescuento > 0)
            {
                clientesConDescuentos.Add(cliente);
            }
        }

        return clientesConDescuentos.OrderByDescending(c => c.TotalDescuento).ToList();
    }
}
