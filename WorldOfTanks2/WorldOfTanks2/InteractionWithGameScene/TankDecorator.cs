using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2.InteractionWithGameScene
{
    public abstract class TankDecorator : Tank
    {
        protected Tank tank;
        public TankDecorator(Tank tank)
        {
            this.tank = tank;
        }
    }
}
