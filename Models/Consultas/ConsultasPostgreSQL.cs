using Npgsql;
using pruebaConexionPostgreSQLV.Models.Conexiones;
using pruebaConexionPostgreSQLV.Models.DTOs;
using pruebaConexionPostgreSQLV.Models.ToDTOs;
using pruebaConexionPostgreSQLV.Util;

namespace pruebaConexionPostgreSQLV.Models.Consultas
{
    public class ConsultasPostgreSQL
    {
        // MÉTODOS
        public static List<AlumnoDTO> ConsultaSelectAlumnos(ConexionPostgreSQL conexionPostgreSQL)
        {
            List<AlumnoDTO> listaAlumnos = new List<AlumnoDTO>();
     
            // Declaramos una conexión del tipo de nuestro NuGet de PostgreSQL, la inicializamos y construímos la conexión con los parámetros de nuestra BBDD previamente definidos en otra clase, pero traídos como constantes aquí (por razones de seguridad y abstracción)
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            // Declaramos una variable para mostrar el flujo del programa por la consola y para debugear mejor en un futuro
            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                // Definimos la consulta y la ejecutamos
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                // Guardamos en una lista los datos obtenidos de la consulta select
                listaAlumnos = PostgreSQLtoDTO.ConsultaSelectAlumnosToDTO(resultadoConsulta);

                // Cerramos el flujo de los datos resultantes de la consulta
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                // Cerramos la conexión a nuestra BBDD
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaAlumnos;
        }

        public static List<AsignaturaDTO> ConsultaSelectAsignaturas(ConexionPostgreSQL conexionPostgreSQL)
        {
            List<AsignaturaDTO> listaAsignaturas = new List<AsignaturaDTO>();

            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"asignaturas\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaAsignaturas = PostgreSQLtoDTO.ConsultaSelectAsignaturasToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaAsignaturas;
        }

        public static List<RelAlumAsigDTO> ConsultaSelectRelAlumAsig(ConexionPostgreSQL conexionPostgreSQL)
        {
            List<RelAlumAsigDTO> listaRelAlumAsig = new List<RelAlumAsigDTO>();

            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"rel_alum_asig\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaRelAlumAsig = PostgreSQLtoDTO.ConsultaSelectRelAlumAsigToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaRelAlumAsig;
        }

        public static List<ProfesorDTO> ConsultaSelectProfesores(ConexionPostgreSQL conexionPostgreSQL)
        {
            List<ProfesorDTO> listaProfesores = new List<ProfesorDTO>();

            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"profesores\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaProfesores = PostgreSQLtoDTO.ConsultaSelectProfesoresToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaProfesores;
        }

        public static List<RelProfAsigDTO> ConsultaSelectRelProfAsig(ConexionPostgreSQL conexionPostgreSQL)
        {
            List<RelProfAsigDTO> listaRelProfAsig = new List<RelProfAsigDTO>();

            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"EjemploInicial\".\"rel_prof_asig\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                listaRelProfAsig = PostgreSQLtoDTO.ConsultaSelectRelProfAsigToDTO(resultadoConsulta);

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return listaRelProfAsig;
        }

        /****************************************** INSERTS *******************************************/

        public static void ConsultaInsertAlumnos(ConexionPostgreSQL conexionPostgreSQL)
        {
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("INSERT INTO \"EjemploInicial\".\"alumnos\" (alumno_id, alumno_nombre, alumno_apellidos, alumno_email) VALUES (DEFAULT, 'ivan', 'iglesias', 'ivan@gmail.com')", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }
        }

    }
}
