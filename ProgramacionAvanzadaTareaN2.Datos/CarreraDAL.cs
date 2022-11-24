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
    public class CarreraDAL
    {
        public static List<Carrera> Listar(int pNumCarrera)
        {
            SqlCommand vCmd = new("SP_ListarCorredorTiempo", Conexion.GetCnxCarreras());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pCarrera", pNumCarrera);
            try
            {
                Conexion.GetCnxCarreras().Open();
                SqlDataReader vRd = vCmd.ExecuteReader();
                List<Carrera> vDatos = new();
                while (vRd.Read())
                {
                    vDatos.Add(new Carrera(vRd.GetInt32(0),
                        vRd.GetInt32(1), 
                        new Corredor(vRd.GetInt32(2), vRd.GetString(3)),
                        vRd.GetInt32(4),
                        vRd.GetInt32(5)));
                }
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

        public static void Agregar(Carrera pCarrera)
        {
            SqlCommand vCmd = new ("SP_AgregarTiempo", Conexion.GetCnxCarreras());
            vCmd.CommandType = CommandType.StoredProcedure;
            vCmd.Parameters.Clear();
            vCmd.Parameters.AddWithValue("@pIdCarrera", pCarrera.NumCarrera);
            vCmd.Parameters.AddWithValue("@pIdCorredor", pCarrera.Corredor.Id);
            vCmd.Parameters.AddWithValue("@pMinutos", pCarrera.Minutos);
            vCmd.Parameters.AddWithValue("@pSegundos", pCarrera.Segundos);
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
