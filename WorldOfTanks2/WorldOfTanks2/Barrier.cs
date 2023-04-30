using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс барьер - это стена, через которую можно стрелять, но нельзя проехать.
    /// </summary>
    public class Barrier : GameObject // 5
    {
        public Barrier(float x, float y, float height, float width, int objectType) : base(x, y, width, height, objectType)
        {

        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
