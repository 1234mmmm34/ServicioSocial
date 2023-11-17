using Microsoft.AspNetCore.Mvc;
using System.Net;
using MySql.Data;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Cors;
using ServicioSocial.Clases;
using Microsoft.AspNetCore.Authorization;

namespace ServicioSocial.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class FileController : ControllerBase
    {

        private string _pathString = @"C:\prueba_archivos\";
        public static string cadena_conexion = Global.cadena_conexion;


        [HttpPost]
        [Route("Guardar_Documento")]

        public string Guardar_Documento(string nombre_pregunta, IFormFile file)
        {
            string ruta_comprobante = "";

            bool archivo_guardado = false;

            nombre_pregunta = nombre_pregunta + '\\';
            if (file.Length > 0)
            {
                string filePath = Path.Combine(_pathString, nombre_pregunta, file.FileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);

                    ruta_comprobante = _pathString + file.FileName;

                }
            }
            return "Archivo guardado";
        }

      

    }
        
}
