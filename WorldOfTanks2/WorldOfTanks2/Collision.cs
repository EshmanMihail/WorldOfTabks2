using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    public class Collision
    {
        private List<float> walls = new List<float>() 
        {
            0.1f, -0.1f,  0.2f, -0.1f, 0.4f, -0.1f, 0.6f, -0.1f,  0.6f, -0.2f,  0.6f, -0.3f,
             -0.1f, 0.1f,  -0.2f, 0.1f,  -0.4f, 0.1f,  -0.6f, 0.1f,  -0.6f, 0.2f, -0.6f, 0.3f,

             -0.65f, -0.4f,  -0.65f, -0.3f,  -0.65f, -0.2f,
             0.65f, 0.4f,  0.65f, 0.3f,  0.65f, 0.2f,

             -0.2f, -0.7f,  -0.1f, -0.7f,  0f, -0.7f,  0.1f, -0.7f , 0.2f, -0.7f ,  0.4f, -0.7f ,  0.5f, -0.7f,
             0.2f, 0.7f,  0.1f, 0.7f,  0f, 0.7f,  -0.1f, 0.7f,  -0.2f, 0.7f,  -0.4f, 0.7f,  -0.5f, 0.7f,
             -0.85f, 0.7f,  0.85f, -0.7f,  0.85f, 0.7f, -0.85f, -0.7f,

             0.3f, -0.1f,  0.5f, -0.1f,  -0.3f, 0.1f,  -0.5f, 0.1f,  -0.85f, -0.4f, -0.75f, -0.4f,
             -0.55f, -0.4f,  -0.45f, -0.4f,  0.85f, 0.4f,  0.75f, 0.4f,  0.55f, 0.4f,  0.45f, 0.4f,
             0.3f, -0.7f,  -0.3f, 0.7f
        };

        public Collision() { }

        public bool CheckToCollision(float goX, float goY, int objectType)
        {
            if (goY >= 0.85 || goY <= -0.85 || goX >= 0.85 || goX <= -0.85)
            {
                return true;
            }
            for (int i = 0; i < walls.Count; i += 2)
            {
                if (Math.Abs(walls[i] - goX) < 0.1 && Math.Abs(walls[i + 1] - goY) < 0.1)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
