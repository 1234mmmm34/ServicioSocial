using ServicioSocial.Controllers;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ServicioSocial.Clases;
using System.Threading;

namespace ServicioSocial.Clases
{
    public class Recomendacion
    {

        public int id_recomendacion { get; set; }
        public int id_pregunta { get; set; }
        public string nombre { get; set; }

        public string accion { get; set; }

        public string responsable { get; set; }

        public string objetivos { get; set; }
        public int porcentaje_metas { get; set; }

        public DateTime fecha_limite { get; set; }

    }
}