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
        /// <summary>
        /// Игровая сцена.
        /// </summary>
        Scene scene;

        /// <summary>
        /// Отслеживание характеристик танков.
        /// </summary>
        PlayersStatistics playersStatistics;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            timer1.Interval = 15;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            scene = new Scene();
            playersStatistics = new PlayersStatistics(scene);
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
            CheckCooldownPlayers();
            CheckAmmunitionPlayers();
            glControl1.Refresh();
        }

        /// <summary>
        /// Метод, который выводит информацию о топливе игроков.
        /// </summary>
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

        /// <summary>
        /// Метод, который выводит информацию о броне игроков.
        /// </summary>
        private void CheckHealthPlayers()
        {
            if (playersStatistics.CheckHealthPlayer1() <= 0)
            {
                healthPlayer1.Text = "Здоровье: 0";
                timer1.Stop();
                MessageBox.Show("Игрок 2 победил!");
            }
            else
            {
                healthPlayer1.Text = "Здоровье: " + playersStatistics.CheckHealthPlayer1();
            }
            if (playersStatistics.CheckHealthPlayer2() <= 0)
            {
                healthPlayer2.Text = "Здоровье: 0";
                timer1.Stop();
                MessageBox.Show("Игрок 1 победил!");
            }
            else
            {
                healthPlayer2.Text = "Здоровье: " +  playersStatistics.CheckHealthPlayer2();
            } 
        }

        /// <summary>
        /// Метод, который выводит информацию о перезарядке игроков.
        /// </summary>
        private void CheckCooldownPlayers()
        {
            double seconds1 = playersStatistics.ReturnColdown1() / 1000;
            double seconds2 = playersStatistics.ReturnColdown2() / 1000;
            cooldown1.Text = "Перезарядка:" + Math.Round(seconds1, 1).ToString();
            cooldown2.Text = "Перезарядка:" + Math.Round(seconds2, 1).ToString();
        }

        /// <summary>
        /// Метод, который выводит информацию о запасе патрон игроков.
        /// </summary>
        private void CheckAmmunitionPlayers()
        {
            int[] ammunition_1 = playersStatistics.AmmunitionPlayer1();
            int[] ammunition_2 = playersStatistics.AmmunitionPlayer2();
            ammunitionPlayer1.Text = "Боезапас: " + ammunition_1[0].ToString() + " | " + ammunition_1[1].ToString();
            ammunitionPlayer2.Text = "Боезапас: " + ammunition_2[0].ToString() + " | " + ammunition_2[1].ToString();
        }
    }
}
