using System;

class Program
{
    static void Main()
    {
        // Definir el arreglo y su tamaño máximo
        string[] market = new string[40];

        int MAX_STANDS = 40;
        int contadorEmprendimiento = 0;

        string Emprendimiento;
        string Propietario;
        string Categoria;
        string Telefono;
        int NumStand;
        string CodigoCredencial;
        string Estado;

        if (contadorEmprendimiento >= MAX_STANDS)
        {
            Console.WriteLine("Ya no hay stands disponibles :(");
            Console.WriteLine("El emprendimiento pasará a la lista de espera para el próximo Jaguar Market");
        }
        else
        {
            Console.Write("Ingrese el nombre del emprendimiento: ");
            Emprendimiento = Console.ReadLine();

            Console.Write("Ingrese el nombre del propietario del negocio: ");
            Propietario = Console.ReadLine();

            Console.Write("Ingrese la categoría (Comida, ropa, accesorios, tecnología, maquillaje): ");
            Categoria = Console.ReadLine();

            Console.Write("Ingrese su número telefónico: ");
            Telefono = Console.ReadLine();

            // Procesos automáticos
            NumStand = contadorEmprendimiento + 1;
            CodigoCredencial = "JAG-" + NumStand;
            Estado = "Confirmado";

            // Almacenamiento en el arreglo
            market[contadorEmprendimiento] = Emprendimiento;
            contadorEmprendimiento++;

            Console.WriteLine("\n¡Inscripción agregada!");
            Console.WriteLine("Código asignado: " + CodigoCredencial);

            // Mostrar información registrada
            Console.WriteLine("\n--- Datos registrados ---");
            Console.WriteLine("Emprendimiento: " + Emprendimiento);
            Console.WriteLine("Propietario: " + Propietario);
            Console.WriteLine("Categoría: " + Categoria);
            Console.WriteLine("Teléfono: " + Telefono);
            Console.WriteLine("Stand: " + NumStand);
            Console.WriteLine("Estado: " + Estado);
        }
    }
}
