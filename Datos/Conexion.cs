﻿using System.Data.SqlClient;

namespace AppCuidandoPatitas.Datos
{
    public class Conexion
    {

        private string CadenaSQL = string.Empty;

        public Conexion()       
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL() { return CadenaSQL; }

    }
}
