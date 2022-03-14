using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Car
    {
        
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime? DateOfAcquisition { get; set; }
        public int? RefId { get; set; }

    }
}
