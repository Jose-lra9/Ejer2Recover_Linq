using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice_SecondTry
{
    public class Program
    {
        static List<Cars> listaCoche = new List<Cars>();
        static void Main(string[] args)
        {
            
        }

        static List<Cars> Ejer1()
        {
            using (StreamReader lector = new StreamReader("Cars.json"))
            {
                string json = lector.ReadToEnd();
                List<Cars> listaCoche = JsonConvert.DeserializeObject<List<Cars>>(json);
                return listaCoche;
            }
        }

        static void Ejer2()
        {
            var fabricantes = listaCoche.GroupBy(x => x.Maker).Select(y => y.First());
            foreach (var item in fabricantes)
            {
                Console.WriteLine($"Fabricante: { item.Maker}");
            }
        }

        static void Ejer3()
        {
            var colores = listaCoche.GroupBy(x => x.Color).Select(y => y.First());
            foreach (var item in colores)
            {
                Console.WriteLine($"Fabricante: {item.Maker}, Modelo{item.Model}, Color{item.Color}");
            }
        }

        static void Ejer4()
        {
            var colorverde = listaCoche.Where(x => x.Color == "Green");

            foreach (var item in colorverde)
            {
                Console.WriteLine($"Fabricante: {item.Maker}, Modelo{item.Model}, Color{item.Color}");
            }
        }

        static void Ejer6()
        {
            var cochessup2001 = listaCoche.Where(x => x.Year > 2001);

            foreach (var item in cochessup2001)
            {
                Console.WriteLine($"Los coches más nuevos al año 2001 son: Fabricante: {item.Maker}, Modelo: {item.Model}, Año: {item.Year}");
            }

        }

        static void Ejer8()
        {
            var cocheazulsup2000 = listaCoche.Where(x => x.Color == "Blue" && x.Year<2000);

            foreach (var item in cocheazulsup2000)
            {
                Console.WriteLine($"Los coches azules y más nuevos al año 2000 son: Fabricante: {item.Maker}, Modelo{item.Model}, Año: {item.Year}, Color{item.Year}");
            }
        }

        static void Ejer9()
        {
            var groupbyyearmaker = listaCoche.OrderBy(x => x.Year).GroupBy(x => x.Maker);
            
            foreach (var i in groupbyyearmaker)
            {
                Console.WriteLine(i.Key);
            }

        }



        static void Ejer10()
        {
            var groupbymodel = listaCoche.GroupBy(x => x.Model).Select(y => y.First());
            foreach (var item in groupbymodel)
            {
                Console.WriteLine($"Fabricante: {item.Maker},Color: {item.Color}");
            }

        }

        static void Ejer11()
        {
           
            for (int i = 0; i < listaCoche.Count; i += 10)
            {
                var salto10en10 = listaCoche.Skip(0 + i).Take(10);
                foreach (var item in salto10en10)
                {
                    Console.WriteLine($"Fabricante{item.Maker}, Modelo{item.Model}");
                }
                Console.ReadKey();

            }
        }

        static void Ejer12()
        {
            var primersuzuki2001 = listaCoche.Where(x => x.Maker == "Suzuki" && x.Year < 2001).Take(1);
            foreach (var item in primersuzuki2001)
            {
                Console.WriteLine(item);
            }
        }

        static void Ejer13()
        {
            var añoguardado = listaCoche.Where(x => x.Year != null);

            foreach (var item in añoguardado)
            {
                Console.WriteLine(item);
            }
        }

        static void Ejer14()
        {
            var añocolorrosa = listaCoche.Where(x => x.Color == "Pink").GroupBy(y => y.Year);
            foreach (var i in añocolorrosa)
            {
                Console.WriteLine(i);
            }

        }

        static void Ejer15()
        {
            var cochebmw = listaCoche.Where(x => x.Maker == "BMW" && x.Year == 0 && x.Location.Latitude == null && x.Location.Longitude == null);

            foreach (var item in cochebmw)
            {
                Console.WriteLine($"Fabricante: {item.Maker},Año: {item.Year},Longitud:{item.Location.Longitude}, Latitud: {item.Location.Latitude}");
            }
        }
    }
}

