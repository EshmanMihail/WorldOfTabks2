using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfTanks2.Debuffs;
using WorldOfTanks2.InteractionWithGameScene;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс, отвечающий за события на сцене.
    /// </summary>
    public class SceneIvents
    {
        /// <summary>
        /// Игровая сцена.
        /// </summary>
        private Scene scene;

        /// <summary>
        /// Объект класса для получения случайныъ чисел.
        /// </summary>
        private Random random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Переменная, отвечающая за время изменения позиции дебаффов.
        /// </summary>
        private int positionColdown = 0;
        /// <summary>
        /// Количество тумана.
        /// </summary>
        private int mistCount = 3;
        /// <summary>
        /// Количество грязи.
        /// </summary>
        private int mudCount = 4;

        public SceneIvents(Scene scene)
        {
            this.scene = scene;
            CreateDebuffs();
        }

        private bool CheckCollisionD(DebuffObject debuffObject)
        {
            foreach (DebuffObject obj in scene.GetDebuffs())
            {
                if (obj == debuffObject) continue;

                float leftEdge = debuffObject.X - debuffObject.Width / 2;
                float rightEdge = debuffObject.X + debuffObject.Width / 2;
                float topEdge = debuffObject.Y + debuffObject.Width / 2;
                float bottomEdge = debuffObject.Y - debuffObject.Width / 2;

                float leftEdgeObj = obj.X - obj.Width / 2;
                float rightEdgeObj = obj.X + obj.Width / 2;
                float topEdgeObj = obj.Y + obj.Width / 2;
                float bottomEdgeObj = obj.Y - obj.Width / 2;

                if (!(leftEdge >= rightEdgeObj || rightEdge <= leftEdgeObj || topEdge <= bottomEdgeObj || bottomEdge >= topEdgeObj))
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Изменяет позицию дебаффов на игровой сцене.
        /// </summary>
        public void ChangePositionOfDebuffs()
        {
            if (positionColdown <= 0)
            {
                positionColdown = 6000;
                foreach (DebuffObject debuffObject in scene.GetDebuffs())
                {
                    while (true)
                    {
                        PointF newCenter = GetRandomCenter();
                        debuffObject.X = newCenter.X;
                        debuffObject.Y = newCenter.Y;
                        if (!CheckCollisionD(debuffObject))
                        {
                            debuffObject.X = newCenter.X;
                            debuffObject.Y = newCenter.Y;
                            break;
                        }
                    }
                }
            }
            else
            {
                positionColdown -= 15;
            }
        }

        /// <summary>
        /// Создаёт дебаффы.
        /// </summary>
        private void CreateDebuffs()
        {
            for (int i = 0; i < mudCount; ++i)
            {
                PointF center = GetRandomCenter();
                scene.AddDebuffObject(new Mud(center.X, center.Y, 0.3f, 0.3f, 7));
            }
            for (int i = 0; i < mistCount; ++i)
            {
                PointF center = GetRandomCenter();
                scene.AddDebuffObject(new Mist(center.X, center.Y, 0.3f, 0.3f, 6));
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
