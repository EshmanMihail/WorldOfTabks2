using coursework;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorldOfTanks2
{
    /// <summary>
    /// Стена. Через неё нельзя стрелять и нельзя проехать.
    /// </summary>
    public class Wall : GameObject // 4
    {
        public Wall(float x, float y, float height, float width, int objectType) : base(x, y, width, height, objectType)
        {
            texture = Textures2D.LoadTexture(texturesInstaller.SetTexture(objectType));
        }
    }
}
