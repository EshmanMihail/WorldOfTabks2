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

namespace WorldOfTanks2
{
    public class Scene
    {   
        private List<GameObject> objects;

        private List<GameObject> objectsToRemove;

        private List<GameObject> objectsToAdd;

        Action action;

        Maze maze;

        /// <summary>
        /// Создание сцены.
        /// </summary>
        public Scene()
        {
            objects = new List<GameObject>();
            objectsToRemove = new List<GameObject>();
            objectsToAdd = new List<GameObject>();
            action = new Action(this);
            maze = new Maze(this);
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

            DrawObjects();
        }

        public int CheckHealthPlayer1()
        {
            return ((Tank)objects[0]).hp;
        }
        public int CheckHealthPlayer2()
        {
            return ((Tank)objects[1]).hp;
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
        public void SpawnPlayers()
        {
            objectsToAdd.Add(new Tank(0, -0.5f, 0.1f, 0.1f, 1));
            objectsToAdd.Add(new Tank(0, 0.5f, 0.1f, 0.1f, 2));
        }

        /// <summary>
        /// Метод, добовляющий стены и барьеры на сцену.
        /// </summary>
        public void SpawnWallsAndBarriers()
        {
            maze.CreateWalls();
            maze.CreateBarries();
        }

    }
}
