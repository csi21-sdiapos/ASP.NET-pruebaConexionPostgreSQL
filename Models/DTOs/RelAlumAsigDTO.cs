namespace pruebaConexionPostgreSQLV.Models.DTOs
{
    public class RelAlumAsigDTO
    {
        // ATRIBUTOS
        public int id_asignatura { get; private set; }
        public string? nombreAsignatura { get; private set; }
        public int id_alumno { get; private set; }
        public string? nombreAlumno { get; private set; }


        // CONSTRUCTORES
        public RelAlumAsigDTO(int id_asignatura, string? nombreAsignatura, int id_alumno, string? nombreAlumno)
        {
            this.id_asignatura = id_asignatura;
            this.nombreAsignatura = nombreAsignatura;
            this.id_alumno = id_alumno;
            this.nombreAlumno = nombreAlumno;
        }

        // ToString
        public override string ToString()
        {
            return String.Format
                (
                    "\n\t{0}\t\t{1}\t\t{2}\t\t{3}",

                    id_alumno,
                    nombreAlumno,
                    id_asignatura,
                    nombreAsignatura
                );
        }
    }
}
