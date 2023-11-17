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

        public class Programa_academico
        {
            public int id_carrera { get; set; }
            public string? nombre { get; set; }
            public string? documento_creacion { get; set; }
            public string? numero_rvoe { get; set; }
            public string? institucion_rvoe { get; set; }
            public string? mision { get; set; }
            public string? vision { get; set; }
            public string? objetivos_estrategicos { get; set; }

        }
        public class Docentes
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

        public class Aprobados_egel
        {
            public int id_carrera { get; set; }
            public string? generacion { get; set; }
            public int alumnos_egresados { get; set; }
            public int alumnos_examen { get; set; }
            public int alumnos_aprobados { get; }
        }

        public class Matricula
        {
            public int id_carrera { get; set; }
            public string? generacion { get; set; }
            public int hombre_nuevo { get; set; }
            public int mujer_nuevo { get; set; }
            public int hombre_reingreso { get; set; }
            public int mujer_reingreso { get; set; }

        }

        public class Rendimiento_escolar
        {
            public int id_carrera { get; set; }
            public string generacion { get; set; }
            public int estudiantes { get; set; }
            public int desercion { get; set; }
            public int reprobacion { get; set; }
            public int titulados { get; set; }

        }

        public class Responsables
        {
            public int id_responsable { get; set; }
            public int id_carrera { get; set; }
            public string? nombre { get; set; }
            public string? cargo { get; set; }
            public string? correo { get; set; }
            public string? telefono { get; set; }

        }

    }
}