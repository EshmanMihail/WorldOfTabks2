using coursework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfTanks2.Debuffs;
using WorldOfTanks2.Scenes;

namespace WorldOfTanks2
{
    /// <summary>
    /// Грязь, замедляет танк, если он находится в ней.
    /// </summary>
    public class Mud : DebuffObject
    {
        //7
        public Mud(float x, float y, float height, float width, int objectType) : base(x, y, height, width, objectType)
        {
            texture = Textures2D.LoadTexture(texturesInstaller.SetTexture(objectType));
        }
    }
}
