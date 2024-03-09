using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(LaserRadar) && typeName != nameof(SpecializedArm))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement;

            if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                supplement = new SpecializedArm();
            }

            supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements
                .Models()
                .FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            int interfaceValue = supplement.InterfaceStandard;

            IRobot robotForUpgrading = robots.Models()
                .FirstOrDefault(r => !r.InterfaceStandards.Contains(interfaceValue) && r.Model == model);

            if (robotForUpgrading == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robotForUpgrading.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> robotsForService = robots.Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel);

            if (!robotsForService.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int batteriesLevelSum = robotsForService.Sum(r => r.BatteryLevel);

            if (batteriesLevelSum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - batteriesLevelSum);
            }

            int usedRobotsCount = 0;
            foreach (var robot in robotsForService)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    usedRobotsCount++;
                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(robot.BatteryLevel);
                usedRobotsCount++;
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobotsCount);
        }

        public string RobotRecovery(string model, int minutes)
        {
            int fedCount = 0;

            foreach (var robot in robots.Models().Where(r => r.Model == model))
            {
                decimal percentage = Math.Round(robot.BatteryLevel / robot.BatteryCapacity * 100m,
                    MidpointRounding.AwayFromZero);

                if (percentage < 50)
                {
                    robot.Eating(minutes);
                    fedCount++;
                }
            }

            return string.Format(OutputMessages.RobotsFed, fedCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var orderedRobots = robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            foreach (var robot in orderedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
