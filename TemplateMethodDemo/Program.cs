using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using TemplateMethodDemo.Models;

namespace TemplateMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            var cadenadeconexion = config.GetConnectionString("MySQLDev");
            var catalogo = new List<string>();
            var categorias = new Categorias(cadenadeconexion);
            var productos = new Productos(cadenadeconexion);

            catalogo = categorias.Ejecutar();
            Console.WriteLine("");
            foreach(var item in catalogo)
            {
                Console.WriteLine(item);
            }

            catalogo = productos.Ejecutar();
            Console.WriteLine("");
            foreach (var item in catalogo)
            {
                Console.WriteLine(item);
            }

        }
    }
}
