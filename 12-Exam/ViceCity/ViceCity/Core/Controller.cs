using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepo;
        private List<IPlayer> civilPlayers;
        private MainPlayer tommy = new MainPlayer();
        private GangNeighbourhood neighbourhood = new GangNeighbourhood();

        public Controller()
        {
            gunRepo = new GunRepository();
            civilPlayers = new List<IPlayer>();
        }
        public string AddGun(string type, string name)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            gunRepo.Add(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (gunRepo.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = gunRepo.Models.FirstOrDefault();

            if (name == "Vercetti")
            {
                tommy.GunRepository.Add(gun);
                gunRepo.Remove(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var civilPlayer = civilPlayers.FirstOrDefault(x => x.Name == name);

            if (civilPlayer == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            civilPlayer.GunRepository.Add(gun);
            gunRepo.Remove(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
        }

        public string AddPlayer(string name)
        {
            var civilPlayer = new CivilPlayer(name);

            civilPlayers.Add(civilPlayer);

            return $"Successfully added civil player: {civilPlayer.Name}!";
        }

        public string Fight()
        {
            int tommysHealthBeforeFight = tommy.LifePoints;
            bool isEveryBodyFine = true;
            neighbourhood.Action(tommy, civilPlayers);

            if (!civilPlayers.Any(x => x.IsAlive) || civilPlayers.Any(x => x.LifePoints != 50))
            {
                isEveryBodyFine = false;
            }

            if (isEveryBodyFine && tommysHealthBeforeFight == tommy.LifePoints)
            {
                return "Everything is okay!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                var killedEnemiesList = civilPlayers.Where(x => x.LifePoints == 0);
                int killedEnemiesCount = killedEnemiesList.Count();
                var livingEnemiesList = civilPlayers.Where(x => x.IsAlive);
                int livingEnemiesCount = livingEnemiesList.Count();


                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {tommy.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {killedEnemiesCount} players!");
                sb.AppendLine($"Left Civil Players: {livingEnemiesCount}!");

                return sb.ToString().TrimEnd();
            }


        }
    }
}
