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
        const int MAX_STANDS = 100;
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
                Console.WriteLine("1. Registrar Emprendimiento (Inscripción)");
                Console.WriteLine("2. Mostrar Todos los Emprendimientos Inscritos");
                Console.WriteLine("3. Buscar Emprendimiento por Nombre");
                Console.WriteLine("4. Guardar Información en Archivo");
                Console.WriteLine("5. Salir del Sistema");
                Console.WriteLine("==================================================");
                Console.Write("Seleccione una opción: ");
                
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: RegistrarEmprendimiento(); break;
                        case 2: MostrarInscritos(); break;
                        case 3: BuscarPorNombre(); break;
                        case 4: 
                            GuardarDatos();
                            Console.WriteLine("Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                        case 5: 
                            // Guardado automático al salir
                            GuardarDatos();
                            Console.WriteLine("¡Éxito en el Jaguar Market! Saliendo..."); 
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
            } while (opcion != 5);
        }

        // Evan programará aquí
        
        static void RegistrarEmprendimiento()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRAR NUEVO EMPRENDIMIENTO ---");

            // Validación de cupo máximo
            if (contadorEmprendimientos >= MAX_STANDS)
            {
                Console.WriteLine("Lo sentimos, ya no hay stands disponibles (Límite: " + MAX_STANDS + ").");
                Console.WriteLine("El emprendimiento pasará a la lista de espera.");
                Console.ReadKey();
                return;
            }

            Emprendimiento nuevo;
            
            // Captura de datos
            Console.Write("Nombre del Emprendimiento: ");
            nuevo.NombreNegocio = Console.ReadLine()!;
            Console.Write("Nombre del Representante: ");
            nuevo.Representante = Console.ReadLine()!;
            Console.Write("Categoría (Comida, Ropa, Accesorios, Tecnología): ");
            nuevo.Categoria = Console.ReadLine()!;
            Console.Write("Número de Teléfono: ");
            nuevo.Telefono = Console.ReadLine()!;
            
            // Lógica automatizada propuesta
            nuevo.NumStand = contadorEmprendimientos + 1; // Asigna el siguiente stand libre
            nuevo.CodigoCredencial = "JAG-" + nuevo.NumStand.ToString("D3"); // Ejemplo: JAG-001
            nuevo.Estado = "Confirmado";

            // Guardar en el arreglo
            listaMarket[contadorEmprendimientos] = nuevo;
            contadorEmprendimientos++;

            Console.WriteLine("\n¡Inscripción Exitosa!");
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
                for (int i = 0; i < contadorEmprendimientos; i++)
                {
                    Console.WriteLine($"[{listaMarket[i].CodigoCredencial}] - {listaMarket[i].NombreNegocio}");
                    Console.WriteLine($"    Resp: {listaMarket[i].Representante} | Cat: {listaMarket[i].Categoria}");
                    Console.WriteLine($"    Tel: {listaMarket[i].Telefono} | Stand: {listaMarket[i].NumStand} | Estado: {listaMarket[i].Estado}");
                    Console.WriteLine("------------------------------------------------");
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
            try 
            {
                using (StreamWriter sw = new StreamWriter("jaguarmarket.txt"))
                {
                    for (int i = 0; i < contadorEmprendimientos; i++)
                    {
                        Emprendimiento emp = listaMarket[i];
                        sw.WriteLine($"{emp.CodigoCredencial}|{emp.NombreNegocio}|{emp.Representante}|{emp.Categoria}|{emp.Telefono}|{emp.NumStand}|{emp.Estado}");
                    }
                }
                Console.WriteLine("Datos guardados en el disco duro exitosamente.");
            }
            catch (Exception) 
            {
                Console.WriteLine("No se pudo guardar la información en el archivo.");
            }
        }

        static void CargarDatos()
        {
            if (File.Exists("jaguarmarket.txt"))
            {
                // Reiniciar el contador antes de leer para evitar duplicados
                contadorEmprendimientos = 0; 

                using (StreamReader sr = new StreamReader("jaguarmarket.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()!) != null)
                    {
                        // Si el archivo tiene más registros que el tamaño del arreglo (MAX_STANDS = 50), frenamos el ciclo
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
    }
}
