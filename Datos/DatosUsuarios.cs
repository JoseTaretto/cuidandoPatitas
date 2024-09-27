using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;


namespace AppCuidandoPatitas.Datos
{
    public class DatosUsuarios
    {
       public List<ModelUsuarios> Listar()
        {
            var listaUsuarios = new List<ModelUsuarios>();
            var con = new Conexion();
            var conexion = new SqlConnection(con.getCadenaSQL());
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("TraerListaUsuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                var dr = cmd.ExecuteReader();
                {
                    while (dr.Read())
                    {
                        listaUsuarios.Add(new ModelUsuarios()
                        {
                            UsuarioId = Convert.ToInt32(dr["USER_ID"]),
                            UsuarioUserName = dr["USER_NAME"].ToString(),
                            UsuarioRol = dr["USUARIO_ROL"].ToString(),
                            UsuarioPassword = dr["USUARIO_PASSWORD"].ToString(),
                            UsuarioNombre = dr["USUARIO_NOMBRE"].ToString(),
                            UsuarioApellido = dr["USUARIO_APELLIDO"].ToString(),
                            UsuarioFechaNacimiento = Convert.ToDateTime(dr["USUARIO_FECHA_NACIMIENTO"]),
                            DocumentoId = Convert.ToInt32(dr["DOCUMENTO_ID"]),
                            UsuarioDocumento = dr["USUARIO_DOCUMENTO"].ToString(),
                            UsuarioEmail = dr["USUARIO_EMAIL"].ToString(),
                            UsuarioTelefono1 = dr["USUARIO_TELEFONO_1"].ToString(),
                            UsuarioTelefono2 = dr["USUARIO_TELEFONO_2"].ToString(),
                            UsuarioDireccion = dr["USUARIO_DIRECCION"].ToString(),
                            LocalidadId = Convert.ToInt32(dr["LOCALIDAD"]),
                            ProvinciaId = Convert.ToInt32(dr["PROVINCIA_ID"]),
                            UsuarioActivo = Convert.ToInt32(dr["USUARIO_ACTIVO"]),
                            FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]),
                            UserAlta = Convert.ToInt32(dr["USER_ALTA"]),
                            FechaModificacion = Convert.ToDateTime(dr["FECHA_MODIFICACION"]),
                            UserModificacion= Convert.ToInt32(dr["USER_MODIFICACION"]),
                            FechaBaja = Convert.ToDateTime(dr["FECHA_ALTA"]),
                            UserBaja = Convert.ToInt32(dr["USER_ALTA"])

                        });

                    }
                }
                return listaUsuarios;
            }
        }

        public bool guardar(ModelUsuarios objUsuarios)
        {
            bool respuesta;

            try
            {
                var con = new Conexion();
                var conexcion = new SqlConnection(con.getCadenaSQL());

                {
                    conexcion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarUsuario", conexcion);
                    cmd.Parameters.AddWithValue("USER_NAME", objUsuarios.UsuarioUserName);
                    cmd.Parameters.AddWithValue("USAURIO_PASSWORD", objUsuarios.UsuarioPassword);
                    cmd.Parameters.AddWithValue("USUARIO_ROL", objUsuarios.UsuarioRol);
                    cmd.Parameters.AddWithValue("USUARIO_NOMBRE", objUsuarios.UsuarioNombre);
                    cmd.Parameters.AddWithValue("USUARIO_APELLIDO", objUsuarios.UsuarioApellido);
                    cmd.Parameters.AddWithValue("USER_FECHA_NACIMIENTO", objUsuarios.UsuarioFechaNacimiento);
                    cmd.Parameters.AddWithValue("DOCUMENTO_ID", objUsuarios.DocumentoId);
                    cmd.Parameters.AddWithValue("USUARIO_DOCUMENTO", objUsuarios.UsuarioDocumento);
                    cmd.Parameters.AddWithValue("USUARIO_EMAIL", objUsuarios.UsuarioEmail);
                    cmd.Parameters.AddWithValue("USUARIO_TELEFONO_1", objUsuarios.UsuarioTelefono1);
                    cmd.Parameters.AddWithValue("USUARIO_TELEFONO_2", objUsuarios.UsuarioTelefono2);
                    cmd.Parameters.AddWithValue("USUARIO_DIRECCION", objUsuarios.UsuarioDireccion);
                    cmd.Parameters.AddWithValue("LOCALIDAD", objUsuarios.LocalidadId);
                    cmd.Parameters.AddWithValue("PROVINCIA_ID", objUsuarios.ProvinciaId);
                    cmd.Parameters.AddWithValue("USER_ALTA", objUsuarios.UserAlta);
                }

                respuesta = true;

            }
            catch (Exception)
            {
                respuesta=false;
            }

            return respuesta;

        }
    }
}
