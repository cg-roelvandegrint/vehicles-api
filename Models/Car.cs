using System;

namespace Vehicles.Api.Models
{
    public class Car
    {
        public string Id { get; }
        public string Make { get; set; }
        public string Model { get; set; }

        public Car(string make, string model)
        {
            Id = Guid.NewGuid().ToString();
            Make = make;
            Model = model;
        }
    }
}