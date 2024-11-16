using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;

namespace AppCuidandoPatitas.Datos
{
    public class DatosDocumento
    {
        public List<ModelDocumentos> ListarDocumento(int tipoDocumento)
        {
            var listaDocumentos = new List<ModelDocumentos>();
            var con = new Conexion();
            var conexion = new SqlConnection(con.GetCadenaSQL());
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("TraerListaDocumentos", conexion);
                cmd.Parameters.AddWithValue("DOCUMENTO_TIPO", tipoDocumento);
                cmd.CommandType = CommandType.StoredProcedure;

                var dr = cmd.ExecuteReader();
                {
                    while (dr.Read())
                    {
                        listaDocumentos.Add(new ModelDocumentos()
                        {
                            DocumentoID = Convert.ToInt32(dr["DOCUMENTO_ID"]),
                            DocumentoNombre = dr["DOCUMENTO_NOMBRE"].ToString()   
                        });

                    }
                }
                return listaDocumentos;
            }
        }

    }
}
