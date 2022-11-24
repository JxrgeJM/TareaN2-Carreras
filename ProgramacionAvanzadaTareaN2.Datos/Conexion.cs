using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProgramacionAvanzadaTareaN2.Datos
{
    public class Conexion
    {
        private static SqlConnection _cnxCarrerasBD = null;
        public static SqlConnection GetCnxCarreras()
        {
            if (_cnxCarrerasBD == null)
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                _cnxCarrerasBD = new SqlConnection(root["ConnectionStrings:TareaN2CarrerasDB"].ToString());
            }
            return _cnxCarrerasBD;
        }
    }
}
