using AppCuidandoPatitas.Models;
using System.Data.SqlClient;
using System.Data;
using AppCuidandoPatitas.Interface;

namespace AppCuidandoPatitas.Datos
{
    public class DatosAnimales : IGuardar<ModelAnimales>, IListar<ModelAnimales>, IEditar<ModelAnimales>
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
                                Adoptado = Convert.ToInt32(dr["adoptado"]),
                                AnimalDescripcion = dr["ANIMAL_DESCRIPCION"].ToString(), 
                                AnimalEstado = Convert.ToInt32(dr["ANIMAL_ESTADO"]),
                                imagen = dr["imagen"].ToString()
                            });
                        }
                    }
                }
                return listaAnimales;
            }
        }

        public bool Guardar(ModelAnimales objMascota)
        {
            bool respuesta;

            try
            {
                var con = new Conexion();
                var conexion = new SqlConnection(con.getCadenaSQL());

                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarAnimal", conexion);

                    cmd.Parameters.AddWithValue("ESPECIE_ID", objMascota.EspecieId);
                    cmd.Parameters.AddWithValue("RAZA_ID", objMascota.RazaId);
                    cmd.Parameters.AddWithValue("ANIMAL_NOMBRE", objMascota.AnimalNombre);
                    cmd.Parameters.AddWithValue("ANIMAL_SEXO", objMascota.AnimalSexo);
                    cmd.Parameters.AddWithValue("ANIMAL_EDAD", objMascota.AnimalEdad);
                    cmd.Parameters.AddWithValue("ANIMAL_FECHA_NACIMIENTO", objMascota.AnimalFechaNacimiento);
                    cmd.Parameters.AddWithValue("ANIMAL_PESO", objMascota.AnimalPeso);
                    cmd.Parameters.AddWithValue("ANIMAL_CASTRADO", objMascota.AnimalCastrado);
                    cmd.Parameters.AddWithValue("ANIMAL_ESTADO", objMascota.AnimalEstado);
                    cmd.Parameters.AddWithValue("ANIMAL_DESCRIPCION", objMascota.AnimalDescripcion);
                    cmd.Parameters.AddWithValue("DOCUMENTO_ID", objMascota.DocumentoID);
                    cmd.Parameters.AddWithValue("ANIMAL_DOCUMENTO", objMascota.AnimalDocumento);
                    cmd.Parameters.AddWithValue("USER_ALTA", objMascota.UserAlta);
                    cmd.Parameters.AddWithValue("IMAGEN", objMascota.imagen);
                    cmd.Parameters.AddWithValue("USER_OWNER",objMascota.UserOwner);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
                return respuesta;                
            }

            catch (Exception x)
            {
                respuesta = false;
                Console.WriteLine(x);
            }

            return respuesta;
        }

        public int adoptarAnimal(int animalId, int userId){

            int respuesta;

            try{

                var con = new Conexion();
                var conexion = new SqlConnection(con.getCadenaSQL());                
                conexion.Open();                
                SqlCommand cmd = new SqlCommand("ActualizarAdoptado", conexion);                    
                cmd.Parameters.AddWithValue("@AnimalID", animalId);
                cmd.Parameters.AddWithValue("@USER_ID", userId);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                
                respuesta = 1;
                return respuesta;
            }

            catch (Exception x) { 

                Console.Error.WriteLine(x);
                respuesta = 0;
                return respuesta;
            }
        }

        public int eliminarAnimal(int animalId){

             int respuesta;

            try{

                var con = new Conexion();
                var conexion = new SqlConnection(con.getCadenaSQL());                
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ActualizarEstadoAnimal", conexion);                    
                cmd.Parameters.AddWithValue("@id", animalId);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                respuesta = 1;
                return respuesta;
            }

            catch (Exception x) { 
                Console.Error.WriteLine(x);
                respuesta = 0;
                return respuesta;
            } 

        }

        public bool Editar(ModelAnimales objAnimal){

            bool respuesta;

            try
            {
                var con = new Conexion();
                var conexcion = new SqlConnection(con.getCadenaSQL());

                {
                    conexcion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizarDatosAnimal", conexcion);

                    cmd.Parameters.AddWithValue("id", objAnimal.AnimalId);
                    cmd.Parameters.AddWithValue("especie_id", objAnimal.EspecieId);
                    cmd.Parameters.AddWithValue("raza_id", objAnimal.RazaId);
                    cmd.Parameters.AddWithValue("animal_nombre", objAnimal.AnimalNombre);
                    cmd.Parameters.AddWithValue("animal_sexo", objAnimal.AnimalSexo);
                    cmd.Parameters.AddWithValue("animal_edad", objAnimal.AnimalEdad);
                    cmd.Parameters.AddWithValue("animal_fecha_nacimiento", objAnimal.AnimalFechaNacimiento);
                    cmd.Parameters.AddWithValue("animal_peso", objAnimal.AnimalPeso);
                    cmd.Parameters.AddWithValue("animal_castrado", objAnimal.AnimalCastrado);
                    cmd.Parameters.AddWithValue("animal_descripcion", objAnimal.AnimalDescripcion);
                    cmd.Parameters.AddWithValue("animal_documento", objAnimal.AnimalDocumento);
                    cmd.Parameters.AddWithValue("documento_id", objAnimal.DocumentoID);
                    cmd.Parameters.AddWithValue("imagen", objAnimal.imagen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;

            }
            catch (Exception x)
            {
                respuesta = false;
                Console.WriteLine(x);
            }

            return respuesta;
        }

        public ModelAnimales TraerUno(int id)
        {
            try
            {
                var objAnimal = new ModelAnimales();
                var con = new Conexion();
                var conexion = new SqlConnection(con.getCadenaSQL());

                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("TraerAnimalesID", conexion);
                    cmd.Parameters.AddWithValue("@USER_ID", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();

                    {
                        if (dr.Read())
                        {
                            objAnimal.UsuarioID = Convert.ToInt32(dr["ANIMAL_ID"]);
                            objAnimal.UsuarioUserName = dr["USER_NAME"].ToString();
                            objAnimal.UsuarioRol = dr["USUARIO_ROL"].ToString();
                            objAnimal.UsuarioPassword = dr["USUARIO_PASSWORD"].ToString();
                            objAnimal.UsuarioNombre = dr["USUARIO_NOMBRE"].ToString();
                            objAnimal.UsuarioApellido = dr["USUARIO_APELLIDO"].ToString();
                            objAnimal.UsuarioFechaNacimiento = Convert.ToDateTime(dr["USUARIO_FECHA_NACIMIENTO"]);
                            objAnimal.DocumentoID = Convert.ToInt32(dr["DOCUMENTO_ID"]);
                            objAnimal.UsuarioDocumento = dr["USUARIO_DOCUMENTO"].ToString();
                            objAnimal.UsuarioEmail = dr["USUARIO_EMAIL"].ToString();
                            objAnimal.UsuarioTelefono1 = dr["USUARIO_TELEFONO_1"].ToString();
                            objAnimal.UsuarioTelefono2 = dr["USUARIO_TELEFONO_2"].ToString();
                            objAnimal.UsuarioDireccion = dr["USUARIO_DIRECCION"].ToString();
                            objAnimal.LocalidadId = Convert.ToInt32(dr["LOCALIDAD"]);
                            objAnimal.ProvinciaId = Convert.ToInt32(dr["PROVINCIA_ID"]);
                            objAnimal.UsuarioActivo = Convert.ToInt32(dr["USUARIO_ACTIVO"]);
                            objAnimal.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                            objAnimal.UserAlta = Convert.ToInt32(dr["USER_ALTA"]);
                            objAnimal.FechaModificacion = Convert.ToDateTime(dr["FECHA_MODIFICACION"]);
                            objAnimal.UserModificacion = Convert.ToInt32(dr["USER_MODIFICACION"]);
                            objAnimal.FechaBaja = Convert.ToDateTime(dr["FECHA_ALTA"]);
                            objAnimal.UserBaja = Convert.ToInt32(dr["USER_ALTA"]);

                        }
                    }

                    return objAnimal;
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
