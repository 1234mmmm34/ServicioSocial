using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ServicioSocial.Clases;

namespace ServicioSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CumplimientoController : ControllerBase
    {
        public static string cadena_conexion = Global.cadena_conexion;

        [HttpPost]
        [Route("Agregar_Cumplimiento")]

        public IActionResult Agregar_Cumplimiento([FromBody] Cumplimiento request)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into cumplimiento (id_recomendacion, id_pregunta, acciones_realizadas, fecha, meta_alcanzada, documentos) VALUES (@id_recomendacion, @id_pregunta, @acciones_realizadas, @fecha, @meta_alcanzada, @documentos)", conexion);

                comando.Parameters.Add("@id_recomendacion", MySqlDbType.Int32).Value = request.id_recomendacion;
                comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;
                comando.Parameters.Add("@acciones_realizadas", MySqlDbType.VarChar).Value = request.acciones_realizadas;
                comando.Parameters.Add("@fecha", MySqlDbType.Date).Value = request.fecha;
                comando.Parameters.Add("@meta_alcanzada", MySqlDbType.VarChar).Value = request.meta_alcanzada;
                comando.Parameters.Add("@documentos", MySqlDbType.VarChar).Value = request.documentos;
;
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

                }
                finally
                {
                    conexion.Close();
                }
                return StatusCode(statusCode: 401);

            }
        }

        [HttpDelete]
        [Route("Eliminar_Cumplimiento")]

        public IActionResult Eliminar_Cumplimiento([FromBody] Cumplimiento request)
        {

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM cumplimiento WHERE id_cumplimiento=@id_cumplimiento", conexion);

                //comando.Parameters.Add("@id_cumplimiento", MySqlDbType.Int32).Value = request.id_cumplimiento;
                comando.Parameters.Add("@id_recomendacion", MySqlDbType.Int32).Value = request.id_recomendacion;


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
        [Route("Actualizar_Cumplimiento")]

        public IActionResult Actualizar_cumplimiento([FromBody] Cumplimiento request)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE cumplimiento " +
                    "SET acciones_realizadas=@acciones_realizadas, " +
                    "fecha=@fecha, " +
                    "meta_alcanzada=@meta_alcanzada" +
                    "documentos=@documentos" +
                    "WHERE id_cumplimiento=@id_cumplimiento", conexion);

                comando.Parameters.Add("@acciones_realizadas", MySqlDbType.VarChar).Value = request.acciones_realizadas;
                comando.Parameters.Add("@fecha", MySqlDbType.Date).Value = request.fecha;
                comando.Parameters.Add("@meta_alcanzada", MySqlDbType.VarChar).Value = request.meta_alcanzada;
                comando.Parameters.Add("@documentos", MySqlDbType.VarChar).Value = request.documentos;


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
        [Route("Consultar_Cumplimiento")]
        public IEnumerable<Cumplimiento> Consultar_Cumplimiento([FromBody] Cumplimiento request)
        {
            List<Cumplimiento> Cumplimiento = new List<Cumplimiento>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM cumplimiento WHERE id_pregunta=@id_pregunta", conexion);

                comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Cumplimiento.Add(new Cumplimiento()
                        {
                            id_cumplimiento = reader.GetInt32(0),
                            id_pregunta = reader.GetInt32(1),
                            id_recomendacion = reader.GetInt32(2),
                            acciones_realizadas = reader.GetString(3),
                            fecha = reader.GetDateTime(6),
                            meta_alcanzada = reader.GetInt32(7),
                            documentos = reader.GetString(8)

                        });
                    }


                }
                catch (MySqlException ex)
                {

                }
                finally
                {
                    conexion.Close();
                }

                return Cumplimiento;
            }
        }


    }
}
