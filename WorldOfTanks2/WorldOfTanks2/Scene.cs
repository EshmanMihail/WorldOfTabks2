﻿using OpenTK;
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

        Listener listener;

        public Scene()
        {
            objects = new List<GameObject>();
            objectsToRemove = new List<GameObject>();
            objectsToAdd = new List<GameObject>();
            listener = new Listener();
            SpawnPlayers();
        }

        public void UpdateScene()
        {
            GL.ClearColor(0, 0.1f, 0, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            if (objects.Count != 0) listener.CheckKeyDown((Tank)objects[0], (Tank)objects[1], objectsToAdd);

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
                MessageBox.Show(objects.Count.ToString());
            }
        }

        public void SpawnPlayers()
        {
            objectsToAdd.Add(new Tank(-0.7f, -0.5f, 0.2f, 0.2f));
            objectsToAdd.Add(new Tank(0.7f, 0.5f, 0.2f, 0.2f));
        }
    }
}
