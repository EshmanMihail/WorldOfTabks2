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
            return ((Tank)scene.GetGameObjects()[0]).Hp;
        }
        public int CheckFuelPlayer1()
        {
            return ((Tank)scene.GetGameObjects()[0]).Fuel;
        }
        public double TrunkCooldownPlayer1(int timeInterval)
        {
            if (((Tank)scene.GetGameObjects()[0]).TrunkColdown <= 0)
            {
                ((Tank)scene.GetGameObjects()[0]).TrunkColdown = 0;
            }
            else
            {
                ((Tank)scene.GetGameObjects()[0]).TrunkColdown -= timeInterval;
            }
            return ((Tank)scene.GetGameObjects()[0]).TrunkColdown;
        }
        public int[] AmmunitionPlayer1()
        {
            int[] ammunition = { ((Tank)scene.GetGameObjects()[0])[0], ((Tank)scene.GetGameObjects()[0])[1] };
            return ammunition;
        }


        public int CheckHealthPlayer2()
        {
            return ((Tank)scene.GetGameObjects()[1]).Hp;
        }
        public int CheckFuelPlayer2()
        {
            return ((Tank)scene.GetGameObjects()[1]).Fuel;
        }
        public double TrunkCooldownPlayer2(int timeInterval)
        {
            if (((Tank)scene.GetGameObjects()[1]).TrunkColdown <= 0)
            {
                ((Tank)scene.GetGameObjects()[1]).TrunkColdown = 0;
            }
            else
            {
                ((Tank)scene.GetGameObjects()[1]).TrunkColdown -= timeInterval;
            }
            return (((Tank)scene.GetGameObjects()[1]).TrunkColdown);
        }
        public int[] AmmunitionPlayer2()
        {
            int[] ammunition = { ((Tank)scene.GetGameObjects()[1])[0], ((Tank)scene.GetGameObjects()[1])[1] };
            return ammunition;
        }
    }
}
