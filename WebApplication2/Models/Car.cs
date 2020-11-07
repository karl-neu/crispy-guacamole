using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int ManufacturerId { get; set; }
        public int EngineId { get; set; }

        public virtual Engine Engine { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
