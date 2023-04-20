using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public class Amo : GameObject
    {
        private string direction;
        public Amo(float x, float y, float height, float width, string direction) : base(x, y, height, width)
        {
            this.direction = direction;
        }

        public override void Draw()
        {
            base.Draw();
            if (y > -1 && y < 1 && x < 1 && x > -1) Move();
            else { }
        }

        private void Move()
        {
            switch (direction)
            {
                case "U":
                    y += 0.1f;
                    break;
                case "D":
                    y -= 0.1f;
                    break;
                case "R":
                    x += 0.1f;
                    break;
                case "L":
                    x -= 0.1f;
                    break;
            }
        }
    }
}
