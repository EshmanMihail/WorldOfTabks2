using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public class Player : GameObject
    {
        public Player(float x, float y, float height, float width) : base(x, y, height, width)
        {

        }
        public void Move(float goX, float goY)
        {
            x += goX;
            y += goY;
        }
    }
}
