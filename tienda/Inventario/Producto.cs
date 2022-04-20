using System;
using Inventario.Productos;


namespace Inventario.Productos
{
    public class Producto
    {
         public string  Nombre { get; set; }

         public string  Codigo { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

    

         public void EstablecerPrecio(decimal _Precio)
         {
             Precio=_Precio;
         }
    }
  
    
}