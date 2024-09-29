using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;


namespace AppCuidandoPatitas.Datos
{
    public class DatosDocumento
    {
        public List<ModelDocumento> ListarDocumento(int tipoDocumento)
        {
            var listaDocumentos = new List<ModelDocumento>();
            var con = new Conexion();
            var conexion = new SqlConnection(con.getCadenaSQL());
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("TraerListaDocumentos", conexion);
<<<<<<< HEAD
=======
                cmd.Parameters.AddWithValue("DOCUMENTO_TIPO", tipoDocumento);
>>>>>>> baf329ca6056ce3f0de58f336b37fcd617d22962
                cmd.CommandType = CommandType.StoredProcedure;

                var dr = cmd.ExecuteReader();
                {
                    while (dr.Read())
                    {
                        listaDocumentos.Add(new ModelDocumento()
                        {
<<<<<<< HEAD
                            DocumentoID = Convert.ToInt32(dr["USER_ID"]),
                            DocumentoNombre = dr["USER_NAME"].ToString(),
                          
=======
                            DocumentoID = Convert.ToInt32(dr["DOCUMENTO_ID"]),
                            DocumentoNombre = dr["DOCUMENTO_NOMBRE"].ToString(),                         
>>>>>>> baf329ca6056ce3f0de58f336b37fcd617d22962

                        });

                    }
                }
                return listaDocumentos;
            }
        }



    }
}
