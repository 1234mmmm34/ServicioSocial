using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioSocial.Clases;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServicioSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public static string cadena_conexion = Global.cadena_conexion;

        private readonly string secretKey;

        public UsuariosController(IConfiguration config)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost]
        [Route("autenticacion")]

        public IActionResult Autenticacion([FromBody] Usuario request)
        {
            List<Usuario> Usuario = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(cadena_conexion))
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM usuarios WHERE correo=@correo and clave=@clave", conexion);

                comando.Parameters.Add("@correo", MySqlDbType.VarChar).Value = request.correo;
                comando.Parameters.Add("@clave", MySqlDbType.VarChar).Value = request.clave;

                string tokenCreado="";
                try
                {

                    conexion.Open();

                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        //   if (request.correo == "urquidy12@gmail.com" && request.clave == "123") { 
                        Usuario.Add(new Usuario()
                        {
                            id_carrera = reader.GetInt32(0)

                        });

                        var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                        var claims = new ClaimsIdentity();

                        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.correo));

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = claims,
                            Expires = DateTime.UtcNow.AddMinutes(120),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)

                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                        tokenCreado = tokenHandler.WriteToken(tokenConfig);

                      

                        

                    }
                    return StatusCode(statusCode: 200, new { token = tokenCreado , Usuario});
                }
                catch (MySqlException ex)
                {
                    return StatusCode(statusCode: 401, new { token = "" });
                }
                finally
                {
                    conexion.Close();
                }
            }


        }
    }
}

