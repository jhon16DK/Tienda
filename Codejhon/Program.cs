using System;
   
    //programacion orientada a objetos 
//atributos de un objeto

//para modelar un objeto usamos una clase 
//una clase es un contenedor para atributos y funciones (propiedades y metodos(miembros))
//cada uno de los miembros tiene un "modificador de acceso" (public, private)

public abstract class animal 
   {
       
       public animal(int NumExtremidades, string nombreCientifico, string nombreComun, string color)
         {
          Color = color;
          NumerodeExtremidades = NumExtremidades;
          NombreComun = nombreComun;
          NombreCientifico = nombreCientifico;
         }
       // Propiedades
       public string Color { get; set; }
       public int NumerodeExtremidades { get; set; } 
       public float AlturaenCentimetros { get; set; }
       public float PesoenKilogramos { get; set; }
       public abstract string NombreComun { get; set; }
        string NombreCientifico { get; set; }

        //Metodos
         public void ImprimirDatos()
        {
          Console.WriteLine($"Nombre Comun: {NombreComun}");
           Console.WriteLine($"Peso en Kilogramos: {PesoenKilogramos}");
           Console.WriteLine($"Color: {color}");
           Console.WriteLine($"Numero De Exctremidades: {NumerodeExtremidades}");
        }


        public void Imprimirnombrecomun()
        {
          Console.WriteLine($"Nombre Comun, {NombreComun}");
        }
        public void Imprimirnombrecientifico()
        {

        }
        public void Comer()
        {
           Console.WriteLine("comiendo");
        }
        public abstract void HacerSonido();

         public void poop()
       {
           Console.WriteLine("pooping");
       }
       
   }

public class perro : animal

{
    public perro (int NumExtremidades, string nombreCientifico, string nombreComun, string color) : base (NumerodeExtremidades, NombreCientifico, NombreComun, Color);
           
   public override string NombreComun { get; set; }= "perro";
    public override void HacerSonido()
    {
         Console.WriteLine("wouft");
    }
}
public class gato : animal
{
        public gato (int NumExtremidades, string nombreCientifico, string nombreComun, string color) : base (NumExtremidades, nombreCientifico, nombreComun, Color);

    public override string NombreComun { get; set; } = "gato";
    public override void HacerSonido()
    {
         Console.WriteLine("miau");
    }
}
public class pato : animal
{
        public pato(int NumExtremidades, string nombreCientifico, string nombreComun, string color) : base (NumExtremidades, nombreCientifico, nombreComun, Color);

    public override string NombreComun { get; set; } = "pato";
    public override void HacerSonido()
    {
         Console.WriteLine("quack");
    }
}
 public class program
    {
        public static void Main(string[] args){

            perro darius = new perro(4, "perro", "canis familiaris", "rojo");
            gato garen = new gato ();
            pato lucas = new pato();

            darius.ImprimirDatos();
            
        }
    }
  
       
           
   

   


    