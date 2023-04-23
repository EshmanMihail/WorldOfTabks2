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
        public Maze()
        {

        }

        private List<float> coodsWalls = new List<float>()
        {
             0.1f, -0.1f ,  0.2f, -0.1f , 0.4f, -0.1f, 0.6f, -0.1f ,  0.6f, -0.2f ,  0.6f, -0.3f ,
             -0.1f, 0.1f ,  -0.2f, 0.1f ,  -0.4f, 0.1f ,  -0.6f, 0.1f ,  -0.6f, 0.2f , -0.6f, 0.3f ,

             -0.65f, -0.4f ,  -0.65f, -0.3f ,  -0.65f, -0.2f ,
             0.65f, 0.4f ,  0.65f, 0.3f ,  0.65f, 0.2f ,

             -0.2f, -0.7f ,  -0.1f, -0.7f ,  0f, -0.7f ,  0.1f, -0.7f , 0.2f, -0.7f ,  0.4f, -0.7f ,  0.5f, -0.7f ,
             0.2f, 0.7f ,  0.1f, 0.7f ,  0f, 0.7f ,  -0.1f, 0.7f ,  -0.2f, 0.7f ,  -0.4f, 0.7f ,  -0.5f, 0.7f ,
             -0.85f, 0.7f ,  0.85f, -0.7f ,  0.85f, 0.7f , -0.85f, -0.7f
        };

        private List<float> coodsBarrier = new List<float>()
        {
             0.3f, -0.1f ,  0.5f, -0.1f ,  -0.3f, 0.1f ,  -0.5f, 0.1f ,  -0.85f, -0.4f , -0.75f, -0.4f ,
             -0.55f, -0.4f ,  -0.45f, -0.4f ,  0.85f, 0.4f ,  0.75f, 0.4f ,  0.55f, 0.4f ,  0.45f, 0.4f ,
             0.3f, -0.7f ,  -0.3f, 0.7f
        };

        public void Build(float x, float y, float height, float width, Color color)
        {
            float xLeft, xRight, yUpper, yLower;

            xLeft = x - (float)width / 2;
            xRight = x + (float)width / 2;
            yUpper = y + (float)height / 2;
            yLower = y - (float)height / 2;

            GL.Color3(color);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(xLeft, yLower);
            GL.Vertex2(xRight, yLower);
            GL.Vertex2(xRight, yUpper);
            GL.Vertex2(xLeft, yUpper);
            GL.End();
        }
        public void BuildWalls()
        {
            Color color = Color.FromArgb(1, 0, 0, 0);
            for (int i = 0; i < coodsWalls.Count; i += 2)
            {
                Build(coodsWalls[i], coodsWalls[i + 1], 0.1f, 0.1f, color);
            }
        }
        public void BuildSideWalls()
        {
            Color color = Color.FromArgb(0, 0, 0, 1);
            float xbegin = 0.95f, ybegin = 0.95f;
            Math.Round(ybegin, 2);
            while (ybegin >= -0.95f)
            {

                Build(xbegin, ybegin, 0.1f, 0.1f, color);
                ybegin += -0.1f;
            }
            while (xbegin >= -0.95f)
            {

                Build(xbegin, ybegin, 0.1f, 0.1f, color);
                xbegin += -0.1f;

            }
            while (ybegin < 0.95f)
            {

                Build(xbegin, ybegin, 0.1f, 0.1f, color);
                ybegin += 0.1f;
            }
            while (xbegin < 0.95f)
            {

                Build(xbegin, ybegin, 0.1f, 0.1f, color);
                xbegin += 0.1f;
            }
        }
        public void BuildBarrier()
        {
            Color color = Color.FromArgb(1, 150, 150, 150);
            for (int i = 0; i < coodsBarrier.Count; i += 2)
            {
                Build(coodsBarrier[i], coodsBarrier[i + 1], 0.1f, 0.1f, color);
            }
        }
    }
}
