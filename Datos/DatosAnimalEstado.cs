using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;
using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Datos
{
    public class DatosAnimalEstado : IListar<ModelAnimalEstado>
    {
        public List<ModelAnimalEstado> Listar()
        {
            var listaAnimalEstado = new List<ModelAnimalEstado>();
            var con = new Conexion();
            var conexion = new SqlConnection(con.GetCadenaSQL());
            {
                conexion.Open();
                SqlCommand cmd = new("TRAER_LISTA_ANIMAL_ESTADO", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var dr = cmd.ExecuteReader();
                {
                    while (dr.Read())
                    {
                        listaAnimalEstado.Add(new ModelAnimalEstado()
                        {
                            AnimalEstadoId = Convert.ToInt32(dr["ANIMAL_ESTADO_ID"]),
                            AnimalEstadoNombre = dr["ANIMAL_ESTADO_NOMBRE"].ToString()
                        });

                    }
                }
                return listaAnimalEstado;
            }
        }
    }
}
