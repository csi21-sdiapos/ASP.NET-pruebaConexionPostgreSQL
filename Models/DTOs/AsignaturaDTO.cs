namespace pruebaConexionPostgreSQLV.Models.DTOs
{
    public class AsignaturaDTO
    {
        // ATRIBUTOS
        public int id_asignatura { get; private set; }
        //Al añadir al tipo el símbolo ? se admite null en el campo al salir del constructor.
        public string? nombreAsignatura { get; private set; }


        // CONSTRUCTORES
        public AsignaturaDTO(int id_asignatura, string? nombreAsignatura)
        {
            this.id_asignatura = id_asignatura;
            this.nombreAsignatura = nombreAsignatura;
        }


        // ToString
        public override string ToString()
        {
            return String.Format
                (
                    "\n\t{0}\t\t{1}",

                    id_asignatura,
                    nombreAsignatura
                );
        }
    }
}
