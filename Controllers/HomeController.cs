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

        public IActionResult Index()
        {
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Entra en Index\n");

            /************ Declaramos un objeto de nuestra clase ConexionPostgreSQL y lo inicializamos () ************/
            // para esto usamos su constructor vacío (que cuando una clase no tiene constructor definido, predetermiandamente lleva el constructor vacío)
            ConexionPostgreSQL conexionPostgreSQL = new ConexionPostgreSQL(); // este objeto se lo iremos pasando como parámetro en las llamadas a nuestras consultas
            
            /***************** Obtenemos los alumnos de la BBDD y los mostramos por consola ***************/

            List<AlumnoDTO> listaAlumnos = new List<AlumnoDTO>();
            listaAlumnos = ConsultasPostgreSQL.ConsultaSelectAlumnos(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tID\tNombre\tApellidos\tEmail");
            System.Console.WriteLine("\t------------------------------------------------");

            foreach (AlumnoDTO alumno in listaAlumnos)
                System.Console.WriteLine(alumno.ToString());

            /************* Obtenemos las asignaturas de la BBDD y los mostramos por consola ************/

            List<AsignaturaDTO> listaAsignaturas = new List<AsignaturaDTO>();
            listaAsignaturas = ConsultasPostgreSQL.ConsultaSelectAsignaturas(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tID Asig.\tNombre Asig.");
            System.Console.WriteLine("\t-----------------------");

            foreach (AsignaturaDTO asignatura in listaAsignaturas)
                System.Console.WriteLine(asignatura.ToString());

            /* Obtenemos la relación entre alumnos y asignaturas asi de la BBDD y los mostramos por consola */
            
            List<RelAlumAsigDTO> listaRelAlumAsig = new List<RelAlumAsigDTO>();
            listaRelAlumAsig = ConsultasPostgreSQL.ConsultaSelectRelAlumAsig(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tID Alum.\tNombre Alum.\tID Asig.\tNombre Asig.");
            System.Console.WriteLine("\t------------------------------------------------------------");

            foreach (RelAlumAsigDTO relAlumAsig in listaRelAlumAsig)
                System.Console.WriteLine(relAlumAsig.ToString());
            
            /************* Obtenemos los profesores de la BBDD y los mostramos por consola ************/

            List<ProfesorDTO> listaProfesores = new List<ProfesorDTO>();
            listaProfesores = ConsultasPostgreSQL.ConsultaSelectProfesores(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tID\tNombre\t\tApellidos\tEmail");
            System.Console.WriteLine("\t------------------------------------------------");

            foreach (ProfesorDTO profesor in listaProfesores)
                System.Console.WriteLine(profesor.ToString());

            /* Obtenemos la relación entre profesores y asignaturas asi de la BBDD y los mostramos por consola */

            List<RelProfAsigDTO> listaRelProfAsig = new List<RelProfAsigDTO>();
            listaRelProfAsig = ConsultasPostgreSQL.ConsultaSelectRelProfAsig(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tID Prof.\tNombre Prof.\t\tID Asig.\tNombre Asig.");
            System.Console.WriteLine("\t------------------------------------------------------------");

            foreach (RelProfAsigDTO relProfAsig in listaRelProfAsig)
                System.Console.WriteLine(relProfAsig.ToString());

            /*************************** Hacemos un insert de un alumno ************************/

            ConsultasPostgreSQL.ConsultaInsertAlumnos(conexionPostgreSQL);

            /***************** Obtenemos los alumnos de la BBDD y los mostramos por consola ***************/

            listaAlumnos = new List<AlumnoDTO>();
            listaAlumnos = ConsultasPostgreSQL.ConsultaSelectAlumnos(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tID\tNombre\tApellidos\tEmail");
            System.Console.WriteLine("\t------------------------------------------------");

            foreach (AlumnoDTO alumno in listaAlumnos)
                System.Console.WriteLine(alumno.ToString());


            /**** finalmente devolvemos la vista, al igual que cualquier otro método del tipo IActionResult ***/
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Lógica del Index finalizada\n");

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