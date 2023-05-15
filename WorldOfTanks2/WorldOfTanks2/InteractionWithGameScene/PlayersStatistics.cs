using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WorldOfTanks2.InteractionWithGameScene;

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
        public int[] AmmunitionPlayer1()
        {
            int[] ammunition = { ((Tank)scene.GetGameObjects()[0]).TrunkAmmunition, ((Tank)scene.GetGameObjects()[0]).MachinegunAmmunition };
            return ammunition;
        }
        public double ReturnColdown1()
        {
            return ((Tank)scene.GetGameObjects()[0]).CheckTrunkColdown();
        } 


        public int CheckHealthPlayer2()
        {
            return ((Tank)scene.GetGameObjects()[1]).Hp;
        }
        public int CheckFuelPlayer2()
        {
            return ((Tank)scene.GetGameObjects()[1]).Fuel;
        }
        public int[] AmmunitionPlayer2()
        {
            int[] ammunition = { ((Tank)scene.GetGameObjects()[1]).TrunkAmmunition, ((Tank)scene.GetGameObjects()[1]).MachinegunAmmunition };
            return ammunition;
        }
        public double ReturnColdown2()
        {
            return ((Tank)scene.GetGameObjects()[1]).CheckTrunkColdown();
        }
    }
}
