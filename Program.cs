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
                // Seguridad 1: Reiniciar el contador antes de leer para evitar duplicados
                contadorEmprendimientos = 0;

                using (StreamReader sr = new StreamReader("datos_emprendimientos.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()!) != null)
                    {
                        // Seguridad 2: Si el archivo tiene más registros que el tamaño del arreglo (MAX_STANDS = 100), frenamos el ciclo
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
