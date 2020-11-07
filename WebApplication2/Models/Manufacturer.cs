using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Car = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Headquarters { get; set; }

        public virtual ICollection<Car> Car { get; set; }
    }
}
