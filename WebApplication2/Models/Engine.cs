using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Engine
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public string Type { get; set; }
        public double Volume { get; set; }

        public virtual Car Car { get; set; }
    }
}
