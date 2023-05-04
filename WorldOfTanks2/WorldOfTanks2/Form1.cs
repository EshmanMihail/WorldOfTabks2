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

        PlayersStatistics playersStatistics;
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            scene = new Scene();
            playersStatistics = new PlayersStatistics(scene);

            health1.Value = 100;
            health2.Value = 100;
            fuelRsrf1.Value = 100;
            fuelRsrf2.Value = 100;

            timer1.Interval = 15;
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
            CheckFuelPlayers();
            CheckCooldownPlayers(timer1.Interval);
            glControl1.Refresh();
        }

        private void CheckFuelPlayers()
        {
            if (playersStatistics.CheckFuelPlayer1() <= 0)
            {
                fuelRsrf1.Value = 0;
            }
            else
            {
                fuelRsrf1.Value = playersStatistics.CheckFuelPlayer1();
            }
            if (playersStatistics.CheckFuelPlayer2() <= 0)
            {
                fuelRsrf2.Value = 0;
            }
            else
            {
                fuelRsrf2.Value = playersStatistics.CheckFuelPlayer2();
            }
        }

        private void CheckHealthPlayers()
        {
            if (playersStatistics.CheckHealthPlayer1() <= 0)
            {
                health1.Value = 0;
                timer1.Stop();
            }
            else
            {
                health1.Value = playersStatistics.CheckHealthPlayer1();
            }
            if (playersStatistics.CheckHealthPlayer2() <= 0)
            {
                health2.Value = 0;
                timer1.Stop();
            }
            else
            {
                health2.Value = playersStatistics.CheckHealthPlayer2();
            }
        }

        private void CheckCooldownPlayers(int timeInterval)
        {
            double seconds1 = playersStatistics.TrunkCooldownPlayer1(timeInterval) / 1000;
            double seconds2 = playersStatistics.TrunkCooldownPlayer2(timeInterval) / 1000;
            cooldown1.Text = "Перезарядка:" + Math.Round(seconds1, 1).ToString();
            cooldown2.Text = "Перезарядка:" + Math.Round(seconds2, 1).ToString();
        }
    }
}
