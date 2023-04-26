using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WorldOfTanks2
{
    public class Maze
    {
        Scene scene;
        public Maze(Scene scene)
        {
            this.scene = scene;
        }

        private List<float> coodsOfWalls = new List<float>()
        {
              0.2f, -0.1f, 0.4f, -0.1f, 0.6f, -0.1f,  0.6f, -0.2f,  0.6f, -0.3f,
              -0.2f, 0.1f,  -0.4f, 0.1f,  -0.6f, 0.1f,  -0.6f, 0.2f, -0.6f, 0.3f,

             -0.65f, -0.4f,  -0.65f, -0.3f,  -0.65f, -0.2f,
             0.65f, 0.4f,  0.65f, 0.3f,  0.65f, 0.2f,

             -0.2f, -0.7f,  -0.1f, -0.7f,  0f, -0.7f,  0.1f, -0.7f , 0.2f, -0.7f ,  0.4f, -0.7f ,  0.5f, -0.7f,
             0.2f, 0.7f,  0.1f, 0.7f,  0f, 0.7f,  -0.1f, 0.7f,  -0.2f, 0.7f,  -0.4f, 0.7f,  -0.5f, 0.7f,
             -0.85f, 0.7f,  0.85f, -0.7f,  0.85f, 0.7f, -0.85f, -0.7f
        };

        private List<float> coodsOfBarriers = new List<float>()
        {
             0.3f, -0.1f,  0.5f, -0.1f,  -0.3f, 0.1f,  -0.5f, 0.1f,  -0.85f, -0.4f, -0.75f, -0.4f,
             -0.55f, -0.4f,  -0.45f, -0.4f,  0.85f, 0.4f,  0.75f, 0.4f,  0.55f, 0.4f,  0.45f, 0.4f,
             0.3f, -0.7f,  -0.3f, 0.7f
        };
        public void AddWalls()
        {
            for (int i = 0; i < coodsOfWalls.Count; i += 2)
            {
                scene.AddObject(new Wall(coodsOfWalls[i], coodsOfWalls[i + 1], 0.1f, 0.1f, 4));
            }
            float xbegin = 0.95f, ybegin = 0.95f;
            Math.Round(ybegin, 2);
            while (ybegin >= -0.95f)
            {
                scene.AddObject(new Wall(xbegin, ybegin, 0.1f, 0.1f, 4));
                ybegin += -0.1f;
            }
            while (xbegin >= -0.95f)
            {
                scene.AddObject(new Wall(xbegin, ybegin, 0.1f, 0.1f, 4));
                xbegin += -0.1f;
            }
            while (ybegin < 0.95f)
            {
                scene.AddObject(new Wall(xbegin, ybegin, 0.1f, 0.1f, 4));
                ybegin += 0.1f;
            }
            while (xbegin < 0.95f)
            {
                scene.AddObject(new Wall(xbegin, ybegin, 0.1f, 0.1f, 4));
                xbegin += 0.1f;
            }
        }

        public void AddBarries()
        {
            for (int i = 0; i < coodsOfBarriers.Count; i += 2)
            {
                scene.AddObject(new Barrier(coodsOfBarriers[i], coodsOfBarriers[i + 1], 0.1f, 0.1f, 5));
            }
        }

    }
}
