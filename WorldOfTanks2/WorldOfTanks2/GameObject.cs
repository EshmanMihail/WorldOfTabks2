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
    /// <summary>
    /// Абстрактный класс, описывающий базовые свойства объекта в игре.
    /// </summary>
    public abstract class GameObject : IDisposable
    {
        protected float x;
        protected float y;
        protected float height;
        protected float width;
        protected int objectType;

        public GameObject(float x, float y, float height, float width, int objectType)
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

        public float Get_X()
        {
            return x;
        }

        public float Get_Y()
        {
            return y;
        }

        public float Get_Width()
        {
            return width;
        }

        public int Get_ObjectType()
        {
            return objectType;
        }

        public virtual void Dispose()
        {

        }
    }
}
