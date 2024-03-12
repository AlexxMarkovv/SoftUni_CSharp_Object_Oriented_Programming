using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int SpecializedInterfaceStandard = 10045;
        private const int SpecializedBatteryUsage = 10_000;

        public SpecializedArm() 
            : base(SpecializedInterfaceStandard, SpecializedBatteryUsage)
        {
        }
    }
}
