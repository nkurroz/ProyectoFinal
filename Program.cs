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
        const int MAX_STANDS = 40;
        static Emprendimiento[] listaMarket = new Emprendimiento[MAX_STANDS];
        static int contadorEmprendimientos = 0;

        static void Main(string[] args)
        {
            // Mia trabajará aquí adentro haciendo el menú y el switch-case
        }

        // Evan programará aquí:
        // static void RegistrarEmprendimiento() { ... }

        // Isabela programará aquí:
        // static void BuscarPorNombre() { ... }

        // Noraelena programará aquí:
       static void GuardarDatos()
        {
            using (StreamWriter sw = new StreamWriter("datos_emprendimientos.txt"))
            {
                for (int i = 0; i < contadorEmprendimientos; i++)
                {
                    Emprendimiento emp = listaMarket[i];
                    sw.WriteLine($"{emp.CodigoCredencial}|{emp.NombreNegocio}|{emp.Representante}|{emp.Categoria}|{emp.Telefono}|{emp.NumStand}|{emp.Estado}");
                }
            }
        }

        static void CargarDatos()
        {
            if (File.Exists("datos_emprendimientos.txt"))
            {
                // Seguridad 1: Reiniciamos el contador antes de leer para evitar duplicados
                contadorEmprendimientos = 0;

                using (StreamReader sr = new StreamReader("datos_emprendimientos.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()!) != null)
                    {
                        // Seguridad 2: Si el archivo tiene más registros que el tamaño del arreglo (MAX_STANDS = 40), frenamos el ciclo
                        if (contadorEmprendimientos >= MAX_STANDS)
                        {
                            Console.WriteLine("Advertencia: Se alcanzó el límite máximo de stands. Algunos datos no se cargaron.");
                            break;
                        }

                        string[] parts = line.Split('|');
                        if (parts.Length == 7)
                        {
                            Emprendimiento emp = new Emprendimiento
                            {
                                CodigoCredencial = parts[0],
                                NombreNegocio = parts[1],
                                Representante = parts[2],
                                Categoria = parts[3],
                                Telefono = parts[4],
                                NumStand = int.Parse(parts[5]),
                                Estado = parts[6]
                            };
                            listaMarket[contadorEmprendimientos++] = emp;
                        }
                    }
                }
            }
        }
        static void ReiniciarSistema()
        {
            Console.Clear();
            Console.WriteLine("        ¡ADVERTENCIA: REINICIO DEL SISTEMA!         ");
            Console.WriteLine("********************************************************");
            Console.WriteLine("Esta opción eliminará TODOS los emprendimientos actuales");
            Console.WriteLine("para dejar el sistema vacío para el Siguiente Evento.");
            Console.WriteLine("********************************************************");
            Console.Write("¿Está COMPLETAMENTE seguro de vaciar el sistema? (S/N): ");

            string respuesta = Console.ReadLine()!.ToUpper();

            if (respuesta == "S")
            {
                // 1. Vaciamos la memoria RAM
                contadorEmprendimientos = 0;

                try
                {
                    // 2. Vaciamos el archivo físico en el disco duro
                    File.WriteAllText("jaguarmarket.txt", string.Empty);

                    Console.WriteLine("\n¡Sistema reiniciado con éxito! Todo quedó en 0 para el siguiente Jaguar Market.");
                }
                catch (Exception)
                {
                    Console.WriteLine("\nError al limpiar el archivo, pero la memoria RAM fue reiniciada.");
                }
            }
            else
            {
                Console.WriteLine("\nOperación cancelada. Los datos actuales están a salvo.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        static void CancelarInscripcion()
        {
            Console.Clear();
            Console.WriteLine("--- CANCELAR INSCRIPCIÓN DE EMPRENDIMIENTO ---");
            Console.Write("Ingrese el Código (ej: JAG-001) o Nombre del negocio a cancelar: ");
            string busqueda = Console.ReadLine()!.ToLower();
            bool encontrado = false;

            for (int i = 0; i < contadorEmprendimientos; i++)
            {
                // Buscamos coincidencia por código o por nombre
                if (listaMarket[i].CodigoCredencial.ToLower() == busqueda || listaMarket[i].NombreNegocio.ToLower() == busqueda)
                {
                    encontrado = true;
                    Console.WriteLine($"\n  Emprendimiento Localizado:");
                    Console.WriteLine($"   Negocio: {listaMarket[i].NombreNegocio}");
                    Console.WriteLine($"   Representante: {listaMarket[i].Representante}");
                    Console.WriteLine($"   Stand Actual: {listaMarket[i].NumStand}");
                    Console.WriteLine($"   Estado Actual: {listaMarket[i].Estado}");
                    Console.WriteLine("------------------------------------------------");

                    if (listaMarket[i].Estado == "Cancelado")
                    {
                        Console.WriteLine("Este emprendimiento ya se encuentra cancelado anteriormente.");
                        break;
                    }

                    Console.Write("¿Está seguro de cambiar el estado a CANCELADO? (S/N): ");
                    if (Console.ReadLine()!.ToUpper() == "S")
                    {
                        listaMarket[i].Estado = "Cancelado";
                        Console.WriteLine("\nEl registro ha sido marcado como 'Cancelado' con éxito.");

                        // Guardado automático para actualizar el archivo .txt inmediatamente
                        GuardarDatos();
                    }
                    else
                    {
                        Console.WriteLine("\nOperación anulada. El registro sigue activo.");
                    }
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró ningún emprendimiento con esos datos.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
