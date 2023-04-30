﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using System.Xml.Linq;
using OpenTK.Platform;

namespace WorldOfTanks2
{
    public partial class Form1 : Form
    {
        Scene scene;
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            scene = new Scene();

            progressBar1.Value = 100;
            progressBar2.Value = 100;

            timer1.Interval = 8;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            
        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            glControl1.SwapBuffers();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.UpdateScene();
            CheckHealthPlayers();
            glControl1.Refresh();
        }

        private void CheckHealthPlayers()
        {
            if (scene.CheckHealthPlayer1() <= 0)
            {
                progressBar1.Value = 0;
                timer1.Stop();
            }
            else
            {
                progressBar1.Value = scene.CheckHealthPlayer1();
            }
            if (scene.CheckHealthPlayer2() <= 0)
            {
                progressBar2.Value = 0;
                timer1.Stop();
            }
            else
            {
                progressBar2.Value = scene.CheckHealthPlayer2();
            }
        }
    }
}
