using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ServicioSocial.Clases;


namespace ServicioSocial.Controllers
{
    //  [EnableCors("ReglasCors")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
   
    
    public class RespuestasController : ControllerBase
    {

        public static string cadena_conexion = Global.cadena_conexion;

        [HttpPost]
        [Route("Agregar_Pregunta")]

        public IActionResult Agregar_Pregunta([FromBody] Pregunta request)
        {

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into pregunta (id_carrera, eje, categoria, indicador, nombre, valuacion) VALUES (@id_carrera, @eje, @categoria, @indicador, @nombre, @valuacion)", conexion);

                //@id_usuario, @Tipo_deuda,@Nombre_deuda, @Monto, @Ruta_comprobante, @Estado

                comando.Parameters.Add("@id_carrera", MySqlDbType.Int32).Value = request.id_carrera;
                comando.Parameters.Add("@eje", MySqlDbType.Int32).Value = request.eje;
                comando.Parameters.Add("@categoria", MySqlDbType.Int32).Value = request.categoria;
                comando.Parameters.Add("@indicador", MySqlDbType.Int32).Value = request.indicador;
                comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = request.nombre;
                comando.Parameters.Add("@valuacion", MySqlDbType.VarChar).Value = request.valuacion;
                //  comando.Parameters.Add("@fecha", MySqlDbType.Date).Value = fecha;




                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        //  Agregar_Pregunta = true;

                        return StatusCode(statusCode: 200);
                    }

                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conexion.Close();
                }
                //  return Agregar_Pregunta;
                return StatusCode(statusCode: 401);

            }

        }

        [HttpDelete]
        [Route("Eliminar_Pregunta")]

        public IActionResult Eliminar_Pregunta([FromBody] Pregunta request)
        {

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM pregunta WHERE id_pregunta=@id_pregunta", conexion);

                //@id_usuario, @Tipo_deuda,@Nombre_deuda, @Monto, @Ruta_comprobante, @Estado

                comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;
               // comando.Parameters.Add("@id_carrera", MySqlDbType.Int32).Value = request.id_carrera;


                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        return StatusCode(statusCode: 200);
                    }

                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conexion.Close();
                }
                return StatusCode(statusCode: 401);

            }
        }

        [HttpPut]
        [Route("Actualizar_Pregunta")]

        public IActionResult Actualizar_Pregunta([FromBody] Pregunta request)
        {

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE pregunta " +
                    "SET eje=@eje, categoria=@categoria, indicador=@indicador, nombre=@nombre, valuacion = @valuacion" +
                    "WHERE id_pregunta=@id_pregunta && id_carrera=@id_carrera", conexion);

                comando.Parameters.Add("@eje", MySqlDbType.Int32).Value = request.eje;
                comando.Parameters.Add("@categoria", MySqlDbType.Int32).Value = request.categoria;
                comando.Parameters.Add("@indicador", MySqlDbType.Int32).Value = request.indicador;
                comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = request.nombre;
                comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;
                comando.Parameters.Add("@valuacion", MySqlDbType.VarChar).Value = request.valuacion;



                try
                {
                    conexion.Open();
                    rowsaffected = comando.ExecuteNonQuery();

                    if (rowsaffected >= 1)
                    {
                        return StatusCode(statusCode: 200);
                    }

                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conexion.Close();
                }
                return StatusCode(statusCode: 401);

            }

        }

        [HttpPost]
        [Route("Consultar_Pregunta")]

        public IEnumerable<Pregunta> Consultar_Preguntas([FromBody] Pregunta request)
        {

            List<Pregunta> Pregunta = new List<Pregunta>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM pregunta WHERE id_carrera=@id_carrera", conexion);

                comando.Parameters.Add("@id_carrera", MySqlDbType.Int32).Value = request.id_carrera;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Pregunta.Add(new Pregunta() { id_pregunta = reader.GetInt32(0), eje = reader.GetInt32(1), categoria = reader.GetInt32(2), 
                                                      indicador = reader.GetInt32(3), nombre = reader.GetString(4), valuacion = reader.GetString(5) });
                    }


                }
                catch (MySqlException ex)
                {

                }
                finally
                {
                    conexion.Close();
                }

                return Pregunta;
            }
        }

    }
}
