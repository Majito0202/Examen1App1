using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1App1
{
    internal class Menu //CLASE VARIABLES GLOBALES-LOCALES Y ARREGLOS
    {

        private Empleado[] empleados;

        public Menu(int maxEmpleados)
        {
            empleados = new Empleado[maxEmpleados];
        }

        public void MostrarMenu() //MENU PRINCIPAL
        {

            Console.WriteLine("-BIENVENIDO AL SISTEMA DE RECURSOS HUMANOS-");
            Console.WriteLine("-------MENÚ PRINCIPAL-------");
            Console.WriteLine("                                               ");
            Console.WriteLine("1- AGREGAR EMPLEADOS");
            Console.WriteLine("2- CONSULTAR EMPLEADOS");
            Console.WriteLine("3- MODIFICAR EMPLEADOS");
            Console.WriteLine("4- BORRAR EMPLEADOS");
            Console.WriteLine("5- INICIALIZAR ARREGLOS");
            Console.WriteLine("6- GENERAR REPORTES");
            Console.WriteLine("7- SALIR");
        }

        public void AgregarEmpleado() //DATOS EMPLEADOS ALMACENADOS
        {

            Console.WriteLine("------SISTEMA EN AGREGAR EMPLEADO------");
            Console.WriteLine("                                               ");
            Console.Write("INSERTE CÉDULA DEL EMPLEADO: ");
            string cedula = Console.ReadLine();
            Console.Write("INSERTE NOMBRE DEL EMPLEADO: ");
            string nombre = Console.ReadLine();
            Console.Write("INSERTE DIRECCIÓN DEL EMPLEADO: ");
            string direccion = Console.ReadLine();
            Console.Write("INSERTE NÚMERO DE TELEFONO DEL EMPLEADO: ");
            string telefono = Console.ReadLine();
            Console.Write("INSERTE SALARIO DEL EMPLEADO: ");
            double salario = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] == null)
                {
                    empleados[i] = new Empleado(cedula, nombre, direccion, telefono, salario);
                    Console.WriteLine("EL EMPLEADO SE AGREGO CON ÉXITO.");
                    return;
                }
            }
            Console.WriteLine("SIN ESPACIO PARA AGREGAR EMPLEADOS.INTENTELO EN OTRO MOMENTO");
        }

        public void ConsultarEmpleados() // ALMACENADOS
        {
            Console.WriteLine("------SISTEMA LISTADO DE EPLEADOS------");

            Console.WriteLine("LISTA DE EMPEADOS: ");
            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    Console.WriteLine($"CEDULA: {empleado.Cedula}, NOMBRE: {empleado.Nombre}, DIRECCIÓN: {empleado.Direccion}, TEL: {empleado.Telefono}, SALARIO:  {empleado.Salario}");
                }
            }
        }

        public void ModificarEmpleado()
        {
            Console.WriteLine("------SISTEMA EN MODIFICAR EMPLEADO------");
            Console.WriteLine("                                               ");
            Console.Write("INSERTE NÚMERO DE CÉDULA QUE DESEA MODIFICAR: ");
            string cedula = Console.ReadLine();

            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    Console.Write("INSERTE EL NUEVO NOMBRE DEL EMPLEADO: ");
                    empleados[i].Nombre = Console.ReadLine();
                    Console.Write("INSERTE NUEVA DIRECCION DEL EMPLEADO: ");
                    empleados[i].Direccion = Console.ReadLine();
                    Console.Write("INSERTE NUEVO # DE TELEFONO DEL EMPLEADO: ");
                    empleados[i].Telefono = Console.ReadLine();
                    Console.Write("INSERTE EL NUEVO SALARIO DEL EMPLEADO: ");
                    empleados[i].Salario = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("SE MODIFICÓ CON ÉXITO.");
                    return;
                }
            }
            Console.WriteLine("EMPLEADO NO ENCOTRADO, # DE CÉDULA INVALIDA");
        }

        public void BorrarEmpleado() // ELIMINACION DE EMPLEADOS UTILIZAR FOR 
        {
            Console.WriteLine("------SISTEMA EN ELIMINACIÓN DEL EMPLEADO------");
            Console.WriteLine("                                               ");
            Console.Write("INSERTE NÚMERO DE CÉDULA DEL EMPLEADO QUE DESEA ELIMINAR: ");
            string cedula = Console.ReadLine();

            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    empleados[i] = null;
                    Console.WriteLine("SE ELIMINO DE MANERA EXITOSA");
                    return;
                }
            }
            Console.WriteLine("NÚMERO DE CÉDULA NO ENCONTRADA. INTENTELO NUEVAMENTE. ");
        }



        public void MostrarReportes()  // REPORTE DE TODOS LOS EMPLEADOS ALMACENADOS - FUNCION SWITCH 
        {

            Console.WriteLine("---------MENÚ REPORTES---------");
            Console.WriteLine("                                               ");
            Console.WriteLine("1- CONSULTAR EMPLEADOS CON EL # DE CÉDULA");
            Console.WriteLine("2- LISTAR TODOS LOS EMPLEADOS ORDENADOS POR EL NOMBRE");
            Console.WriteLine("3- CALCULAR Y MOSTRAR EL PROMEDIO DE LOS SALARIOS");
            Console.WriteLine("4- CALCULAR Y MOSTRAR EL SALARIO MÁS ALTO Y MÁS BAJO DE TODOS LOS EMPLEADOS.");
            Console.WriteLine("---------RECURSOS HUMANOS-------");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write(" INSERTE NÚMERO DE CÉDULA DEL EMPLEADO QUE DESEA CONSULTAR: ");
                    string cedula = Console.ReadLine();
                    ConsultarEmpleadoPorCedula(cedula);
                    break;
                case 2:
                    ListarEmpleadosOrdenadosPorNombre();
                    break;
                case 3:
                    CalcularPromedioSalarios();
                    break;
                case 4:
                    CalcularSalarioMaximoMinimo();
                    break;
                default:
                    Console.WriteLine("OPCIÓN INVALIDA.INTENTELO NUEVAMENTE");
                    break;
            }
        }


        public void InicializarArreglos()
        {
            empleados = new Empleado[empleados.Length];
            Console.WriteLine("ARREGLOS INICIALIZADOS CON ÉXITO. ");
        }


        private void ConsultarEmpleadoPorCedula(string cedula)
        {
            foreach (var empleado in empleados)
            {
                if (empleado != null && empleado.Cedula == cedula)
                {
                    Console.WriteLine($"CÉDULA: {empleado.Cedula}, NOMBRE: {empleado.Nombre}, DIRECCIÓN: {empleado.Direccion}, TEL: {empleado.Telefono}, Salario: {empleado.Salario}");
                    return;
                }
            }
            Console.WriteLine("NÚMERO DE CÉDULA NO ENCONTRADO");
        }

        private void ListarEmpleadosOrdenadosPorNombre() // ARRAY. SORT = ORDEN ASCENTENTE
        {
            Array.Sort(empleados, delegate (Empleado emp1, Empleado emp2)
            {
                if (emp1 != null && emp2 != null)
                {
                    return emp1.Nombre.CompareTo(emp2.Nombre);
                }
                return 0;
            });

            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    Console.WriteLine($"CÉDULA: {empleado.Cedula}, NOMBRE: {empleado.Nombre}, DIRECCIÓN: {empleado.Direccion}, TEL: {empleado.Telefono}, SALARIO: {empleado.Salario}");
                }
            }
        }

        private void CalcularPromedioSalarios()
        {
            double totalSalarios = 0;
            int contador = 0;
            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    totalSalarios += empleado.Salario;
                    contador++;
                }
            }
            if (contador > 0)
            {
                double promedio = totalSalarios / contador;
                Console.WriteLine($"EL PROMEDIO DE SALARIO ES : {promedio}");
            }
            else
            {
                Console.WriteLine("SIN EMPLEADOS PARA CALCULAR PROMEDIO.");
            }
        }

        private void CalcularSalarioMaximoMinimo()
        {
            double salarioMaximo = double.MinValue;
            double salarioMinimo = double.MaxValue;

            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    if (empleado.Salario > salarioMaximo)
                    {
                        salarioMaximo = empleado.Salario;
                    }
                    if (empleado.Salario < salarioMinimo)
                    {
                        salarioMinimo = empleado.Salario;
                    }
                }
            }

            if (salarioMaximo != double.MinValue && salarioMinimo != double.MaxValue)
            {
                Console.WriteLine("------SISTEMA EN SALARIOS------");
                Console.WriteLine("                                               ");
                Console.WriteLine($"EL SALARIO MÁS ALTO: {salarioMaximo}");
                Console.WriteLine($"SALARIO MÁS BAJO: {salarioMinimo}");
            }
            else
            {
                Console.WriteLine("SIN SALARIOS PARA CALCULAR (MÁS ALTO) Y (MÁS BAJO)");
            }
        }
    }
}

