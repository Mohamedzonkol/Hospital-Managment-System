using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class TestPrice
    {
        public int Id { get; set; }
        public string TestCode { get; set; }
        public decimal Price { get; set; }
        public Lap Lap { get; set; }
        public Bill Bill { get; set; }
    }
}
