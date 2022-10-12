using Npgsql;
using pruebaConexionPostgreSQLV.Models.DTOs;
using pruebaConexionPostgreSQLV.Models.ToDTOs;

namespace pruebaConexionPostgreSQLV.Models.Consultas
{
    public class ConsultasPostgreSQL
    {
        
        // MÉTODOS
        public static List<AlumnoDTO> ConsultaSelectAlumnos(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoDTO> listaAlumnos = new List<AlumnoDTO>();

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaAlumnos = PostgreSQLtoDTO.ConsultaSelectAlumnosToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaAlumnos;
        }

        public static List<AsignaturaDTO> ConsultaSelectAsignaturas(NpgsqlConnection conexionGenerada)
        {
            List<AsignaturaDTO> listaAsignaturas = new List<AsignaturaDTO>();

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"asignaturas\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaAsignaturas = PostgreSQLtoDTO.ConsultaSelectAsignaturasToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaAsignaturas;
        }

        public static List<RelAlumAsigDTO> ConsultaSelectRelAlumAsig(NpgsqlConnection conexionGenerada)
        {
            List<RelAlumAsigDTO> listaRelAlumAsig = new List<RelAlumAsigDTO>();

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"rel_alum_asig\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaRelAlumAsig = PostgreSQLtoDTO.ConsultaSelectRelAlumAsigToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaRelAlumAsig;
        }

        public static List<ProfesorDTO> ConsultaSelectProfesores(NpgsqlConnection conexionGenerada)
        {
            List<ProfesorDTO> listaProfesores = new List<ProfesorDTO>();

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"profesores\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaProfesores = PostgreSQLtoDTO.ConsultaSelectProfesoresToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaProfesores;
        }

        public static List<RelProfAsigDTO> ConsultaSelectRelProfAsig(NpgsqlConnection conexionGenerada)
        {
            List<RelProfAsigDTO> listaRelProfAsig = new List<RelProfAsigDTO>();

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"rel_prof_asig\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaRelProfAsig = PostgreSQLtoDTO.ConsultaSelectRelProfAsigToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaRelProfAsig;
        }

        /****************************************** INSERTS *******************************************/

        public static void ConsultaInsertAlumnos(NpgsqlConnection conexionGenerada)
        {
            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("INSERT INTO \"EjemploInicial\".\"alumnos\" (alumno_id, alumno_nombre, alumno_apellidos, alumno_email) VALUES (DEFAULT, 'ivan', 'iglesias', 'ivan@gmail.com')", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }
        }

    }
}
