using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfTanks2.Debuffs;

namespace WorldOfTanks2
{
    public class Mist : DebuffObject
    {
        //6
        public Mist(float x, float y, float height, float width, int objectType) : base(x, y, height, width, objectType)
        {

        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
