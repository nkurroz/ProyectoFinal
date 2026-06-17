static void Main()
{
    int opcion;

    do
    {
        Console.WriteLine("\n===== UAM JAGUAR MARKET =====");
        Console.WriteLine("1. Registrar emprendimiento");
        Console.WriteLine("2. Salir");
        Console.Write("Seleccione una opción: ");

        opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                RegistrarEmprendimiento();
                break;

            case 2:
                Console.WriteLine("Saliendo del sistema...");
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }

    } while (opcion != 2);
}
