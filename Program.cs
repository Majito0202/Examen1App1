using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1App1
{
    internal class Program //CLASE RELACION CON TODAS MENÚ 
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu(1000);

            while (true)
            {
                menu.MostrarMenu();

                Console.Write("DIGITE UNA OPCIÓN: ");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        menu.AgregarEmpleado();
                        break;
                    case 2:
                        menu.ConsultarEmpleados();
                        break;
                    case 3:
                        menu.ModificarEmpleado();
                        break;
                    case 4:
                        menu.BorrarEmpleado();
                        break;
                    case 5:
                        menu.InicializarArreglos();
                        break;
                    case 6:
                        menu.MostrarReportes();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("OPCIÓN INVALIDA.");
                        break;
                }
            }
        }
    }
}

  