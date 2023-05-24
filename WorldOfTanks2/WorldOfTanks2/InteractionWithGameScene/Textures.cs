using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace coursework
{
    /// <summary>
    /// Класс, который описывает двухмерную текстуру.
    /// </summary>
    public class Textures2D
    {
        /// <summary>
        /// Идентификатор текстуры.
        /// </summary>
        public virtual int Id { get; private set; }
        /// <summary>
        /// Ширина текстуры.
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Высота текстуры.
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// Цвет, который будет наложен на текстуру.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Создание новой текстуры.
        /// </summary>
        public Textures2D(int id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
            Color = Color.Transparent;
        }

        /// <summary>
        /// Загрузка текстуры из файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Загруженная текстура.</returns>
        public static Textures2D LoadTexture(string path)
        {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bitmap = new Bitmap(path);
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0,
                PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureWrapS,
                (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureWrapT,
                (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Nearest);

            return new Textures2D(id, bitmap.Width, bitmap.Height);
        }

    }
}