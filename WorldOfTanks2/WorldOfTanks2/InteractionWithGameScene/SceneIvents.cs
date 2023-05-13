using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfTanks2.Debuffs;

namespace WorldOfTanks2
{
    public class SceneIvents
    {
        private Scene scene;

        private Random random = new Random();

        private int positionColdown = 0;
        private int mistCount = 2;
        private int mudCount = 4;

        public SceneIvents(Scene scene)
        {
            this.scene = scene;
            CreateMist();
            CreateMud();
        }

        public void ChangePositionOfDebuffs()
        {
            if (positionColdown <= 0)
            {
                positionColdown = 6000;
                foreach (DebuffObject debuffObject in scene.GetDebuffs())
                {
                    PointF newCenter = GetRandomCenter();
                    debuffObject.X = newCenter.X;
                    debuffObject.Y = newCenter.Y;
                }
            }
            else
            {
                positionColdown -= 15;
            }
        }

        private void CreateMist()
        {
            for (int i = 0; i < mistCount; ++i)
            {
                PointF center = GetRandomCenter();
                scene.AddDebuffObject(new Mist(center.X, center.Y, 0.3f, 0.3f, 6));
            }
        }
        private void CreateMud()
        {
            for (int i = 0; i < mudCount; ++i)
            {
                PointF center = GetRandomCenter();
                scene.AddDebuffObject(new Mud(center.X, center.Y, 0.2f, 0.2f, 7));
            }
        }

        /// <summary>
        /// Метод, который случайно генерирует координаты нового центра.
        /// </summary>
        /// <returns>Координаты Х и Y.</returns>
        private PointF GetRandomCenter()
        {
            return new PointF(((float)random.NextDouble() * 1.6f) - 0.8f, (float)(random.NextDouble() * 1.6f) - 0.8f);
        }
    }
}
