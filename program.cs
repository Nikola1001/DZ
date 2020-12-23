using System;
using System.IO;
using System.Xml.Serialization;
 // Var C13
namespace Serialization
{


  [Serializable]
public class Engine
  {
      public string name { get; set; }
      public int number { get; set; }
      public bool type_petrol { get; set; }
      public Engine(){;}
      public Engine(string n, int num, bool typ){
          name = n;
          number = num;
          type_petrol = typ;
      }    
        
      
      
  }
    [Serializable]
  public class Cab{

      public string name { get; set; }
      public int number { get; set; }
      public string type { get; set; }
public Cab(){;}
      public Cab(string n, int num,  string typ){
          name = n;
          number = num;
          type = typ;
      }    
      
   
      
      
      
  }
    
  [Serializable]
  public class Tractor{

    public string name { get; set; }
    public int number { get; set; }
    public Engine engine { get; set; }
    public Cab cab { get; set; }

    public Tractor (){}
    public Tractor (string n, int num, Engine en, Cab c){
      name = n;
      number = num;
      engine = en;
      cab = c;
    }

  }
  
  class Program
    {
        
        static void Main(string[] args)
        {
            
            Tractor tractor = new Tractor("tractorok", 34, new Engine("dvigatel", 89, true), new Cab("cabinka", 3, "standart"));
            Console.WriteLine("Объект создан");
          
 
            XmlSerializer formatter = new XmlSerializer(typeof(Tractor));
 
            using (FileStream fs = new FileStream("tractor.xml", FileMode.OpenOrCreate))
            {
               formatter.Serialize(fs, tractor);
            }
 
            using (FileStream fs = new FileStream("tractor.xml", FileMode.OpenOrCreate))
            {
                Tractor newtractor = (Tractor)formatter.Deserialize(fs);
 
                
                    Console.WriteLine($"name: {newtractor.name} --- number: {newtractor.number} --- engine: {newtractor.engine.name} --- cab: {newtractor.cab.name}");
                
            }
            Console.ReadKey();
        }
    }
}
