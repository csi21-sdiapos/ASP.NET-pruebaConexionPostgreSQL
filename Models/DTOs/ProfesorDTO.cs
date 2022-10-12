namespace pruebaConexionPostgreSQLV.Models.DTOs
{
    public class ProfesorDTO
    {
        // ATRIBUTOS
        public int id_profesor { get; private set; }
        public string? nombre { get; private set; }
        public string? apellidos { get; private set; }
        public string? email { get; private set; }


        // CONSTRUCTORES
        public ProfesorDTO(int id_profesor, string? nombre, string? apellidos, string? email)
        {
            this.id_profesor = id_profesor;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
        }


        // ToString
        public override string ToString()
        {
            return String.Format
                (
                    "\n\t{0}\t{1}\t{2}\t{3}",

                    id_profesor,
                    nombre,
                    apellidos,
                    email
                );
        }
    }
}
