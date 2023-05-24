using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2.Scenes
{
    public class TexturesDistributor
    {
        const string texturePlayer_1 = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png";

        const string texturePlayer_2 = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png";

        const string textureAmmo = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\ammo.png";

        const string textureWall = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\wall.png";

        const string textureBarrier = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\barrier.png";

        const string textureMist = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\mist.png";

        const string textureMud = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\mud.png";

        public string SetTexture(int objectType)
        {
            string resautl = "";
            if (objectType == 1)
            {
                resautl = texturePlayer_1;
            }
            if (objectType == 2)
            {
                resautl = texturePlayer_2;
            }
            if (objectType == 3)
            {
                resautl = textureAmmo;
            }
            if (objectType == 4)
            {
                resautl = textureWall;
            }
            if (objectType == 5)
            {
                resautl = textureBarrier;
            }
            if (objectType == 6)
            {
                resautl = textureMist;
            }
            if (objectType == 7)
            {
                resautl = textureMud;
            }
            return resautl;
        }
    }
}
