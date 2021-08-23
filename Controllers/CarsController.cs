using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vehicles.Api.Models;

namespace Vehicles.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private static List<Car> Cars = new List<Car>
        {
            new Car("Ford", "Taurus"),
            new Car("Ford", "Focus" ),
            new Car("Ford", "Fiesta")
        };

        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Car> Get() => Cars;

        [HttpPost]
        public IEnumerable<Car> Create(Car car)
        {
            Cars.Add(new Car(car.Make, car.Model));
            return Cars;
        }

        [HttpPut]
        public IEnumerable<Car> Update(string id, Car car)
        {
            var carToUpdate = Cars.Find(c => c.Id == id);
            carToUpdate.Make = car.Make;
            carToUpdate.Model = car.Model;
            return Cars;
        }

        [HttpDelete]
        public IEnumerable<Car> Delete(string id)
        {
            var carToRemove = Cars.Find(car => car.Id == id);
            Cars.Remove(carToRemove);
            return Cars;
        }
    }
}
