using Npgsql;
using pruebaConexionPostgreSQLV.Models.DTOs;

namespace pruebaConexionPostgreSQLV.Models.ToDTOs
{
    public class PostgreSQLtoDTO
    {
        public static List<AlumnoDTO> ConsultaSelectAlumnosToDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<AlumnoDTO> listaAlumnos = new List<AlumnoDTO>();

            while (resultadoConsulta.Read())
            {
                listaAlumnos.Add
                    (
                        new AlumnoDTO
                            (
                                Convert.ToInt32(resultadoConsulta[0]),
                                Convert.ToString(resultadoConsulta[1]),
                                Convert.ToString(resultadoConsulta[2]),
                                Convert.ToString(resultadoConsulta[3])
                            )
                    );
            }

            return listaAlumnos;
        }

        public static List<AsignaturaDTO> ConsultaSelectAsignaturasToDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<AsignaturaDTO> listaAsignaturas = new List<AsignaturaDTO>();

            while (resultadoConsulta.Read())
            {
                listaAsignaturas.Add
                    (
                        new AsignaturaDTO
                            (
                                Convert.ToInt32(resultadoConsulta[0]),
                                Convert.ToString(resultadoConsulta[1])
                            )
                    );
            }

            return listaAsignaturas;
        }

        public static List<RelAlumAsigDTO> ConsultaSelectRelAlumAsigToDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<RelAlumAsigDTO> listaRelAlumAsig = new List<RelAlumAsigDTO>();

            while (resultadoConsulta.Read())
            {
                listaRelAlumAsig.Add
                    (
                        new RelAlumAsigDTO
                            (
                                Convert.ToInt32(resultadoConsulta[0]),
                                Convert.ToString(resultadoConsulta[1]),
                                Convert.ToInt32(resultadoConsulta[2]),
                                Convert.ToString(resultadoConsulta[3])
                            )
                    );
            }

            return listaRelAlumAsig;
        }

        public static List<ProfesorDTO> ConsultaSelectProfesoresToDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<ProfesorDTO> listaProfesores = new List<ProfesorDTO>();

            while (resultadoConsulta.Read())
            {
                listaProfesores.Add
                    (
                        new ProfesorDTO
                            (
                                Convert.ToInt32(resultadoConsulta[0]),
                                Convert.ToString(resultadoConsulta[1]),
                                Convert.ToString(resultadoConsulta[2]),
                                Convert.ToString(resultadoConsulta[3])
                            )
                    );
            }

            return listaProfesores;
        }

        public static List<RelProfAsigDTO> ConsultaSelectRelProfAsigToDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<RelProfAsigDTO> listaRelProfAsig = new List<RelProfAsigDTO>();

            while (resultadoConsulta.Read())
            {
                listaRelProfAsig.Add
                    (
                        new RelProfAsigDTO
                            (
                                Convert.ToInt32(resultadoConsulta[0]),
                                Convert.ToString(resultadoConsulta[1]),
                                Convert.ToInt32(resultadoConsulta[2]),
                                Convert.ToString(resultadoConsulta[3])
                            )
                    );
            }

            return listaRelProfAsig;
        }
    }
}
