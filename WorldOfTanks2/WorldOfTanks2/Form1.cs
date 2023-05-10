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
            CheckAmmunitionPlayers();
            glControl1.Refresh();
        }

        private void CheckFuelPlayers()
        {
            if (playersStatistics.CheckFuelPlayer1() <= 0)
            {
                fuelPlayer1.Text = "Запас топлива: 0";
            }
            else
            {
                fuelPlayer1.Text = "Запас топлива: " + playersStatistics.CheckFuelPlayer1();
            }
            if (playersStatistics.CheckFuelPlayer2() <= 0)
            {
                fuelPlayer2.Text = "Запас топлива: 0";
            }
            else
            {
                fuelPlayer2.Text = "Запас топлива: " + playersStatistics.CheckFuelPlayer2();
            }
        }

        private void CheckHealthPlayers()
        {
            if (playersStatistics.CheckHealthPlayer1() <= 0)
            {
                healthPlayer1.Text = "Здоровье: 0";
                timer1.Stop();
            }
            else
            {
                healthPlayer1.Text = "Здоровье: " + playersStatistics.CheckHealthPlayer1();
            }
            if (playersStatistics.CheckHealthPlayer2() <= 0)
            {
                healthPlayer2.Text = "Здоровье: 0";
                timer1.Stop();
            }
            else
            {
                healthPlayer2.Text = "Здоровье: " +  playersStatistics.CheckHealthPlayer2();
            } 
        }

        private void CheckCooldownPlayers(int timeInterval)
        {
            double seconds1 = playersStatistics.TrunkCooldownPlayer1(timeInterval) / 1000;
            double seconds2 = playersStatistics.TrunkCooldownPlayer2(timeInterval) / 1000;
            cooldown1.Text = "Перезарядка:" + Math.Round(seconds1, 1).ToString();
            cooldown2.Text = "Перезарядка:" + Math.Round(seconds2, 1).ToString();
        }

        private void CheckAmmunitionPlayers()
        {
            int[] ammunition_1 = playersStatistics.AmmunitionPlayer1();
            int[] ammunition_2 = playersStatistics.AmmunitionPlayer2();
            ammunitionPlayer1.Text = "Боезапас: " + ammunition_1[0].ToString() + " | " + ammunition_1[1].ToString();
            ammunitionPlayer2.Text = "Боезапас: " + ammunition_2[0].ToString() + " | " + ammunition_2[1].ToString();
        }
    }
}
