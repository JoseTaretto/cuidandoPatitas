using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;


namespace AppCuidandoPatitas.Datos
{
    public class DatosAnimales
    {
        public List<ModelAnimales> Listar()
        {
            {
                var listaAnimales = new List<ModelAnimales>();
                var con = new Conexion();
                var conexion = new SqlConnection(con.getCadenaSQL());
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("TraerListaAnimales", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();
                    {
                        while (dr.Read())
                        {
                            listaAnimales.Add(new ModelAnimales()
                            {
                                AnimalId = Convert.ToInt32(dr["ANIMAL_ID"]),
                                
                                AnimalNombre = dr["ANIMAL_NOMBRE"].ToString(),
                                RazaId = Convert.ToInt32(dr["RAZA_ID"]),
                                AnimalEdad = Convert.ToInt32(dr["ANIMAL_EDAD"]),
                                AnimalSexo = Convert.ToChar(dr["ANIMAL_SEXO"]),
                                                            
                                AnimalDescripcion = dr["ANIMAL_DESCRIPCION"].ToString(),  
                            });
                        }
                    }

                }
                return listaAnimales;
            }
        }
    }
}
