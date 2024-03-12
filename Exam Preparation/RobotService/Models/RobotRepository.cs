using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        public void AddNew(IRobot robot) => robots.Add(robot);

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models() => robots.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            //IRobot robot = robots.FirstOrDefault(s => s.GetType().Name == typeName);

            //if (robot != null)
            //{
            //    robots.Remove(robot);
            //    return true;
            //}

            //return false;

            return robots.Remove(robots.FirstOrDefault(r => r.GetType().Name ==  typeName));
        }
    }
}
