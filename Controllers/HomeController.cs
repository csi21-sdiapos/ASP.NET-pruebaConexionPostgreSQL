using Microsoft.AspNetCore.Mvc;
using Npgsql;
using pruebaConexionPostgreSQLV.Models.Conexiones;
using pruebaConexionPostgreSQLV.Models;
using pruebaConexionPostgreSQLV.Util;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using pruebaConexionPostgreSQLV.Models.DTOs;
using pruebaConexionPostgreSQLV.Models.Consultas;

namespace pruebaConexionPostgreSQLV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Entra en Index\n");

            // CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;

            // CONEXIÓN
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);

            /************** Obtenemos los alumnos de la BBDD y los mostramos por consola ***************/

            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada + "\n");

            List<AlumnoDTO> listaAlumnos = new List<AlumnoDTO>();
            listaAlumnos = ConsultasPostgreSQL.ConsultaSelectAlumnos(conexionGenerada);

            System.Console.WriteLine("\n\n\tID\tNombre\tApellidos\tEmail");
            System.Console.WriteLine("\t------------------------------------------------");

            foreach (AlumnoDTO alumno in listaAlumnos)
                System.Console.WriteLine(alumno.ToString());

            /************* Obtenemos las asignaturas de la BBDD y los mostramos por consola ************/

            estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada + "\n");

            List<AsignaturaDTO> listaAsignaturas = new List<AsignaturaDTO>();
            listaAsignaturas = ConsultasPostgreSQL.ConsultaSelectAsignaturas(conexionGenerada);

            System.Console.WriteLine("\n\n\tID Asig.\tNombre Asig.");
            System.Console.WriteLine("\t-----------------------");

            foreach (AsignaturaDTO asignatura in listaAsignaturas)
                System.Console.WriteLine(asignatura.ToString());
            
            /* Obtenemos la relación entre alumnos y asignaturas asi de la BBDD y los mostramos por consola */
            
            estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada + "\n");

            List<RelAlumAsigDTO> listaRelAlumAsig = new List<RelAlumAsigDTO>();
            listaRelAlumAsig = ConsultasPostgreSQL.ConsultaSelectRelAlumAsig(conexionGenerada);

            System.Console.WriteLine("\n\n\tID Alum.\tNombre Alum.\tID Asig.\tNombre Asig.");
            System.Console.WriteLine("\t------------------------------------------------------------");

            foreach (RelAlumAsigDTO relAlumAsig in listaRelAlumAsig)
                System.Console.WriteLine(relAlumAsig.ToString());
            
            /************* Obtenemos los profesores de la BBDD y los mostramos por consola ************/

            estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada + "\n");

            List<ProfesorDTO> listaProfesores = new List<ProfesorDTO>();
            listaProfesores = ConsultasPostgreSQL.ConsultaSelectProfesores(conexionGenerada);

            //System.Console.WriteLine("\n\n\tID Asig.\tNombre\tID Prof.\tProfesor");
            System.Console.WriteLine("\n\n\tID\tNombre\t\tApellidos\tEmail");
            System.Console.WriteLine("\t------------------------------------------------");

            foreach (ProfesorDTO profesor in listaProfesores)
                System.Console.WriteLine(profesor.ToString());

            /* Obtenemos la relación entre profesores y asignaturas asi de la BBDD y los mostramos por consola */

            estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada + "\n");

            List<RelProfAsigDTO> listaRelProfAsig = new List<RelProfAsigDTO>();
            listaRelProfAsig = ConsultasPostgreSQL.ConsultaSelectRelProfAsig(conexionGenerada);

            //System.Console.WriteLine("\n\n\tID Asig.\tNombre\tID Prof.\tProfesor");
            System.Console.WriteLine("\n\n\tID Prof.\tNombre Prof.\t\tID Asig.\tNombre Asig.");
            System.Console.WriteLine("\t------------------------------------------------------------");

            foreach (RelProfAsigDTO relProfAsig in listaRelProfAsig)
                System.Console.WriteLine(relProfAsig.ToString());
            
            /************************* Hacemos un insert de un alumno *********************/

            estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada + "\n");

            ConsultasPostgreSQL.ConsultaInsertAlumnos(conexionGenerada);

            /************** Obtenemos los alumnos de la BBDD y los mostramos por consola ***************/

            estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada + "\n");

            listaAlumnos = new List<AlumnoDTO>();
            listaAlumnos = ConsultasPostgreSQL.ConsultaSelectAlumnos(conexionGenerada);

            System.Console.WriteLine("\n\n\tID\tNombre\tApellidos\tEmail");
            System.Console.WriteLine("\t------------------------------------------------");

            foreach (AlumnoDTO alumno in listaAlumnos)
                System.Console.WriteLine(alumno.ToString());

            // CERRAMOS LA CONEXIÓN
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Cierre de la conexión\n");
            conexionGenerada.Close();

            // y devolvemos la vista
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}