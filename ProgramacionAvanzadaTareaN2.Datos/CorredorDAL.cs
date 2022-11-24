using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProgramacionAvanzadaTareaN2.Entidades;

namespace ProgramacionAvanzadaTareaN2.Datos
{
    public class CorredorDAL
    {
        public static List<Corredor> Listar()
        {
            SqlCommand vCmd = new ("SP_ListarCorredor", Conexion.GetCnxCarreras());
            vCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.GetCnxCarreras().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<Corredor> vDatos = new();
                while (vRd.Read())
                    vDatos.Add(new Corredor(vRd.GetInt32(0), vRd.GetString(1)));
                vRd.Close();
                return vDatos;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexion.GetCnxCarreras().Close();
            }
        }

        public static void Agregar(Corredor pCorredor)
        {
            SqlCommand vCmd = new ("SP_AgregarCorredor", Conexion.GetCnxCarreras());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pNombre", pCorredor.Nombre.ToUpper());
            try
            {
                Conexion.GetCnxCarreras().Open();
                vCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexion.GetCnxCarreras().Close();
            }
        }

    }
}
