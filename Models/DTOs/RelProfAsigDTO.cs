namespace pruebaConexionPostgreSQLV.Models.DTOs
{
    public class RelProfAsigDTO
    {
        // ATRIBUTOS
        public int id_asignatura { get; private set; }
        public string? nombreAsignatura { get; private set; }
        public int id_profesor { get; private set; }
        public string? nombreProfesor { get; private set; }


        // CONSTRUCTORES
        public RelProfAsigDTO(int id_asignatura, string? nombreAsignatura, int id_profesor, string? nombreProfesor)
        {
            this.id_asignatura = id_asignatura;
            this.nombreAsignatura = nombreAsignatura;
            this.id_profesor = id_profesor;
            this.nombreProfesor = nombreProfesor;
        }


        // ToString
        public override string ToString()
        {
            return String.Format
                (
                    "\n\t{0}\t\t{1}\t\t{2}\t\t{3}",

                    id_profesor,
                    nombreProfesor,
                    id_asignatura,
                    nombreAsignatura
                );
        }
    }
}
