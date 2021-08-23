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
    public class BikesController : ControllerBase
    {
        private static List<Bike> Bikes = new List<Bike>
        {
            new Bike("Gazelle", "Sport")
        };

        private readonly ILogger<BikesController> _logger;

        public BikesController(ILogger<BikesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Bike> Get() => Bikes;

        [HttpPost]
        public IEnumerable<Bike> Create(Bike car)
        {
            Bikes.Add(new Bike(car.Make, car.Model));
            return Bikes;
        }

        [HttpPut]
        public IEnumerable<Bike> Update(string id, Bike car)
        {
            var carToUpdate = Bikes.Find(c => c.Id == id);
            carToUpdate.Make = car.Make;
            carToUpdate.Model = car.Model;
            return Bikes;
        }

        [HttpDelete]
        public IEnumerable<Bike> Delete(string id)
        {
            var carToRemove = Bikes.Find(car => car.Id == id);
            Bikes.Remove(carToRemove);
            return Bikes;
        }
    }
}
