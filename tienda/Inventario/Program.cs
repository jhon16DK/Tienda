using System;
using System.Collections.Generic;
using Inventario.Modelos;
using Inventario.Productos;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

  namespace Inventario.Productos

  {
      class program
      {
        //mision escribir un formatpo en json almacendando en este los datos de la app.
          static void Main(string[] args)
          {

          Tienda MiTiendita = new Tienda();

          //crear un archivo 
          //objeto path.

         var ruta = Path.Combine(@"C:\Users\War_Machine\Desktop\C#\tienda\Inventario", "almacenamiento.json");

          //objeto file.

          if( ! File.Exists(ruta)){
             File.Create(ruta);
          }
          else{
            Console.WriteLine("El archivo de almacenamiento ya existe.");
            //leer el contenido del archivo
           var contenido = File.ReadAllText(ruta);
           //deserializando el contenido del archivo a un objeto 
          MiTiendita = JsonConvert.DeserializeObject<Tienda>(contenido);

          }
        
          //operaciones asiconcronos y sincronos


         while(true)
         {

         ImprimirMenu();
         string respuesta = Console.ReadLine();
         
         switch(respuesta){
             case "1":
              
             Producto p = new Producto();

                        Console.WriteLine("Cod del producto: ");

                        p.Codigo = Console.ReadLine();

                        Console.WriteLine("Nombre del producto: ");
                        p.Nombre = Console.ReadLine();

                        Console.WriteLine("Precio del producto: ");
                        var respuestaPrecio = Console.ReadLine();
                        // Convertir de string a decimal
                        decimal nuevoprecio = Convert.ToDecimal(respuestaPrecio);
                        // Establecer precio del producto
                        p.EstablecerPrecio(nuevoprecio);
                        // Preguntar cantidad del producto a agregar
                        Console.WriteLine("Cantidad del producto: ");
                        p.Cantidad = Int32.Parse(Console.ReadLine());
            // int32.parce convierte un string a un int de 32 bts
            // agregar el producto al inventario 
              MiTiendita.Inventario.Add(p);
              break;
             case "2":
             //preguntar cual es el codigo del producto que va a vender
            Console.WriteLine("Digita el codigo del producto: ");
             var cod = Console.ReadLine();
              // preguntar las uniades a vender
            Console.WriteLine("Cuantas unidades queire vender del producto?: ");
             var unidades = Console.ReadLine();

             //revisar si hay existencias del producto
            var productoaVender = MiTiendita.Inventario.FirstOrDefault(p => p.Codigo == cod && p.Cantidad > 0);
             // si es null significa que no hay existencxia del producto 
             if( productoaVender == null)
             {
               Console.WriteLine("No hay Existencias");
               break;
            }
            //disminuir la cantidad de producto en el inventario  
              productoaVender.Cantidad -= Int32.Parse(unidades);
             //aumentar el valor en la caja
             MiTiendita.caja += productoaVender.Precio * Int32.Parse(unidades);
              break; 
               case "3":
               if(MiTiendita.Inventario.Count == 0){
                  Console.WriteLine(" No hay productos en el inventario");
               }
                foreach(Producto productoActual in MiTiendita.Inventario){
                     Console.WriteLine();
                     Console.WriteLine($"Nombre: {productoActual.Nombre}");
                     Console.WriteLine($"Precio: {productoActual.Precio} Pesos.");
                     Console.WriteLine($"Cantidad: {productoActual.Cantidad} unidades.");
                     Console.WriteLine();
                }
              break;
               case "4":
              Console.WriteLine($"Balance Actual de la tienda {MiTiendita.Nombre}: {MiTiendita.caja} Pesos.");
              break;
              case "5":
                   //guardar el contenido del objeto mitiendita en el archivo de almacenamiento  
                   //serializando un el contenido de un objeto a un string  
                 string Contenido = JsonConvert.SerializeObject(MiTiendita);
                 //guardando el string en el archivo
                 File.WriteAllText(ruta, Contenido);
                  Console.WriteLine("Guardado exitosamente.");
              break;
              case "6":
               Console.WriteLine("Nombra Tu Tienda:");
               MiTiendita.Nombre = Console.ReadLine();
              break;
              default:
              Console.WriteLine("No Seleccionaste una opcion valida");
              break;
         }

         }

          }
   
          static void ImprimirMenu()
          {
            Console.WriteLine("1. Agregar un Producto.");
            Console.WriteLine("2. Vender Producto.");
            Console.WriteLine("3. Mostrar Inventario");
            Console.WriteLine("4. Mostrar Caja.");
            Console.WriteLine("5. Guardar Cambios.");
            Console.WriteLine("6. Nombra Tu Tienda.");

          }
      }
  }