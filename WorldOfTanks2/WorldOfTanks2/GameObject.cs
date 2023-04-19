using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace WorldOfTanks2
{
    public class GameObject : IDisposable
    {
        protected float x;
        protected float y;
        protected float height;
        protected float width;
        public GameObject(float x, float y, float height, float width)
        {
            this.x = x;
            this.y = y; 
            this.height = height;
            this.width = width;
        }
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public virtual void Draw()
        {
            float xLeft, xRight, yUpper, yLower;

            xLeft = x - (float)width / 2;
            xRight = x + (float)width / 2;
            yUpper = y + (float)height / 2;
            yLower = y - (float)height / 2;

            GL.PointSize(30);
            GL.Begin(PrimitiveType.Quads);

            GL.Vertex2(xLeft, yLower);
            GL.Vertex2(xRight, yLower);
            GL.Vertex2(xRight, yUpper);
            GL.Vertex2(xLeft, yUpper);

            GL.End();
        }

        public void Dispose()
        {

        }
    }
}
