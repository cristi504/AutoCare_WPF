using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.Services
{
    public class ServiceInterval
    {
        public string Oil { get; set; }
        public string AirFilter { get; set; }
        public string FuelFilter { get; set; }
        public string OilFilter { get; set; }
        public string OtherInterventions { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }

        public ServiceInterval(string oil, string airFilter, string fuelFilter, string oilFilter, string otherInterventions, int mileage, decimal price)
        {
            Oil = oil;
            AirFilter = airFilter;
            FuelFilter = fuelFilter;
            OilFilter = oilFilter;
            OtherInterventions = otherInterventions;
            Mileage = mileage;
            Price = price;
        }
    }

}
