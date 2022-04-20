using System;
using System.Collections.Generic;
using Inventario.Productos;


namespace Inventario.Modelos
{
    public class Tienda
    {
        public string Nombre { get; set; }

        public decimal caja { get; set; }

        public List<Producto> Inventario { get; set; } = new List<Producto>();
    }
}