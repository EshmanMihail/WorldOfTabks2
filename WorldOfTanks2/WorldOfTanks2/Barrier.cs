using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public class Barrier : GameObject
    {
        private int objectType;
        public Barrier(float x, float y, float height, float width, int objectType) : base(x, y, width, height)
        {
            this.objectType = objectType;
        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
