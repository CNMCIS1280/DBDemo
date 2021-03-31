using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Location { get; set; }
        public double Weight { get; set; }
        public decimal Cost { get; set; }
        public string Remarks { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} Located at {Location}";
        }
    }
}
