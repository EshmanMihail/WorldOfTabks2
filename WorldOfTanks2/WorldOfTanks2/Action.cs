using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
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
        Scene scene;

        public Action(Scene scene)
        {
            this.scene = scene;
        }

        private float TankSpeed = 0.007f;

        private int gunTypeFirstPlayer = 0;
        Weapon[] weaponFirstPlayer = { new Trunk(), new Machinegun() };

        private int gunTypeSecondPlayer = 0;
        Weapon[] weaponSecondPlayer = { new Trunk(), new Machinegun() };

        KeyboardState keyboard1;
        KeyboardState lastkeyboardState1;

        KeyboardState keyboard2;
        KeyboardState lastkeyboardState2;

        private bool CheckCollision(float x, float y, Tank player)
        {
            foreach(GameObject obj in scene.GetGameObjects())
            {
                if (player.Get_ObjectType() == obj.Get_ObjectType()) continue;

                if (obj is Amo && obj.Get_Width() == 0.03f && player.Get_ObjectType() != obj.Get_ObjectType())
                {
                    switch (((Amo)obj).GetAmoDerection())
                    {
                        case "U":
                            if (x - player.Get_Width() / 2 <= obj.Get_X() && x + player.Get_Width() / 2 >= obj.Get_X())
                            {
                                player.hp -= ((Amo)obj).Damage;
                                scene.RemoveObject(obj);
                            }
                            break;
                        case "D":
                            if (x - player.Get_Width() / 2 <= obj.Get_X() && x + player.Get_Width() / 2 >= obj.Get_X())
                            {
                                player.hp -= ((Amo)obj).Damage;
                                scene.RemoveObject(obj);
                            }
                            break;
                        case "R":
                            if (y - player.Get_Width() / 2 <= obj.Get_Y() && y + player.Get_Width() / 2 >= obj.Get_Y())
                            {
                                player.hp -= ((Amo)obj).Damage;
                                scene.RemoveObject(obj);
                            }
                            break;
                        case "L":
                            if (y - player.Get_Width() / 2 <= obj.Get_Y() && y + player.Get_Width() / 2 >= obj.Get_Y())
                            {
                                player.hp -= ((Amo)obj).Damage;
                                scene.RemoveObject(obj);
                            }
                            break;
                    }
                }
                if (obj is Amo && obj.Get_Width() > 0.03f && Math.Abs(x - obj.Get_X()) <= obj.Get_Width() && Math.Abs(y - obj.Get_Y()) <= obj.Get_Width())
                {
                    player.hp -= ((Amo)obj).Damage;
                    scene.RemoveObject(obj);
                }
                if (Math.Abs(x - obj.Get_X()) <= obj.Get_Width() && Math.Abs(y - obj.Get_Y()) <= obj.Get_Width())
                {
                    return true;
                }
            }

            return false;
        }

        private void FirstPlayerAction(Tank player1)
        {
            keyboard1 = Keyboard.GetState();

            CheckCollision(player1.Get_X(), player1.Get_Y(), player1);

            if (keyboard1[Key.W])
            {
                if (!CheckCollision(player1.Get_X(), player1.Get_Y() + TankSpeed, player1))
                    player1.Move("U");
            }
            if (keyboard1[Key.S])
            {
                if (!CheckCollision(player1.Get_X(), player1.Get_Y() - TankSpeed, player1))
                    player1.Move("D");
            }
            if (keyboard1[Key.D])
            {
                if (!CheckCollision(player1.Get_X() + TankSpeed, player1.Get_Y(), player1))
                    player1.Move("R");
            }
            if (keyboard1[Key.A])
            {
                if (!CheckCollision(player1.Get_X() - TankSpeed, player1.Get_Y(), player1))
                    player1.Move("L");
            }
            if (keyboard1[Key.Q] && (keyboard1[Key.Q] != lastkeyboardState1[Key.Q]))
            {
                ChangeGunFirstPlayer();
            }
            if (keyboard1[Key.G] && (keyboard1[Key.G] != lastkeyboardState1[Key.G]))
            {
                if (player1.CheckAmmoCount(weaponFirstPlayer[gunTypeFirstPlayer]))
                {
                    scene.AddObject(player1.Fire(weaponFirstPlayer[gunTypeFirstPlayer]));
                }
            }
            lastkeyboardState1 = keyboard1;
        }
        private void ChangeGunFirstPlayer()
        {
            if (gunTypeFirstPlayer == 0) gunTypeFirstPlayer = 1;
            else gunTypeFirstPlayer = 0;
        }

        private void SecondPlayerAction(Tank player2)
        {
            keyboard2 = Keyboard.GetState();

            CheckCollision(player2.Get_X(), player2.Get_Y(), player2);

            if (keyboard2[Key.Up])
            {
                if (!CheckCollision(player2.Get_X(), player2.Get_Y() + TankSpeed, player2)) 
                    player2.Move("U");
            }
            if (keyboard2[Key.Down])
            {
                if (!CheckCollision(player2.Get_X(), player2.Get_Y() - TankSpeed, player2))
                    player2.Move("D");
            }
            if (keyboard2[Key.Right])
            {
                if (!CheckCollision(player2.Get_X() + TankSpeed, player2.Get_Y(), player2))
                    player2.Move("R");
            }
            if (keyboard2[Key.Left])
            {
                if (!CheckCollision(player2.Get_X() - TankSpeed, player2.Get_Y(), player2))
                    player2.Move("L");
            }
            if (keyboard2[Key.KeypadMinus] && keyboard2[Key.KeypadMinus] != lastkeyboardState2[Key.KeypadMinus])
            {
                ChangeGunSecondPlayer();
            }
            if (keyboard2[Key.KeypadPlus] && keyboard2[Key.KeypadPlus] != lastkeyboardState2[Key.KeypadPlus])
            {
                if (player2.CheckAmmoCount(weaponSecondPlayer[gunTypeSecondPlayer]))
                {
                    scene.AddObject(player2.Fire(weaponSecondPlayer[gunTypeSecondPlayer]));
                }
            }
            lastkeyboardState2 = keyboard2;
        }
        private void ChangeGunSecondPlayer()
        {
            if (gunTypeSecondPlayer == 0) gunTypeSecondPlayer = 1;
            else gunTypeSecondPlayer = 0;
        }

        public void CheckAction(Tank player1, Tank player2)
        {

            FirstPlayerAction(player1);

            SecondPlayerAction(player2);

        }
    }
}
