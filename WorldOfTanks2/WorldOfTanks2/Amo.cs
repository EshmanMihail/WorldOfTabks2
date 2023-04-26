using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    public class Amo : GameObject
    {
        private int objectType;
        private string direction;
        private float speedOfAmo = 0.03f;

        public Amo(float x, float y, float height, float width, int objectType, string direction) : base(x, y, height, width)
        {
            this.objectType = objectType;
            this.direction = direction;
        }

        public override void Draw()
        {
            Move();
            base.Draw();
        }

        private void Move()
        {
            switch (direction)
            {
                case "U":
                    y += speedOfAmo;
                    break;
                case "D":
                    y -= speedOfAmo;
                    break;
                case "R":
                    x += speedOfAmo;
                    break;
                case "L":
                    x -= speedOfAmo;
                    break;
            }
        }
    }
}
