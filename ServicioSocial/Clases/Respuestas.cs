using ServicioSocial.Controllers;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ServicioSocial.Clases;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace ServicioSocial.Clases
{
    public class Pregunta
    {

        public int id_pregunta { get; set; }
        public int id_carrera { get; set; }
        public int eje { get; set; }
        public int categoria { get; set; }
        public int indicador { get; set; }
        public string? nombre { get; set; }


    }
}
