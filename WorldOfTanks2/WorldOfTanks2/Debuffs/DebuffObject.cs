using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2.Debuffs
{
    public abstract class DebuffObject
    {
        protected float x;
        protected float y;
        protected float height;
        protected float width;
        protected int objectType;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Width
        {
            get { return width; }
        }

        public DebuffObject(float x, float y, float height, float width, int objectType)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.objectType = objectType;
        }

        public virtual void Draw()
        {
            float xLeft, xRight, yUpper, yLower;

            xLeft = x - (float)width / 2;
            xRight = x + (float)width / 2;
            yUpper = y + (float)height / 2;
            yLower = y - (float)height / 2;

            GL.Begin(PrimitiveType.Quads);

            GL.Vertex2(xLeft, yLower);
            GL.Vertex2(xRight, yLower);
            GL.Vertex2(xRight, yUpper);
            GL.Vertex2(xLeft, yUpper);

            GL.End();
        }
    }
}
