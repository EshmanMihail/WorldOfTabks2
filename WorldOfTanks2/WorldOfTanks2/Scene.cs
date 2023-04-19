using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public class Scene
    {   
        private List<GameObject> objects;

        private List<GameObject> objectsToRemove;

        private List<GameObject> objectsToAdd;
        public Scene(System.Windows.Forms.Label label)
        {
            objects = new List<GameObject>();
            objectsToRemove = new List<GameObject>();
            objectsToAdd = new List<GameObject>();
            someObjects();
            label.Text = objectsToAdd.Count.ToString();
        }

        public void UpdateScene()
        {
            Random random = new Random();
            GL.ClearColor(new Color4((float)random.Next(255) / 255, (float)random.Next(255) / 255, (float)random.Next(255) / 255, 1f));
            GL.Clear(ClearBufferMask.ColorBufferBit);
            UpdateObjectsArray();
            foreach(GameObject obj in objects)
            {
                obj.Draw();
            }
        }
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

        public void RemoveObject(GameObject gameObject)
        {
            objectsToRemove.Add(gameObject);
        }

        public void someObjects()
        {
            objectsToAdd.Add(new Player(0, 0, 0.1f, 0.1f));
            objectsToAdd.Add(new Player(0.5f, 0.5f, 0.2f, 0.2f));
            objectsToAdd.Add(new Player(-0.5f, -0.5f, 0.1f, 0.1f));
            objectsToAdd.Add(new Player(0.7f, 0.9f, 0.2f, 0.2f));
        }
    }
}
