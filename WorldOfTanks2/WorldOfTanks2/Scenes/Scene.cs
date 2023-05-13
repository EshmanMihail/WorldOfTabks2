using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using System.Windows.Forms;
using WorldOfTanks2.Debuffs;

namespace WorldOfTanks2
{
    public class Scene
    {   
        private List<GameObject> objects;

        private List<GameObject> objectsToRemove;

        private List<GameObject> objectsToAdd;

        private List<DebuffObject> objectsDebuff;

        private SceneIvents sceneIvents;

        private Action action;

        private Maze maze;

        private PlayersStatistics statistics;

        /// <summary>
        /// Создание сцены.
        /// </summary>
        public Scene()
        {
            objects = new List<GameObject>();
            objectsToRemove = new List<GameObject>();
            objectsToAdd = new List<GameObject>();
            objectsDebuff = new List<DebuffObject>();

            action = new Action(this);
            sceneIvents = new SceneIvents(this);
            maze = new Maze(this);
            statistics = new PlayersStatistics(this);

            SpawnPlayers();
            SpawnWallsAndBarriers();
        }

        /// <summary>
        /// В этом методе параметры сцены должны обновляться.
        /// </summary>
        public void UpdateScene()
        {
            GL.ClearColor(0.3f, 0.5f, 0.3f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            if (objects.Count != 0) action.CheckAction((Tank)objects[0], (Tank)objects[1]);

            UpdateObjectsArray();

            sceneIvents.ChangePositionOfDebuffs();

            DrawObjects();
        }

        /// <summary>
        /// Метод отрисовки всех объектов на сцене.
        /// </summary>
        private void DrawObjects()
        {
            foreach (GameObject obj in objects)
            {
                obj.Draw();
            }
            foreach (DebuffObject obj in objectsDebuff)
            {
                obj.Draw();
            }
        }

        /// <summary>
        /// Метод, позволяющий обновлять количество объектов для обработки динамически.
        /// </summary>
        private void UpdateObjectsArray()
        {
            if (objectsToRemove.Count != 0)
            {
                foreach (GameObject gameObject in objectsToRemove)
                {
                    objects.Remove(gameObject);
                }
                objectsToRemove.Clear();
            }
            if (objectsToAdd.Count != 0)
            {
                objects.AddRange(objectsToAdd);
                objectsToAdd.Clear();
                //MessageBox.Show(objects.Count.ToString());
            }
        }

        /// <summary>
        /// Получение списка с объектами на сцене.
        /// </summary>
        /// <returns>Список объектов на сцене.</returns>
        public List<GameObject> GetGameObjects()
        {
            return objects;
        }

        /// <summary>
        /// Метод добавления объекта на сцену.
        /// </summary>
        public void AddObject(GameObject gameObject)
        {
            objectsToAdd.Add(gameObject);
        }

        public void AddDebuffObject(DebuffObject debuffObject)
        {
            objectsDebuff.Add(debuffObject);
        }

        public List<DebuffObject> GetDebuffs()
        {
            return objectsDebuff;
        }

        /// <summary>
        /// Метод удаления объекта со сцены.
        /// </summary>
        public void RemoveObject(GameObject gameObject)
        {
            objectsToRemove.Add(gameObject);
        }

        /// <summary>
        /// Метод, добавляющий игроков на сцену.
        /// </summary>
        private void SpawnPlayers()
        {
            objectsToAdd.Add(new Tank(0, -0.5f, 0.1f, 0.1f, 1));
            objectsToAdd.Add(new Tank(0, 0.5f, 0.1f, 0.1f, 2));
        }

        /// <summary>
        /// Метод, добовляющий стены и барьеры на сцену.
        /// </summary>
        private void SpawnWallsAndBarriers()
        {
            maze.CreateWalls();
            maze.CreateBarries();
        }
    }
}
