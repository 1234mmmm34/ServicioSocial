namespace ServicioSocial.Clases
{
    public class FichasTecnicas
    {
        public class Institucion
        {
            public string? mision { get; set; }
            public int vision { get; set; }
            public string? politicas { get; set; }
            public string? lineas_estrategicas { get; }
        }

        public class Facultad
        {
            public int id_facultad { get; set; }
            public int id_zona { get; set; }
            public string? nombre { get; set; }
            public string? campus { get; set; }
            public string? fecha_inicio { get; set; }
            public string? mision { get; set; }
            public string? vision { get; set; }
            public string? objetivos_string { get; set; }

        }
    }
}