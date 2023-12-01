using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pantalla11
{
    internal class Program
    {
        
            static List<Almacen> almacenes = new List<Almacen>();

            static void Main()
            {
                int opcion;

                do
                {
                    MostrarMenuAgregarExtraerProductos();
                    opcion = ObtenerOpcion();

                    switch (opcion)
                    {
                        case 1:
                            IngresarProductoEnAlmacen();
                            break;
                        case 2:
                            ExtraerProductoDeAlmacen();
                            break;
                        case 3:
                            VerStockActual();
                            break;
                        case 4:
                            Console.WriteLine("Volviendo al Menú Principal");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                            break;
                    }

                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();

                } while (opcion != 4);
            }

            static void MostrarMenuAgregarExtraerProductos()
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("||  Agregar y Extraer Productos - Mi Tiendita   ||");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("|| 1. Ingresar Producto en Almacén              ||");
                Console.WriteLine("|| 2. Extraer Producto de Almacén               ||");
                Console.WriteLine("|| 3. Ver Stock Actual                          ||");
                Console.WriteLine("|| 4. Volver al Menú Principal                  ||");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Seleccione una opción:");
            }

            static int ObtenerOpcion()
            {
                int opcion;
                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
                return opcion;
            }

            static void IngresarProductoEnAlmacen()
            {
                Console.Clear();
                Console.WriteLine("===== Pantalla para Ingresar Producto en Almacén =====");
                Console.WriteLine("--------------------------------------------------");

                MostrarAlmacenes();

                Console.Write("\nIngrese el número del almacén: ");
                int indiceAlmacen;

                while (!int.TryParse(Console.ReadLine(), out indiceAlmacen) || indiceAlmacen < 1 || indiceAlmacen > almacenes.Count)
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }

                string nombreAlmacen = almacenes[indiceAlmacen - 1].Nombre;

                Console.Write("Ingrese el nombre del producto: ");
                string nombreProducto = Console.ReadLine();

                Console.Write("Ingrese la cantidad del producto: ");
                int cantidad;

                while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 1)
                {
                    Console.WriteLine("Por favor, ingresa una cantidad válida.");
                }

                almacenes[indiceAlmacen - 1].Productos.Add(new Producto { Nombre = nombreProducto, Cantidad = cantidad });

                Console.WriteLine($"\nConfirmación: Producto '{nombreProducto}' ingresado en el almacén '{nombreAlmacen}' exitosamente.");
            }

            static void ExtraerProductoDeAlmacen()
            {
                Console.Clear();
                Console.WriteLine("===== Pantalla para Extraer Producto de Almacén =====");
                Console.WriteLine("--------------------------------------------------");

                MostrarAlmacenes();

                Console.Write("\nIngrese el número del almacén: ");
                int indiceAlmacen;

                while (!int.TryParse(Console.ReadLine(), out indiceAlmacen) || indiceAlmacen < 1 || indiceAlmacen > almacenes.Count)
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }

                string nombreAlmacen = almacenes[indiceAlmacen - 1].Nombre;

                if (almacenes[indiceAlmacen - 1].Productos.Count == 0)
                {
                    Console.WriteLine("No hay productos en este almacén para extraer.");
                    return;
                }

                MostrarProductosEnAlmacen(indiceAlmacen - 1);

                Console.Write("\nIngrese el número del producto a extraer: ");
                int indiceProducto;

                while (!int.TryParse(Console.ReadLine(), out indiceProducto) || indiceProducto < 1 || indiceProducto > almacenes[indiceAlmacen - 1].Productos.Count)
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }

                string nombreProducto = almacenes[indiceAlmacen - 1].Productos[indiceProducto - 1].Nombre;
                int cantidadProducto = almacenes[indiceAlmacen - 1].Productos[indiceProducto - 1].Cantidad;

                Console.Write($"Ingrese la cantidad a extraer (máximo {cantidadProducto}): ");
                int cantidadExtraer;

                while (!int.TryParse(Console.ReadLine(), out cantidadExtraer) || cantidadExtraer < 1 || cantidadExtraer > cantidadProducto)
                {
                    Console.WriteLine($"Por favor, ingresa una cantidad válida (máximo {cantidadProducto}).");
                }

                almacenes[indiceAlmacen - 1].Productos[indiceProducto - 1].Cantidad -= cantidadExtraer;

                Console.WriteLine($"\nConfirmación: Se extrajeron {cantidadExtraer} unidades del producto '{nombreProducto}' del almacén '{nombreAlmacen}' exitosamente.");
            }

            static void VerStockActual()
            {
                Console.Clear();
                Console.WriteLine("===== Pantalla para Ver Stock Actual =====");
                Console.WriteLine("--------------------------------------------------");

                MostrarAlmacenes();

                Console.Write("\nIngrese el número del almacén: ");
                int indiceAlmacen;

                while (!int.TryParse(Console.ReadLine(), out indiceAlmacen) || indiceAlmacen < 1 || indiceAlmacen > almacenes.Count)
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }

                string nombreAlmacen = almacenes[indiceAlmacen - 1].Nombre;

                if (almacenes[indiceAlmacen - 1].Productos.Count == 0)
                {
                    Console.WriteLine("No hay productos en este almacén para mostrar.");
                    return;
                }

                MostrarProductosEnAlmacen(indiceAlmacen - 1);
            }

            static void MostrarAlmacenes()
            {
                Console.WriteLine("Almacenes Disponibles:");

                for (int i = 0; i < almacenes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {almacenes[i].Nombre}");
                }
            }

            static void MostrarProductosEnAlmacen(int indiceAlmacen)
            {
                Console.WriteLine($"Productos en el Almacén '{almacenes[indiceAlmacen].Nombre}':");

                for (int i = 0; i < almacenes[indiceAlmacen].Productos.Count; i++)
                {
                    Console.WriteLine($"- {i + 1}. {almacenes[indiceAlmacen].Productos[i].Nombre} - Cantidad: {almacenes[indiceAlmacen].Productos[i].Cantidad}");
                }
            }

    // Definición de la clase Almacen
    class Almacen
        {
            public string Nombre { get; set; }
            public List<Producto> Productos { get; } = new List<Producto>();
        }

        // Definición de la clase Producto
        class Producto
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
        }
    }

}
