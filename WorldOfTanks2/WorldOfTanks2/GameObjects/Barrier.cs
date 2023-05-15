using coursework;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс барьер - это стена, через которую можно стрелять, но нельзя проехать.
    /// </summary>
    public class Barrier : GameObject // 5
    {
        public Barrier(float x, float y, float height, float width, int objectType) : base(x, y, width, height, objectType)
        {
            texture = Textures.LoadTexture(@"C:\Users\Asus\source\repos\WorldOfTabks23\WorldOfTanks2\WorldOfTanks2\Textures\barrier.png");
        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
