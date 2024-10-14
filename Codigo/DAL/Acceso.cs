using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DAL
{
    public class Acceso
    {
        //declaro el objeto del tipo conection y uso el constructor para pasar el ConnectionString
        private SqlConnection oCnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BDPuyos;Integrated Security=True");

        //Metodo Generico para leer
        public DataTable Leer(string consulta)
        {
            DataTable tabla = new DataTable();
            try
            {
                //creo el data adapter le paso la consulta y la conexion
                SqlDataAdapter Da = new SqlDataAdapter(consulta, oCnn);
                //lleno la tabla con el metodo fill
                Da.Fill(tabla);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            { //cierro la Conexion
                oCnn.Close();
            }
            return tabla;
        }

        //leo un escalar-
        public bool LeerScalar(string consulta)
        {
            oCnn.Open();
            //uso el constructor del objeto Command
            SqlCommand cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                return Respuesta > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataSet Leer2(string Consulta_SQL)
        {
            DataSet Ds = new DataSet();
            try
            {
                //creo el data adapter le paso la consulta y la conexion
                SqlDataAdapter Da = new SqlDataAdapter(Consulta_SQL, oCnn);
                //lleno el DataSet con el metodo fill
                Da.Fill(Ds);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            { //cierro la Conexion
                oCnn.Close();
            }
            return Ds;
        }

        //realizo un método escribir generico, dado que recibo un string q es la consulta de SQL
        public bool Escribir(string Consulta_SQL)
        {
            oCnn.Open();
            SqlTransaction TX;
            TX=oCnn.BeginTransaction();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = oCnn;
            cmd.CommandText = Consulta_SQL;

            cmd.Transaction = TX;
            try
            {
                int respuesta = cmd.ExecuteNonQuery();
                TX.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                TX.Rollback();
                throw ex;
            }
            finally
            { oCnn.Close(); }
        }
    }
}
