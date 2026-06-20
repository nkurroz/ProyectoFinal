using System;
using System.IO;

namespace SistemaJaguarMarket
{
    class Program
    {
        // 1. DEFINICIÓN DE ESTRUCTURAS

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

        // 2. VARIABLES GLOBALES Y CONSTANTES
        const int MAX_STANDS = 40;
        static Emprendimiento[] listaMarket = new Emprendimiento[MAX_STANDS];
        static int contadorEmprendimientos = 0;

        // Mia programará aquí
        static void Main(string[] args)
        {

            CargarDatos();

            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("        SISTEMA DE GESTIÓN JAGUAR MARKET         ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Registrar Emprendimiento");
                Console.WriteLine("2. Mostrar Todos los Emprendimientos Inscritos");
                Console.WriteLine("3. Buscar Emprendimiento por Nombre");
                Console.WriteLine("4. Cancelar Inscripción de Emprendimiento");
                Console.WriteLine("5. Guardar Información en Archivo");
                Console.WriteLine("6. Reiniciar Sistema para Siguiente Evento");
                Console.WriteLine("7. Salir del Sistema");
                Console.WriteLine("==================================================");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: RegistrarEmprendimiento(); break;
                        case 2: MostrarInscritos(); break;
                        case 3: BuscarPorNombre(); break;
                        case 4: CancelarInscripcion(); break;
                        case 5:
                            GuardarDatos();
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                        case 6: ReiniciarSistema(); break;
                        case 7:
                            GuardarDatos();
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Presione Enter.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, introduce un número válido. Presione Enter.");
                    Console.ReadKey();
                }
            } while (opcion != 7);
        }

        // Evan programará aquí

        static void RegistrarEmprendimiento()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRAR NUEVO EMPRENDIMIENTO ---");

            // 1. Buscar si existe algún stand cancelado que podamos reutilizar
            int indiceDisponible = -1;
            for (int i = 0; i < contadorEmprendimientos; i++)
            {
                if (listaMarket[i].Estado == "Cancelado")
                {
                    indiceDisponible = i;
                    break; // Detenemos la búsqueda al encontrar el primer espacio libre
                }
            }

            // 2. Validación de cupo máximo (Solo si no hay cancelados y llegamos a 40)
            if (indiceDisponible == -1 && contadorEmprendimientos >= MAX_STANDS)
            {
                Console.WriteLine("Lo sentimos, ya no hay stands disponibles (Límite: " + MAX_STANDS + ").");
                Console.WriteLine("El emprendimiento pasará a la lista de espera.");
                Console.ReadKey();
                return;
            }

            Emprendimiento nuevo;

            // 3. Captura de datos
            Console.Write("Nombre del Emprendimiento: ");
            nuevo.NombreNegocio = Console.ReadLine()!;
            Console.Write("Nombre del Representante: ");
            nuevo.Representante = Console.ReadLine()!;
            Console.Write("Categoría (Comida, Ropa, Accesorios, Maquillaje, etc.): ");
            nuevo.Categoria = Console.ReadLine()!;
            Console.Write("Número de Teléfono: ");
            nuevo.Telefono = Console.ReadLine()!;

            // 4. Asignación de Stand dependiendo de si es nuevo o reutilizado
            if (indiceDisponible != -1)
            {
                // REUTILIZAR STAND CANCELADO
                nuevo.NumStand = listaMarket[indiceDisponible].NumStand; // Hereda el número del stand vacío
                nuevo.CodigoCredencial = "JAG-" + nuevo.NumStand.ToString("D3");
                nuevo.Estado = "Confirmado";

                listaMarket[indiceDisponible] = nuevo; // Sobrescribimos el arreglo en esa posición
                Console.WriteLine("\n¡Inscripción Exitosa (Stand Reasignado)!");
            }
            else
            {
                // CREAR NUEVO STAND AL FINAL
                nuevo.NumStand = contadorEmprendimientos + 1;
                nuevo.CodigoCredencial = "JAG-" + nuevo.NumStand.ToString("D3");
                nuevo.Estado = "Confirmado";

                listaMarket[contadorEmprendimientos] = nuevo;
                contadorEmprendimientos++; // Solo aumentamos el contador si es un stand totalmente nuevo
                Console.WriteLine("\n¡Inscripción Exitosa!");
            }

            Console.WriteLine($"Código Asignado: {nuevo.CodigoCredencial} | Stand: {nuevo.NumStand}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        static void MostrarInscritos()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE EMPRENDIMIENTOS INSCRITOS ---");

            if (contadorEmprendimientos == 0)
            {
                Console.WriteLine("No hay ningún emprendimiento registrado todavía.");
            }
            else
            {
                bool hayActivos = false; // Variable extra para saber si todos fueron cancelados

                for (int i = 0; i < contadorEmprendimientos; i++)
                {
                    // Solo mostramos los que NO están cancelados
                    if (listaMarket[i].Estado != "Cancelado")
                    {
                        Console.WriteLine($"[{listaMarket[i].CodigoCredencial}] - {listaMarket[i].NombreNegocio}");
                        Console.WriteLine($"    Resp: {listaMarket[i].Representante} | Cat: {listaMarket[i].Categoria}");
                        Console.WriteLine($"    Tel: {listaMarket[i].Telefono} | Stand: {listaMarket[i].NumStand} | Estado: {listaMarket[i].Estado}");
                        Console.WriteLine("------------------------------------------------");
                        hayActivos = true;
                    }
                }

                if (!hayActivos)
                {
                    Console.WriteLine("Actualmente no hay emprendimientos activos (todos están cancelados).");
                }
            }
            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }

        // Isabela programará aquí

        static void BuscarPorNombre()
        {
            Console.Clear();
            Console.Write("Ingrese el nombre del emprendimiento a buscar: ");
            string buscar = Console.ReadLine()!;
            bool encontrado = false;

            for (int i = 0; i < contadorEmprendimientos; i++)
            {
                if (listaMarket[i].NombreNegocio.ToLower() == buscar.ToLower())
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("✨ Emprendimiento encontrado ✨");
                    Console.WriteLine("========================================");
                    Console.WriteLine("Código del emprendimiento: " + listaMarket[i].CodigoCredencial);
                    Console.WriteLine("Stand asignado: " + listaMarket[i].NumStand);
                    Console.WriteLine("Representante: " + listaMarket[i].Representante);
                    Console.WriteLine("Categoría: " + listaMarket[i].Categoria);
                    Console.WriteLine("Número de teléfono: " + listaMarket[i].Telefono);
                    Console.WriteLine("----------------------------------------");

                    encontrado = true;
                    break;
                }
            }
            if (encontrado == false)
            {
                Console.WriteLine("El emprendimiento no se encuentra registrado.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Noraelena programará aquí

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
                    File.WriteAllText("datos_emprendimientos.txt", string.Empty);

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
}
