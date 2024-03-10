using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int DomAssBatteryCapacity = 20_000;
        private const int DomAssConversionCapacityIndex = 2000;

        public DomesticAssistant(string model)
            : base(model, DomAssBatteryCapacity, DomAssConversionCapacityIndex)
        {
        }
    }
}
