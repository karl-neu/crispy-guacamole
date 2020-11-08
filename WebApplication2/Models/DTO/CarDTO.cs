using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Engine Engine { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
