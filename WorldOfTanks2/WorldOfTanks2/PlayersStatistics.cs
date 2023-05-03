using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public class PlayersStatistics
    {
        Scene scene;
        public PlayersStatistics(Scene scene)
        {
            this.scene = scene;
        }

        public int CheckHealthPlayer1()
        {
            return ((Tank)scene.GetGameObjects()[0]).hp;
        }
        public int CheckFuelPlayer1()
        {
            return ((Tank)scene.GetGameObjects()[0]).fuelReserve;
        }

        public int CheckHealthPlayer2()
        {
            return ((Tank)scene.GetGameObjects()[1]).hp;
        }
        public int CheckFuelPlayer2()
        {
            return ((Tank)scene.GetGameObjects()[1]).fuelReserve;
        }
    }
}
