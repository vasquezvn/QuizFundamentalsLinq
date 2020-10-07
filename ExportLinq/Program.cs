using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ExportLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cars = GetCarsFromCsv(@"..\..\Resources\fuel.csv");

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbCars>());


            InsertData(cars);
            QueryData();



            //var manufacturers = GetManufacturerFromCsv(@"..\..\Resources\manufacturers.csv");

            // Crear una consulta para obtener el top ten autos que tenga la mejor eficiencia de combustible y tambien los que tengan menos eficiencia
            //var query = from car in cars
            //            orderby car.Combined descending, car.Name ascending
            //            select new {
            //                Name = car.Name,
            //                Combined = car.Combined
            //            };

            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Name, -20} : {car.Combined}");
            //}

            //var query2 = cars.OrderByDescending(c => c.Combined)
            //                 //.ThenBy(c => c.Name)
            //                 .Select(c => new
            //                 {
            //                     Name = c.Name,
            //                     Combined = c.Combined
            //                 }).Take(10);

            //Console.WriteLine("******");

            //foreach (var car in query2)
            //{
            //    Console.WriteLine($"{car.Name,-20} : {car.Combined}");
            //}


            // filtrar los autos por marca y por año
            //var query = from car in cars
            //            where car.Manufacturer is "BMW" && car.Year > 2015
            //            select new
            //            {
            //                Name = car.Name,
            //                Manufacturer = car.Manufacturer,
            //                Year = car.Year
            //            };

            //foreach (var car in query)
            //{
            //    Console.WriteLine($"{car.Name,-20} {car.Manufacturer} : {car.Year}");
            //}

            //Console.WriteLine("************");

            //var query2 = cars.Where(c => c.Manufacturer == "BMW" && c.Year > 2015)
            //                 .Select(c => c);

            //foreach (var car in query2)
            //{
            //    Console.WriteLine($"{car.Name,-20} {car.Manufacturer} : {car.Year}");
            //}

            //// verificar que una consulta tiene datos

            //if (query.Any())
            //{
            //    Console.WriteLine("Collection have data");
            //}


            // LISTAR LOS 10 VEHICULOS MAS EFICIENTES Y QUE MUESTRE LA LOCALIZACION POR CADA MARCA
            //var query1 = from car in cars
            //             join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
            //             orderby car.Combined descending
            //             select new
            //             {
            //                 Name = car.Name,
            //                 Headquarters = manufacturer.Headquarters,
            //                 Manufacturer = car.Manufacturer,
            //             };

            //foreach (var car in query1.Take(10))
            //{
            //    Console.WriteLine($"{car.Name} - {car.Manufacturer} : {car.Headquarters}");
            //}

            //var query2 = cars.Join(manufacturers,
            //                      c => c.Manufacturer,
            //                      m => m.Name,
            //                      (c, m) => new
            //                      {
            //                          Name = c.Name,
            //                          Headquarter = m.Headquarters,
            //                          Combined = c.Combined
            //                      })
            //                 .OrderByDescending(c => c.Combined)
            //                 .ThenBy(c => c.Name);

            //foreach (var car in query2.Take(10))
            //{
            //    Console.WriteLine($"{car.Name} : {car.Headquarter} {car.Combined}");
            //}


            // UNIR DOS LISTAS POR MAS DE UN ATRIBUTO Y CREAR UN OBJETO NUEVO CON ATRIBUTOS DE AMBAS LISTAS
            //var query = from car in cars
            //            join manufacturer in manufacturers
            //                on new { car.Manufacturer, car.Year } equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
            //            orderby car.Combined descending, car.Name
            //            select new 
            //            { 
            //                Name = car.Name,
            //                Combined = car.Combined,
            //                Headquarters = manufacturer.Headquarters
            //            };

            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Name} {car.Headquarters} : {car.Combined}");
            //}

            //var query2 = cars.Join(manufacturers,
            //                      c => new { c.Manufacturer, c.Year },
            //                      m => new { Manufacturer = m.Name, m.Year },
            //                      (c, m) => new
            //                      {
            //                          Name = c.Name,
            //                          Headquarter = m.Headquarters,
            //                          Combined = c.Combined
            //                      })
            //                 .OrderByDescending(c => c.Combined)
            //                 .ThenBy(c => c.Name);

            //foreach (var car in query2.Take(10))
            //{
            //    Console.WriteLine($"{car.Name} {car.Headquarter} : {car.Combined}");
            //}

            // AGRUPAR POR MARCA Y MOSTRAR EL TOTAL DE AUTOS POR MARCA
            //var query = from car in cars
            //            group car by car.Manufacturer.ToUpper() into groupCar
            //            select new
            //            {
            //                Manufacturer = groupCar.Key,
            //                numberCar = groupCar.Count(),
            //            };

            //foreach (var car in query.OrderByDescending(c => c.numberCar))
            //{
            //    Console.WriteLine($"{car.Manufacturer} : {car.numberCar}");
            //}

            //var query2 = cars.GroupBy(c => c.Manufacturer.ToUpper())
            //                 .Select(c => new 
            //                 { 
            //                     Manufacturer = c.Key,
            //                     numberCars = c.Count()
            //                 });

            //foreach (var groupCar in query2.OrderByDescending(g => g.numberCars))
            //{
            //    Console.WriteLine($"{groupCar.Manufacturer} : {groupCar.numberCars}");
            //}


            // AGRUPAR POR MARCA Y OBTENER LOS DOS AUTOS CON MEJOR RENDIMIENTO POR MARCA
            //var query = from car in cars
            //            group car by car.Manufacturer.ToUpper() into groupCar
            //            orderby groupCar.Key
            //            select groupCar;


            //foreach (var group in query)
            //{
            //    Console.WriteLine($"{group.Key}");

            //    foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
            //    {
            //        Console.WriteLine($"\t{car.Name} : {car.Combined}");
            //    }
            //}


            //var query2 = cars.GroupBy(c => c.Manufacturer.ToUpper())
            //                 .OrderBy(c => c.Key);

            //foreach (var group in query2)
            //{
            //    Console.WriteLine($"{group.Key}");

            //    foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
            //    {
            //        Console.WriteLine($"\t{car.Name} : {car.Combined}");
            //    }
            //}

            // OBTENER LOS DOS VEHICULOS MAS EFICIENTES POR MARCA Y EL PAIS DE PROCEDENCIA
            //var query = from manufacture in manufacturers
            //            join car in cars on manufacture.Name equals car.Manufacturer into groupCar
            //            select new
            //            {
            //                Manufacturer = manufacture,
            //                car = groupCar
            //            };

            //foreach (var group in query)
            //{
            //    Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");

            //    foreach (var car in group.car.OrderByDescending(c => c.Combined).Take(2))
            //    {
            //        Console.WriteLine($"\t{car.Name} - {car.Combined}");
            //    }
            //}

            //var query2 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, 
            //                                    (m, c) => 
            //                                        new 
            //                                        { 
            //                                            Manufacturer = m,
            //                                            groupCar = c,
            //                                        });

            //foreach (var group in query2)
            //{
            //    Console.WriteLine($"{group.Manufacturer.Name} - {group.Manufacturer.Headquarters}");

            //    foreach (var car in group.groupCar.OrderByDescending(c => c.Combined).Take(2))
            //    {
            //        Console.WriteLine($"\t{car.Name} - {car.Combined}");
            //    }
            //}


            // OBTENER LOS 3 VEHICULOS MAS EFICIENTES POR PAIS

            //var query = from manufacturer in manufacturers
            //            join car in cars on manufacturer.Name equals car.Manufacturer into groupManufacturer
            //            select new
            //            {
            //                Manufacturer = manufacturer,
            //                groupCar = groupManufacturer
            //            } into result
            //            group result by result.Manufacturer.Headquarters;

            //foreach (var group in query)
            //{
            //    Console.WriteLine($"{group.Key}");

            //    foreach (var car in group.SelectMany(g => g.groupCar)
            //                             .OrderByDescending(c => c.Combined)
            //                             .Take(3))
            //    {
            //        Console.WriteLine($"\t{car.Name} - {car.Combined}");
            //    }
            //}

            //var query2 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
            //                                (m, c) => new
            //                                {
            //                                    Manufacturer = m,
            //                                    groupCar = c
            //                                })
            //                          .GroupBy(g => g.Manufacturer.Headquarters);

            //foreach (var group in query2)
            //{
            //    Console.WriteLine($"{group.Key}");

            //    foreach (var car in group.SelectMany(g => g.groupCar)
            //                             .OrderByDescending(c => c.Combined)
            //                             .Take(3))
            //    {
            //        Console.WriteLine($"\t{car.Name} - {car.Combined}");
            //    }
            //}


            // OBTENER EL RENDIMIENTO MIN, MAX, AVG POR CADA MARCA DE AUTO
            //var query = from car in cars
            //            group car by car.Manufacturer.ToUpper() into groupCar
            //            orderby groupCar.Key
            //            select new
            //            {
            //                Name = groupCar.Key,
            //                Min = groupCar.Min(c => c.Combined),
            //                Max = groupCar.Max(c => c.Combined),
            //                Avg = groupCar.Average(c => c.Combined)
            //            };

            //foreach (var group in query)
            //{
            //    Console.WriteLine($"{group.Name}");
            //    Console.WriteLine($"\tMax: {group.Max}");
            //    Console.WriteLine($"\tMin: {group.Min}");
            //    Console.WriteLine($"\tAvg: {group.Avg}");
            //}

            //var query2 = cars.GroupBy(c => c.Manufacturer)
            //                 .OrderBy(c => c.Key)
            //                 .Select(g => new 
            //                 { 
            //                    Name = g.Key,
            //                    Max = g.Max(c => c.Combined),
            //                    Min = g.Min(c => c.Combined),
            //                    Avg = g.Average(c => c.Combined)
            //                 });

            //foreach (var group in query2)
            //{
            //    Console.WriteLine($"{group.Name}");
            //    Console.WriteLine($"\tMax: {group.Max}");
            //    Console.WriteLine($"\tMin: {group.Min}");
            //    Console.WriteLine($"\tAvg: {group.Avg}");
            //}

            //var query3 = cars.GroupBy(c => c.Manufacturer)
            //                 .Select(g => 
            //                 {
            //                     var result = g.Aggregate(new CarStatistics(), (acc, c) => acc.Accumulate(c), acc => acc.Accumulate());

            //                     return new
            //                     {
            //                         Name = g.Key,
            //                         Max = result.Max,
            //                         Min = result.Min,
            //                         Avg = result.Average
            //                     };

            //                 });

            //foreach (var group in query3)
            //{
            //    Console.WriteLine($"{group.Name}");
            //    Console.WriteLine($"\tMax: {group.Max}");
            //    Console.WriteLine($"\tMin: {group.Min}");
            //    Console.WriteLine($"\tAvg: {group.Avg}");
            //}


            // CREAR UN ARCHIVO XML QUE ALMACENE LOS ATRIBUTOS DE LA CLASE CAR
            //SaveXml(cars);
            //QueryXml();
        }

        private static void QueryData()
        {
            var myDB = new MyDbCars();

            myDB.Database.Log = Console.WriteLine;

            //var query = from car in myDB.MyTableCars
            //            where car.Manufacturer == "BMW"
            //            orderby car.Combined descending
            //            select car;

            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Manufacturer} : {car.Name} - {car.Combined}");
            //}

            var query2 = from car in myDB.MyTableCars
                         group car by car.Manufacturer into groupCar
                         select groupCar;

            foreach (var group in query2)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} - {car.Combined}");
                }
            }

        }

        private static void InsertData(List<Car> cars)
        {
            var myDB = new MyDbCars();

            if (!myDB.MyTableCars.Any())
            {
                foreach (var car in cars)
                {
                    myDB.MyTableCars.Add(car);
                }
            }

            myDB.SaveChanges();
        }

        private static void QueryXml()
        {
            var ns = (XNamespace)"http://www.testlinq.com/quiz";
            var ex = (XNamespace)"http://www.testlinq.com/quiz/ex";

            var query = from element in XDocument.Load("fuel.xml").Element(ns + "Cars").Elements(ex + "Car")
                        where element.Attribute("Manufaturer").Value == "BMW"
                        orderby element.Attribute("Name").Value
                        select element.Attribute("Name").Value;

            foreach (var element in query)
            {
                Console.WriteLine($"{element}");
            }
        }

        private static void SaveXml(List<Car> cars)
        {
            var xdoc = new XDocument();
            var ns = (XNamespace)"http://www.testlinq.com/quiz";
            var ex = (XNamespace)"http://www.testlinq.com/quiz/ex";

            var xelement = new XElement(ns + "Cars", from element in cars
                                                select new XElement(ex + "Car",
                                                    new XAttribute("Name", element.Name),
                                                    new XAttribute("Combined", element.Combined),
                                                    new XAttribute("Manufaturer", element.Manufacturer)
                                                ));

            xelement.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));

            xdoc.Add(xelement);
            xdoc.Save("fuel.xml");
        }

        private static List<Manufacturer> GetManufacturerFromCsv(string path)
        {
            var manufacturer = from line in File.ReadAllLines(path)
                               where line.Length > 1
                               select CreateManufacturer(line);

            return manufacturer.ToList();
        }

        private static Manufacturer CreateManufacturer(string line)
        {
            var columns = line.Split(',');
            return new Manufacturer
            {
                Name = columns[0],
                Headquarters = columns[1],
                Year = Int32.Parse(columns[2])
            };
        }

        private static List<Car> GetCarsFromCsv(string path)
        {
            var cars = File.ReadAllLines(path)
                           .Skip(1)
                           .Where(l => l.Length > 1)
                           .Select(l =>
                           {
                               var columns = l.Split(',');
                               return new Car
                               {
                                   Year = Int32.Parse(columns[0]),
                                   Manufacturer = columns[1],
                                   Name = columns[2],
                                   Displacement = Double.Parse(columns[3]),
                                   Cylinders = Int32.Parse(columns[4]),
                                   City = Int32.Parse(columns[5]),
                                   Highway = Int32.Parse(columns[6]),
                                   Combined = Int32.Parse(columns[7])
                               };
                           });

            var cars2 = from line in File.ReadAllLines(path).Skip(1)
                        where line.Length > 1
                        select ProcessLinesIntoCars(line);



            return cars2.ToList();
        }

        private static Car ProcessLinesIntoCars(string line)
        {
            var columns = line.Split(',');

            return new Car
            {
                Year = Int32.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = Double.Parse(columns[3]),
                Cylinders = Int32.Parse(columns[4]),
                City = Int32.Parse(columns[5]),
                Highway = Int32.Parse(columns[6]),
                Combined = Int32.Parse(columns[7])
            };
        }
    }

    class CarStatistics
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Average { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }

        public CarStatistics()
        {
            Min = Int32.MaxValue;
            Max = Int32.MinValue;
        }

        public CarStatistics Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Min = Math.Min(Min, car.Combined);
            Max = Math.Max(Max, car.Combined);

            return this;
        }

        internal CarStatistics Accumulate()
        {
            Average = Total / Count;

            return this;
        }
    }
}
