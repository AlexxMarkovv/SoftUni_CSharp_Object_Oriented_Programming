using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly PilotRepository pilots;
        private readonly RaceRepository races;
        private readonly FormulaOneCarRepository formulaOneCars;

        public Controller()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            formulaOneCars = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilots.FindByName(fullName) != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilots.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type != nameof(Ferrari) && type != nameof(Williams))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar formulaCar = formulaOneCars.FindByName(model);
            if (formulaCar != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == nameof(Williams))
            {
                formulaCar = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                formulaCar = new Ferrari(model, horsepower, engineDisplacement);
            }

            formulaOneCars.Add(formulaCar);
            return $"Car {type}, model {model} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (races.FindByName(raceName) != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            races.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilots.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = formulaOneCars.FindByName(carModel) ?? throw new NullReferenceException
                    (string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));

            pilot.AddCar(car);
            formulaOneCars.Remove(car);

            return string.Format
                (OutputMessages.SuccessfullyPilotToCar, pilotName, pilot.Car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = races.FindByName(raceName) ?? throw new NullReferenceException
                    (string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            IPilot pilot = pilots.FindByName(pilotFullName);
            bool isInTheRace = race.Pilots.Contains(pilot);

            if (isInTheRace || pilot == null || !pilot.CanRace)
            {
                throw new InvalidOperationException
                   (string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.FindByName(raceName) ?? throw new NullReferenceException
                    (string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException
                   (string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException
                   (string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> orderedPilots = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            race.TookPlace = true;
            orderedPilots.First().WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {orderedPilots[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {orderedPilots[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {orderedPilots[2].FullName} is third in the {raceName} race.");

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in pilots.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new();

            foreach (var race in races.Models.Where(r => r.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
