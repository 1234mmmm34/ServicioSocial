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

        public class Aprobados_egel
        {
            public int id_carrera { get; set; }
            public string? generacion { get; set; }
            public int alumnos_egresados { get; set; }
            public int alumnos_examen { get; set; }
            public int alumnos_aprobados { get; }
        }

        public class docentes
        {
            public int id_carrera { get; set; }
            public int tiempo_completo { get; set; }
            public int tres_cuartos { get; set; }
            public int medio_tiempo { get; set; }
            public int por_asignatura { get; set; }
            public int tecnico_universitario { get; set; }
            public int profesional_asociado { get; set; }
            public int licenciatura { get; set; }
            public int especialidad { get; set; }
            public int maestria { get; set; }
            public int doctorado { get; set; }

        }
    }
}