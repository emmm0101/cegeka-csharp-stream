using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CarService
    {
        static List<Car> Cars { get; }
        static CarService()
        {
            Cars = new List<Car>
        {
            new Car { Id = 1, Model = "Bravo", Brand = "Fiat", DateOfAcquisition = DateTime.Now, RefId = 1},
            new Car { Id = 2, Model = "Astra", Brand = "Opel", DateOfAcquisition = DateTime.Now, RefId = 1 },
            new Car { Id = 3, Model = "508", Brand = "Peugeot", DateOfAcquisition = null, RefId = null},
            new Car { Id = 4, Model = "Passat", Brand = "Volkswagen", DateOfAcquisition = DateTime.Now.AddDays(-2), RefId = 3 },
            new Car { Id = 5, Model = "Golf", Brand = "Volkswagen", DateOfAcquisition = null, RefId = null },
            new Car { Id = 6, Model = "Passat", Brand = "Volkswagen", DateOfAcquisition = DateTime.Now.AddDays(-2), RefId = 4 },
            new Car { Id = 7, Model = "Tiguan", Brand = "Volkswagen", DateOfAcquisition = DateTime.Now.AddDays(-2), RefId = 2 },
            new Car { Id = 8, Model = "Passat", Brand = "Volkswagen", DateOfAcquisition = DateTime.Now.AddDays(-2), RefId = 2 },
            new Car { Id = 9, Model = "Passat", Brand = "Volkswagen", DateOfAcquisition = null, RefId = null }


        };
        }
        public static List<Car> GetAll() => Cars;

        public static Car? Get(int id) => Cars.FirstOrDefault(p => p.Id == id);

        public static List<Car> GetCarsByRef(int refId) => Cars.FindAll(p => p.RefId == refId);

        public static void Add(Car Car)
        {
            Cars.Add(Car);
        }

        public static void Delete(int id)
        {
            var Car = Get(id);
            if (Car is null)
                return;

            Cars.Remove(Car);
        }

        public static void Update(Car Car)
        {
            var index = Cars.FindIndex(p => p.Id == Car.Id);
            if (index == -1)
                return;

            Cars[index] = Car;
        }
    }
}
