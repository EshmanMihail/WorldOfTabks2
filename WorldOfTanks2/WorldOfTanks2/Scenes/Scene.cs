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
using WorldOfTanks2.InteractionWithGameScene;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс, описывающий игровое поле.
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// Список объектов на сцене.
        /// </summary>
        private List<GameObject> objects;

        /// <summary>
        /// Временный массив с объектами, который нужен
        /// для возможности удаления объектов со сцены.
        /// </summary>
        private List<GameObject> objectsToRemove;

        /// <summary>
        /// Временный массив с объектами, который нужен
        /// для возможности добавления объектов на сцену.
        /// </summary>
        private List<GameObject> objectsToAdd;

        /// <summary>
        /// Список дебафов на сцене.
        /// </summary>
        private List<DebuffObject> objectsDebuff;

        /// <summary>
        /// Класс, который отвечает за свершение событий на сцене.
        /// </summary>
        private SceneEvents sceneIvents;

        /// <summary>
        /// Класс, который отвечает за дейсвия игроков на сцене.
        /// </summary>
        private EventCheker action;

        /// <summary>
        /// Лабиринт, который отвечает за расположение на сцене.
        /// </summary>
        private Maze maze;

        /// <summary>
        /// Создание сцены.
        /// </summary>
        public Scene()
        {
            objects = new List<GameObject>();
            objectsToRemove = new List<GameObject>();
            objectsToAdd = new List<GameObject>();
            objectsDebuff = new List<DebuffObject>();

            action = new EventCheker(this);
            sceneIvents = new SceneEvents(this);
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
            
            if (objects.Count != 0)
            {
                action.EventChecking((Tank)objects[0], (Tank)objects[1]);
            }
            
            UpdateObjectsArray();

            sceneIvents.ChangePositionOfDebuffs();

            DrawObjects();
        }

        /// <summary>
        /// Метод отрисовки всех объектов на сцене.
        /// </summary>
        private void DrawObjects()
        {
            List<GameObject> players = new List<GameObject>();
            players.Add(objects[0]);
            players.Add(objects[1]);
            List<DebuffObject> mud = new List<DebuffObject>();
            List<DebuffObject> mist = new List<DebuffObject>();
            foreach (DebuffObject obj in objectsDebuff)
            {
                if (obj is Mud) mud.Add(obj);
                if (obj is Mist) mist.Add(obj);
            }
            foreach (DebuffObject obj in mud)
            {
                obj.Draw();
            }
            foreach (GameObject obj in players)
            {
                obj.Draw();
            }
            foreach (GameObject obj in objects)
            {
                obj.Draw();
            }
            foreach (DebuffObject obj in mist)
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
        /// Метод, добавляющий объект, который носит отрицательный эффект.
        /// </summary>
        public void AddDebuffObject(DebuffObject debuffObject)
        {
            objectsDebuff.Add(debuffObject);
        }

        /// <summary>
        /// Получение списка всех объектов, которые носят отрицательные эффекты.
        /// </summary>
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
            Tank firstPlayer = new BaseTank(0, -0.5f, 0.1f, 0.1f, 100, "U", 10000, 0, 25, 150, 0, 1);
            Tank secondPlayer = new BaseTank(0, 0.5f, 0.1f, 0.1f, 100, "D", 10000, 0, 25, 150, 0, 2);
            objectsToAdd.Add(firstPlayer);
            objectsToAdd.Add(secondPlayer);
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
