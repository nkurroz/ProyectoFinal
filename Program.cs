using System;
using System.IO;

namespace SistemaJaguarMarket
{
    class Program
    {
        // 1. TODOS DEBEN TENER LA MISMA ESTRUCTURA EXACTA
        struct Emprendimiento
        {
            public string CodigoCredencial;
            public string NombreNegocio;
            public string Representante;
            public string Categoria;
            public string Telefono;
            public int NumStand;
            public string Estado; 
        }

        // 2. TODOS DEBEN USAR ESTAS MISMAS VARIABLES (Mismos nombres)
        const int MAX_STANDS = 100;
        static Emprendimiento[] listaMarket = new Emprendimiento[MAX_STANDS];
        static int contadorEmprendimientos = 0;

        
            // Mia trabajará aquí adentro haciendo el menú y el switch-case
            int menu()
            {
                Console.WriteLine("=== Jaguar Market ===");
                Console.WriteLine("1. Registrar Emprendimiento");
                Console.WriteLine("2. Buscar por Nombre");
                Console.WriteLine("3. Guardar Datos");
                Console.WriteLine("4. Cargar Datos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                return opcion;
            }
            void main()
            {
                int opcion;
                do
                {
                    opcion = menu();
                    switch (opcion)
                    {
                        case 1:
                            RegistrarEmprendimiento();
                            break;
                        case 2:
                            BuscarPorNombre();
                            break;
                        case 3:
                            GuardarDatos();
                            break;
                        case 4:
                            CargarDatos();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                } while (opcion != 5);
            }

        

        // Evan programará aquí:
        // static void RegistrarEmprendimiento() { ... }

        // Isabela programará aquí:
        // static void BuscarPorNombre() { ... }

        // Noraelena programará aquí:
        // static void GuardarDatos() { ... }
        // static void CargarDatos() { ... }
    }
}
