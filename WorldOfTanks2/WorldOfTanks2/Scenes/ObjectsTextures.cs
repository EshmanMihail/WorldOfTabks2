using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2.Scenes
{
    public class ObjectsTextures
    {
        private string texturePlayer_1 = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player1.png";

        private string texturePlayer_2 = "C:\\Users\\Asus\\source\\repos\\WorldOfTabks23\\WorldOfTanks2\\WorldOfTanks2\\Textures\\Player2.png";

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
            return resautl;
        }
    }
}
