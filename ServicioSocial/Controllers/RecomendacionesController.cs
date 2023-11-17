using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ServicioSocial.Clases;
using System;
using System.Data;

namespace ServicioSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendacionesController : ControllerBase
    {
        public static string cadena_conexion = Global.cadena_conexion;

        [HttpPost]
        [Route("Agregar_Recomendacion")]

        public IActionResult Agregar_Recomendacion([FromBody] Recomendacion request)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("insert into recomendacion (id_pregunta, nombre, accion, responsable, objetivos, porcentaje_metas, fecha_limite) VALUES (@id_pregunta, @nombre, @accion, @responsable, @objetivos, @porcentaje_metas, @fecha_limite)", conexion);

                //@id_usuario, @Tipo_deuda,@Nombre_deuda, @Monto, @Ruta_comprobante, @Estado

                comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;
                comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = request.nombre;
                comando.Parameters.Add("@accion", MySqlDbType.VarChar).Value = request.accion;
                comando.Parameters.Add("@responsable", MySqlDbType.VarChar).Value = request.responsable;
                comando.Parameters.Add("@objetivos", MySqlDbType.VarChar).Value = request.objetivos;
                comando.Parameters.Add("@porcentaje_metas", MySqlDbType.Int32).Value = request.porcentaje_metas;
                comando.Parameters.Add("@fecha_limite", MySqlDbType.Date).Value = request.fecha_limite;

                //  comando.Parameters.Add("@fecha", MySqlDbType.Date).Value = fecha;




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

        [HttpDelete]
        [Route("Eliminar_Recomendacion")]

        public IActionResult Eliminar_Recomendacion([FromBody] Recomendacion request)
        {


            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("DELETE FROM recomendacion WHERE id_recomendacion=@id_recomendacion", conexion);

                //@id_usuario, @Tipo_deuda,@Nombre_deuda, @Monto, @Ruta_comprobante, @Estado

              //  comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;
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
        [Route("Actualizar_Recomendacion")]

        public IActionResult Actualizar_Recomendacion([FromBody] Recomendacion request)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                int rowsaffected = 0;
                MySqlCommand comando = new MySqlCommand("UPDATE recomendacion " +
                    "SET nombre=@nombre, accion=@accion, responsable=@responsable, objetivos=@objetivos, porcentaje_metas=@porcentaje_metas, fecha_limite=@fecha_limite" +
                    "WHERE id_recomendacion=@id_recomendacion", conexion);

                comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = request.nombre;
                comando.Parameters.Add("@accion", MySqlDbType.VarChar).Value = request.accion;
                comando.Parameters.Add("@responsable", MySqlDbType.VarChar).Value = request.responsable;
                comando.Parameters.Add("@objetivos", MySqlDbType.VarChar).Value = request.objetivos;
                comando.Parameters.Add("@porcentaje_metas", MySqlDbType.Int32).Value = request.porcentaje_metas;
                comando.Parameters.Add("@fecha_limite", MySqlDbType.Date).Value = request.fecha_limite;
             //   comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;
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

        [HttpPost]
        [Route("Consultar_Recomendacion")]

        public IEnumerable<Recomendacion> Consultar_Recomendaciones([FromBody] Recomendacion request)
        {
            List<Recomendacion> Recomendacion = new List<Recomendacion>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM recomendacion WHERE id_pregunta=@id_pregunta", conexion);

                comando.Parameters.Add("@id_pregunta", MySqlDbType.Int32).Value = request.id_pregunta;


                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Recomendacion.Add(new Recomendacion()
                        {
                            id_recomendacion = reader.GetInt32(0),
                            id_pregunta = reader.GetInt32(1),
                            nombre = reader.GetString(2),
                            accion = reader.GetString(3),
                            responsable = reader.GetString(4),
                            objetivos = reader.GetString(5),
                            porcentaje_metas = reader.GetInt32(6),
                            fecha_limite = reader.GetDateTime(7)

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

                return Recomendacion;
            }
        }
    }
    
}
