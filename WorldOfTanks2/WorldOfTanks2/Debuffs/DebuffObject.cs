using coursework;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2.Debuffs
{
    /// <summary>
    /// Описывает объекты, которые изменяют характеристики танка.
    /// </summary>
    public abstract class DebuffObject
    {
        protected float x;
        protected float y;
        protected float height;
        protected float width;
        protected int objectType;

        /// <summary>
        /// Текстура объекта.
        /// </summary>
        protected Textures texture;

        /// <summary>
        /// Х координата объекта.
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        /// <summary>
        /// Y координата объекта.
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        /// <summary>
        /// Ширина объекта.
        /// </summary>
        public float Width
        {
            get { return width; }
        }

        /// <summary>
        /// Создаёт дебафф.
        /// </summary>
        public DebuffObject(float x, float y, float height, float width, int objectType)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.objectType = objectType;
        }

        /// <summary>
        /// Метод, отвечающий за отрисовку.
        /// </summary>
        public virtual void Draw()
        {
            float xLeft, xRight, yUpper, yLower;

            xLeft = x - (float)width / 2;
            xRight = x + (float)width / 2;
            yUpper = y + (float)height / 2;
            yLower = y - (float)height / 2;

            GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex2(xLeft, yUpper);
            GL.TexCoord2(1, 0);
            GL.Vertex2(xRight, yUpper);
            GL.TexCoord2(1, 1);
            GL.Vertex2(xRight, yLower);
            GL.TexCoord2(0, 1);
            GL.Vertex2(xLeft, yLower);

            GL.End();
        }
    }
}
