using coursework;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс, описывающий выпущенный патрон.
    /// </summary>
    public class Amo : GameObject // 3
    {
        private string direction;
        private float speedOfAmo;
        public int Damage { get; set; }

        public Amo(float x, float y, float height, float width, int objectType, float speedOfAmo, int damage, string direction) : base(x, y, height, width, objectType)
        {
            this.speedOfAmo = speedOfAmo;
            Damage = damage;
            this.direction = direction;
            texture = Textures2D.LoadTexture(texturesInstaller.SetTexture(3));
        }

        /// <summary>
        /// Переопределённый метод отрисовки пули
        /// </summary>
        public override void Draw()
        {
            Move();
            float xLeft, xRight, yUpper, yLower;

            xLeft = x - (float)width / 2;
            xRight = x + (float)width / 2;
            yUpper = y + (float)height / 2;
            yLower = y - (float)height / 2;

            if (direction == "U")
            {
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
            if (direction == "R")
            {
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);
                GL.Vertex2(xRight, yUpper);
                GL.TexCoord2(1, 0);
                GL.Vertex2(xRight, yLower);
                GL.TexCoord2(1, 1);
                GL.Vertex2(xLeft, yLower);
                GL.TexCoord2(0, 1);
                GL.Vertex2(xLeft, yUpper);

                GL.End();
            }
            if (direction == "D")
            {
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);
                GL.Vertex2(xLeft, yLower);
                GL.TexCoord2(1, 0);
                GL.Vertex2(xRight, yLower);
                GL.TexCoord2(1, 1);
                GL.Vertex2(xRight, yUpper);
                GL.TexCoord2(0, 1);
                GL.Vertex2(xLeft, yUpper);

                GL.End();
            }
            if (direction == "L")
            {
                GL.BindTexture(TextureTarget.Texture2D, texture.Id);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0, 0);
                GL.Vertex2(xLeft, yLower);
                GL.TexCoord2(1, 0);
                GL.Vertex2(xLeft, yUpper);
                GL.TexCoord2(1, 1);
                GL.Vertex2(xRight, yUpper);
                GL.TexCoord2(0, 1);
                GL.Vertex2(xRight, yLower);

                GL.End();
            }
        }

        public void Move()
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

        /// <summary>
        /// </summary>
        /// <returns>Направлени полёта пули.</returns>
        public string GetAmoDerection()
        {
            return direction;
        }
    }
}
