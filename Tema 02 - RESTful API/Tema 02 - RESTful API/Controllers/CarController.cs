using Microsoft.AspNetCore.Mvc;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        // get all
        [HttpGet]
        public List<Car> Get() => CarService.GetAll();

        // get available cars
        [HttpGet]
        [Route("available")]
        public List<Car> GetAvailable() => CarService.GetAll().FindAll(p => p.RefId == null);

        // post
        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            CarService.Add(car);
            return Ok("created");
        }
        
        // put - updates all the properties, body must contain all the props specific to car
        // todo : update the properties given in the req body
        [HttpPut("{id}")]
        public IActionResult UpdateCar(Car car)
        {
            CarService.Update(car);
            return Ok("updated");
        }

        // delete 
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            CarService.Delete(id);
            return Ok("deleted");

        }


    }
}
