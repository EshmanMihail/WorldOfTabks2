using System;
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
            
            timer1.Interval = 16;
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
            glControl1.Refresh();
        }
    }
}
