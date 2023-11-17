namespace ServicioSocial.Clases
{
    public class Cumplimiento
    {

        public int id_cumplimiento { get; set; }
        public int id_pregunta { get; set; }
        public int id_recomendacion { get; set; }
        public string? acciones_realizadas { get; set; }
        public DateTime fecha { get; set; }
        public int meta_alcanzada { get; set; }
        public string? documentos { get; set; }
    }
}
