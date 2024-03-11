using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int IndAssBatteryCapacity = 40_000;
        private const int IndAssConversionCapacityIndex = 5000;

        public IndustrialAssistant(string model)
            : base(model, IndAssBatteryCapacity, IndAssConversionCapacityIndex)
        {

        }
    }
}
