using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ServicioSocial.Clases;
using static ServicioSocial.Clases.Carreras;

namespace ServicioSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarrerasController : ControllerBase
    {

        public static string cadena_conexion = Global.cadena_conexion;

        [HttpPost]
        [Route("Consultar_Zona")]

        public IEnumerable<Zona> Consultar_Zona([FromBody] Zona request)
        {
            List<Zona> Zona = new List<Zona>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM zona", conexion);

                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Zona.Add(new Zona()
                        {
                            id_zona = reader.GetInt32(0),
                            nombre = reader.GetString(1)

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

                return Zona;
            }
        }


        [HttpPost]
        [Route("Consultar_Facultad")]

        public IEnumerable<Facultad> Consultar_Facultad([FromBody] Facultad request)
        {
            List<Facultad> Facultad = new List<Facultad>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM facultad", conexion);

                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Facultad.Add(new Facultad()
                        {
                            id_facultad = reader.GetInt32(0),
                            id_zona = reader.GetInt32(1),
                            nombre = reader.GetString(2)

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

                return Facultad;
            }
        }

        [HttpPost]
        [Route("Consultar_Carrera")]

        public IEnumerable<Carrera> Consultar_Carrera([FromBody] Carrera request)
        {
            List<Carrera> Carrera = new List<Carrera>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {
                MySqlCommand comando = new MySqlCommand("SELECT * FROM carrera", conexion);

                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Carrera.Add(new Carrera()
                        {
                            
                            id_carrera = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            id_facultad = reader.GetInt32(2)

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

                return Carrera;
            }
        }


    }
}
