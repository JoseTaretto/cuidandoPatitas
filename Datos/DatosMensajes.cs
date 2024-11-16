using AppCuidandoPatitas.Models;
using AppCuidandoPatitas.Interface;
using System.Data.SqlClient;
using System.Data;

namespace AppCuidandoPatitas.Datos
{
    public class DatosMensajes : IListar<ModelMensajes>, ITraerUno<ModelMensajes>
    {
        public List<ModelMensajes> Listar()
        {
            var listaMensajes = new List<ModelMensajes>();
            var con = new Conexion();
            var conexion = new SqlConnection(con.GetCadenaSQL());
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("TRAER_LISTA_MENSAJES", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                var dr = cmd.ExecuteReader();
                {
                    while (dr.Read())
                    {
                        listaMensajes.Add(new ModelMensajes()
                        {
                            MensajeId = Convert.ToInt32(dr["MENSAJE_ID"]),
                            MensajeNombre = dr["MENSAJE_NOMBRE"].ToString(),
                            MensajeTelefono = dr["MENSAJE_TELEFONO"].ToString(),
                            MensajeMail = dr["MENSAJE_MAIL"].ToString(),
                            MensajeMensaje = dr["MENSAJE_MENSAJE"].ToString(),
                            MensajeFecha = Convert.ToDateTime(dr["MENSAJE_FECHA"]),
                            MensajeVisto = Convert.ToInt32(dr["MENSAJE_VISTO"]),

                        });
                    }
                }
            }
            return listaMensajes;
        }

        public ModelMensajes TraerUno(int id)
        {
            try
            {
                var objMensaje = new ModelMensajes();
                var con = new Conexion();
                var conexion = new SqlConnection(con.GetCadenaSQL());
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("TRAER_MENSAJE", conexion);
                    cmd.Parameters.AddWithValue("@mensaje_id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    {
                        if (dr.Read())
                        {
                            objMensaje.MensajeId = Convert.ToInt32(dr["MENSAJE_ID"]);
                            objMensaje.MensajeNombre = dr["MENSAJE_NOMBRE"].ToString();
                            objMensaje.MensajeTelefono = dr["MENSAJE_TELEFONO"].ToString();
                            objMensaje.MensajeMail = dr["MENSAJE_MAIL"].ToString();
                            objMensaje.MensajeMensaje = dr["MENSAJE_MENSAJE"].ToString();
                            objMensaje.MensajeFecha = Convert.ToDateTime(dr["MENSAJE_FECHA"]);
                            objMensaje.MensajeVisto = Convert.ToInt32(dr["MENSAJE_VISTO"]);
                        }
                    }
                    return objMensaje;
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return null;
            }
        }


    }
}





