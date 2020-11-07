using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class OwnerManufacturer
    {
        public int OwnerId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
