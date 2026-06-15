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
        // static void GuardarDatos() { ... }
        // static void CargarDatos() { ... }
    }
}
