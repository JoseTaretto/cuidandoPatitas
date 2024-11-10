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
                    cmd.Parameters.AddWithValue("@animal_id", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dr = cmd.ExecuteReader();

                    {
                        if (dr.Read())
                        {
                            objAnimal.AnimalId = Convert.ToInt32(dr["ANIMAL_ID"]);
                            objAnimal.EspecieId = Convert.ToInt32(dr["ESPECIE_ID"]);
                            objAnimal.AnimalNombre = dr["ANIMAL_NOMBRE"].ToString();
                            objAnimal.RazaId = Convert.ToInt32(dr["RAZA_ID"]);
                            objAnimal.AnimalEdad = Convert.ToInt32(dr["ANIMAL_EDAD"]);
                            objAnimal.AnimalSexo = Convert.ToChar(dr["ANIMAL_SEXO"]);
                            objAnimal.AnimalFechaNacimiento = Convert.ToDateTime(dr["ANIMAL_FECHA_NACIMIENTO"]);
                            objAnimal.AnimalPeso = Convert.ToInt32(dr["ANIMAL_PESO"]);
                            objAnimal.AnimalCastrado = Convert.ToInt32(dr["ANIMAL_CASTRADO"]);
                            objAnimal.DocumentoID = Convert.ToInt32(dr["DOCUMENTO_ID"]);
                            objAnimal.AnimalDocumento = dr["ANIMAL_DOCUMENTO"].ToString();
                            objAnimal.AnimalDescripcion = dr["ANIMAL_DESCRIPCION"].ToString();
                            objAnimal.Adoptado = Convert.ToInt32(dr["ADOPTADO"]);
                            objAnimal.AnimalEstado = Convert.ToInt32(dr["ANIMAL_ESTADO"]);
                            objAnimal.imagen = dr["imagen"].ToString();
                           
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
