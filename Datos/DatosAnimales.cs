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

        public bool ingresarAnimal(ModelAnimales objMascota)
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
                    cmd.Parameters.AddWithValue("@USER_ALTA", objMascota.UserAlta);
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
    }


}
