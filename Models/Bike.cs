using System;

namespace Vehicles.Api.Models
{
    public class Bike
    {
        public string Id { get; }
        public string Make { get; set; }
        public string Model { get; set; }

        public Bike(string make, string model)
        {
            Id = Guid.NewGuid().ToString();
            Make = make;
            Model = model;
        }
    }
}