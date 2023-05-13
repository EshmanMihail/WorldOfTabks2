using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс проверяет нажатые клавиши и вызывает нужные события.
    /// </summary>
    public class Action
    {
        private Scene scene;

        private Collider collider;

        private KeyboardState keyboard1;
        private KeyboardState lastkeyboardState1;

        private KeyboardState keyboard2;
        private KeyboardState lastkeyboardState2;

        public Action(Scene scene)
        {
            this.scene = scene;
            collider = new Collider(scene);
        }

        private void FirstPlayerAction(Tank player1)
        {
            keyboard1 = Keyboard.GetState();

            collider.CheckCollision(player1.Get_X(), player1.Get_Y(), player1);

            if (keyboard1[Key.W])
            {
                if (!collider.CheckCollision(player1.Get_X(), player1.Get_Y() + player1.TankSpeed(), player1))
                    player1.Move("U");
            }
            if (keyboard1[Key.S])
            {
                if (!collider.CheckCollision(player1.Get_X(), player1.Get_Y() - player1.TankSpeed(), player1))
                    player1.Move("D");
            }
            if (keyboard1[Key.D])
            {
                if (!collider.CheckCollision(player1.Get_X() + player1.TankSpeed(), player1.Get_Y(), player1))
                    player1.Move("R");
            }
            if (keyboard1[Key.A])
            {
                if (!collider.CheckCollision(player1.Get_X() - player1.TankSpeed(), player1.Get_Y(), player1))
                    player1.Move("L");
            }
            if (keyboard1[Key.Q] && (keyboard1[Key.Q] != lastkeyboardState1[Key.Q]))
            {
                player1.ChangeGun();
            }
            if (keyboard1[Key.G] && (keyboard1[Key.G] != lastkeyboardState1[Key.G]))
            {
                if (player1.CheckAmmoCount())
                {
                    if (player1.GunType == 0 && player1.TrunkColdown == 0)
                    {
                        player1.TrunkColdown = 3000;
                        scene.AddObject(player1.Fire());
                    }
                    else if (player1.GunType == 1)
                    {
                        scene.AddObject(player1.Fire());
                    }
                }
            }
            lastkeyboardState1 = keyboard1;
        }

        private void SecondPlayerAction(Tank player2)
        {
            keyboard2 = Keyboard.GetState();

            collider.CheckCollision(player2.Get_X(), player2.Get_Y(), player2);

            if (keyboard2[Key.Up])
            {
                if (!collider.CheckCollision(player2.Get_X(), player2.Get_Y() + player2.TankSpeed(), player2)) 
                    player2.Move("U");
            }
            if (keyboard2[Key.Down])
            {
                if (!collider.CheckCollision(player2.Get_X(), player2.Get_Y() - player2.TankSpeed(), player2))
                    player2.Move("D");
            }
            if (keyboard2[Key.Right])
            {
                if (!collider.CheckCollision(player2.Get_X() + player2.TankSpeed(), player2.Get_Y(), player2))
                    player2.Move("R");
            }
            if (keyboard2[Key.Left])
            {
                if (!collider.CheckCollision(player2.Get_X() - player2.TankSpeed(), player2.Get_Y(), player2))
                    player2.Move("L");
            }
            if (keyboard2[Key.KeypadMinus] && keyboard2[Key.KeypadMinus] != lastkeyboardState2[Key.KeypadMinus])
            {
                player2.ChangeGun();
            }
            if (keyboard2[Key.KeypadPlus] && keyboard2[Key.KeypadPlus] != lastkeyboardState2[Key.KeypadPlus])
            {
                if (player2.CheckAmmoCount())
                {
                    if (player2.GunType == 0 && player2.TrunkColdown == 0)
                    {
                        player2.TrunkColdown = 3000;
                        scene.AddObject(player2.Fire());
                    }
                    else if (player2.GunType == 1)
                    {
                        scene.AddObject(player2.Fire());
                    }
                }
            }
            lastkeyboardState2 = keyboard2;
        }

        public void CheckAction(Tank player1, Tank player2)
        {

            collider.CheckCollisionWithAmmo(player1, player2);

            FirstPlayerAction(player1);

            SecondPlayerAction(player2);

        }
    }
}
