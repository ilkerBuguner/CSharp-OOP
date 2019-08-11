using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var civilPlayer in civilPlayers)
            {
                while (civilPlayer.IsAlive)
                {
                    var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                    if (currentGun == null)
                    {
                        break;
                    }

                    while (currentGun.CanFire)
                    {
                        int lifeToTake = currentGun.Fire();

                        civilPlayer.TakeLifePoints(lifeToTake);
                    }

                    //mainPlayer.GunRepository.Remove(currentGun);
                }
                
            }

            foreach (var civilPlayer in civilPlayers.Where(x => x.IsAlive))
            {
                while (mainPlayer.IsAlive)
                {
                    var currentGun = civilPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                    if (currentGun == null)
                    {
                        break;
                    }

                    while (currentGun.CanFire)
                    {
                        int lifeToTake = currentGun.Fire();

                        mainPlayer.TakeLifePoints(lifeToTake);
                    }

                    //civilPlayer.GunRepository.Remove(currentGun);
                }
            }
        }
    }
}
