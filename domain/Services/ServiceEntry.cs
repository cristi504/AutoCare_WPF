    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.Services
{
    public class ServiceEntry
    {
        public int CarID { get; set; }
        public string Oil { get; set; }
        public string AirFilter { get; set; }
        public string FuelFilter { get; set; }
        public string OilFilter { get; set; }
        public string OtherInterventions { get; set; }
        public int Mileage { get; set; }
        public int Price { get; set; }
    }
}
