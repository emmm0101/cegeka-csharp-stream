using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        // buy car
        [Route("{id}/buy/{carId}")]
        [HttpPut]
        public IActionResult buyCar(int id, int carId)
        {
            //check if car available
            Car car = CarService.Get(carId);
            if (car.RefId == null)
            {
                car.DateOfAcquisition = DateTime.Now;
                car.RefId = id;
                return Ok("car purchased");

            }
            return Ok("car not available");
        }

        // list customers with their bought vehicles, with pagiation and filter
        [HttpGet]
        public List<WrapperClass> GetCustomersAndCars([FromQuery] int page, int pageSize, string filter) // filter on brand field
        {
            // create list of custom objects that will contain every customer with its associated cars
            List<WrapperClass> wrappers = new List<WrapperClass>();
            
            // create car list and filter based on brand from query
            List<Car> cars = CarService.GetAll();
            if (filter != null)
            {
                cars = cars.FindAll(p => p.Brand == filter);
            }

            // create customers list
            List<Customer> customers = CustomerService.GetAll();
            foreach (Customer customer in customers)
            {
                List<Car> customerCars = cars.FindAll(p => p.RefId == customer.Id);
                if (customerCars.Count > 0)
                {
                    WrapperClass wrapper = new WrapperClass { Customer = customer, Cars = customerCars };
                    wrappers.Add(wrapper);
                }

            }

            // send as response the customers for the page and pageSize requested
            int count = wrappers.Count - (page - 1) * pageSize;
            if (pageSize != 0)
            {
                if (count >= 0)
                {
                    wrappers = wrappers.GetRange(pageSize * (page - 1), count > pageSize ? pageSize : count);
                }
            }

            return wrappers;
        }





    }
}
