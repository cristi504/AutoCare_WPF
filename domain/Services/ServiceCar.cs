using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.Services
{
    internal class ServiceCar
    {
        public int CarID { get; set; }
        public string Brand { get; set; }

        public ServiceCar(int carID, string brand)
        {
            CarID = carID;
            Brand = brand;
        }
    }
}
