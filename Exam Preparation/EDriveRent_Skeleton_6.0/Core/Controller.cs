using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user;

            if (users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format
                    (OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);

            return string.Format
                (OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != nameof(CargoVan) && vehicleType != nameof(PassengerCar))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            IVehicle vehicle;

            if (vehicleType == nameof(CargoVan))
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }

            vehicles.AddModel(vehicle);
            return string.Format
                (OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            var route = routes.GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint
                && r.EndPoint == endPoint && r.Length == length);

            if (route != null)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);

            }

            route = routes.GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint
                && r.EndPoint == endPoint && r.Length < length);

            if (route != null)
            {
                return string.Format
                    (OutputMessages.RouteIsTooLong, startPoint, endPoint, length);
            }

            route = routes.GetAll()
               .FirstOrDefault(r => r.StartPoint == startPoint
               && r.EndPoint == endPoint && r.Length > length);

            if ( route != null)
            {
                route.LockRoute();
            }

            var allRoutes = routes.GetAll().Count;
            var newRoute = new Route(startPoint, endPoint, length, allRoutes + 1);

            routes.AddModel(newRoute);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, 
            string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            IRoute route = routes.FindById(routeId);
            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            var vehiclesToRepair = vehicles.GetAll()
                .Where(v => v.IsDamaged == true)
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model)
                .Take(count)
                .ToList();

            foreach (var vehicle in vehiclesToRepair)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return string.Format(OutputMessages.RepairedVehicles, vehiclesToRepair.Count);    
        }

        public string UsersReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*** E-Drive-Rent ***");

            var usersToReport = users
                .GetAll()
                .OrderByDescending(u => u.Rating)
                .ThenBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            foreach (var user in usersToReport)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
