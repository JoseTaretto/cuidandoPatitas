using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;
using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Datos
{
    public class DatosAdopciones : IListar<ModelAdopciones>
    {
        public List<ModelAdopciones> Listar()
        {
            {
                var listaAdopciones = new List<ModelAdopciones>();
                var con = new Conexion();
                var conexion = new SqlConnection(con.GetCadenaSQL());
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("TraerListaAdoptados", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    {
                        while (dr.Read())
                        {
                            listaAdopciones.Add(new ModelAdopciones()
                            {
                                AdopcionesId = Convert.ToInt32(dr["ADOPCIONES_ID"]),
                                AnimalNombre = dr["ANIMAL_NOMBRE"].ToString(),
                                UsuarioUserName = dr["USUARIO_NOMBRE"].ToString(),
                                AdopcionEstadoId = Convert.ToInt32(dr["ESTADO_ADOPCION_ID"])

                            });
                        }
                    }
                }
                return listaAdopciones;
            }
        }

        public int AceptarAdopcion(int adopcionId)
        {
            int respuesta;

            try
            {

                var con = new Conexion();
                var conexion = new SqlConnection(con.GetCadenaSQL());
                conexion.Open();
                SqlCommand cmd = new SqlCommand("AceptarAdopcion", conexion);
                cmd.Parameters.AddWithValue("@adopcionId", adopcionId);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = 1;
                return respuesta;
            }

            catch (Exception x)
            {

                Console.Error.WriteLine(x);
                respuesta = 0;
                return respuesta;
            }
        }

        public int EliminarAdopcion(int adopcionId)
        {
            int respuesta;

            try
            {

                var con = new Conexion();
                var conexion = new SqlConnection(con.GetCadenaSQL());
                conexion.Open();
                SqlCommand cmd = new SqlCommand("EDeclinarAdopcion", conexion);
                cmd.Parameters.AddWithValue("@adopcionId", adopcionId);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                respuesta = 1;
                return respuesta;
            }

            catch (Exception x)
            {

                Console.Error.WriteLine(x);
                respuesta = 0;
                return respuesta;
            }
        }

    }
}
