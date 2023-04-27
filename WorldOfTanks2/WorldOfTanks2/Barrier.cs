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
    public class Barrier : GameObject
    {
        private int objectType;//
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
