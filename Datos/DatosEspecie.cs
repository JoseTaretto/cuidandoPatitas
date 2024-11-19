using AppCuidandoPatitas.Interface;
using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;

namespace AppCuidandoPatitas.Datos
{
    public class DatosEspecie : IListar<ModelEspecies>
    {
        public List<ModelEspecies> Listar()
        {
            var listaEspecies = new List<ModelEspecies>();
            var con = new Conexion();
            var conexion = new SqlConnection(con.GetCadenaSQL());
            {
                conexion.Open();
                SqlCommand cmd = new("TRAER_LISTA_ESPECIE", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var dr = cmd.ExecuteReader();
                {
                    while (dr.Read())
                    {
                        listaEspecies.Add(new ModelEspecies()
                        {
                            EspecieId = Convert.ToInt32(dr["ESPECIE_ID"]),
                            EspecieNombre = dr["ESPECIE_NOMBRE"].ToString()
                        });

                    }
                }
                return listaEspecies;
            }
        }
    }
}
