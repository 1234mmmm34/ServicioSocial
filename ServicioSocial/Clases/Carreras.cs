namespace ServicioSocial.Clases
{
    public class Carreras
    {
        public class Zona
        {
            public int id_zona { get; set; }
            public string? nombre { get; set; }
        }

        public class Facultad
        {
            public int id_facultad { get; set; }
            public int id_zona { get; set; }
            public string? nombre { get; set; }
        }

        public class Carrera
        {
            public int id_carrera { get; set; }
            public string? nombre { get; set; }
            public int id_facultad { get; set; }
        }
    }
}
