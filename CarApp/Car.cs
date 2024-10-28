using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp
{
    public class Car
    {
        public string RegNumber { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string OwnerAddress { get; set; }

        public override string ToString()
        {
            return $"{RegNumber}; {Brand}; {Color}; {Year}; {OwnerAddress}";
        }
    }


}
