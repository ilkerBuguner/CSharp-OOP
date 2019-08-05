using MXGP.Core.Contracts;
using MXGP.Factories;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motorcycleRepo;
        private RaceRepository raceRepo;
        private RiderRepository riderRepo;

        private MotorcycleFactory motorcycleFactory;
        private RaceFactory raceFactory;
        private RiderFactory riderFactory;

        public ChampionshipController()
        {
            motorcycleRepo = new MotorcycleRepository();
            raceRepo = new RaceRepository();
            riderRepo = new RiderRepository();

            motorcycleFactory = new MotorcycleFactory();
            raceFactory = new RaceFactory();
            riderFactory = new RiderFactory();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (riderRepo.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (motorcycleRepo.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            var rider = riderRepo.GetByName(riderName);
            var motorcycle = motorcycleRepo.GetByName(motorcycleModel);

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (raceRepo.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (riderRepo.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var rider = riderRepo.GetByName(riderName);
            var race = raceRepo.GetByName(raceName);

            race.AddRider(rider);

            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = motorcycleFactory.CreateMotorcycle(type, model, horsePower);

            if (motorcycleRepo.GetAll().Any(x => x == motorcycle))
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleExists, model);
            }

            motorcycleRepo.Add(motorcycle);

            return String.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);

        }

        public string CreateRace(string name, int laps)
        {
            var race = raceFactory.CreateRace("Race", name, laps);

            var raceInRepo = raceRepo.GetByName(name);

            if (raceInRepo != null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.RaceExists, name));
            }

            raceRepo.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var rider = riderFactory.CreateRider("Rider", riderName);

            var riderInRepo = riderRepo.GetByName(riderName);

            if (riderInRepo != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }

            riderRepo.Add(rider);

            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = raceRepo.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String
                    .Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var sortedRiders = race.Riders
                .OrderByDescending(x => x.Motorcycle
                .CalculateRacePoints(race.Laps));

            IRider firstRider = sortedRiders.First();
            IRider secondRider = sortedRiders.Skip(1).FirstOrDefault();
            IRider thirdRider = sortedRiders.Skip(2).FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format(OutputMessages
                .RiderFirstPosition, firstRider.Name, raceName));

            sb.AppendLine(String.Format(OutputMessages
                .RiderSecondPosition, secondRider.Name, raceName));

            sb.AppendLine(String.Format(OutputMessages
                .RiderThirdPosition, thirdRider.Name, raceName));

            return sb.ToString().TrimEnd();

        }
    }
}
