using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using WorldOfTanks2.InteractionWithGameScene;
using coursework;
using WorldOfTanks2.Scenes;

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

        /// <summary>
        /// Текстура объекта.
        /// </summary>
        protected Textures2D texture;

        protected TexturesDistributor texturesInstaller = new TexturesDistributor();

        /// <summary>
        /// Создание игрового объекта.
        /// </summary>
        public GameObject(float x, float y, float height, float width, int objectType)
        {
            this.x = x;
            this.y = y; 
            this.height = height;
            this.width = width;
            this.objectType = objectType;
        }
        public GameObject() { }
        
        /// <summary>
        /// Метод, отвечающий за отрисовку объкта на игровой сцене.
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

        /// <summary>
        /// Возвращает Х координату объетка.
        /// </summary>
        public virtual float Get_X()
        {
            return x;
        }
        /// <summary>
        /// Возвращает Y координату объетка.
        /// </summary>
        public virtual float Get_Y()
        {
            return y;
        }
        /// <summary>
        /// Возвращает ширину объетка.
        /// </summary>
        public virtual float Get_Width()
        {
            return width;
        }
        /// <summary>
        /// Возвращает тип объетка.
        /// </summary>
        public virtual int Get_ObjectType()
        {
            return objectType;
        }

        public virtual void Dispose()
        {

        }
    }
}
