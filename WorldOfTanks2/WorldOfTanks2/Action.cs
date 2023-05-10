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

                if (Math.Abs(x - obj.Get_X()) <= obj.Get_Width() && Math.Abs(y - obj.Get_Y()) <= obj.Get_Width())
                {
                    return true;
                }
            }

            return false;
        }
        private bool CheckCollisionWithAmmo(Tank player1, Tank player2)
        {
            foreach (GameObject ammo in scene.GetGameObjects())
            {
                if (ammo is Amo)
                {
                    if (ammo.Get_Width() != 0.03f)
                    {
                        foreach (GameObject obj in scene.GetGameObjects())
                        {
                            if (obj.Get_ObjectType() == 1 && obj.Get_ObjectType() != ammo.Get_ObjectType() &&
                                obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X()
                                && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y())
                            {
                                player1.Hp -= ((Amo)ammo).Damage;
                                scene.RemoveObject(ammo);
                            }
                            if (obj.Get_ObjectType() == 2 && obj.Get_ObjectType() != ammo.Get_ObjectType() &&
                                obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X()
                                && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y())
                            {
                                player2.Hp -= ((Amo)ammo).Damage;
                                scene.RemoveObject(ammo);
                            }
                            if (obj.Get_ObjectType() == 4 && obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() &&
                                obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X()
                               && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y())
                            {
                                scene.RemoveObject(ammo);
                            }
                        }
                    }
                    else
                    {
                        GameObject hitObj = null;
                        float minDistance = 10000f;                        

                        foreach (GameObject obj in scene.GetGameObjects())
                        {
                            if (obj == ammo) continue;
                            if (((Amo)ammo).GetAmoDerection() == "L")
                            {
                                if (obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y() && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && ammo.Get_X() > obj.Get_X())
                                {
                                    if (minDistance > Math.Abs(obj.Get_X() - ammo.Get_X()))
                                    {
                                        minDistance = Math.Abs(obj.Get_X() - ammo.Get_X());
                                        hitObj = obj;
                                    }
                                }
                            }
                            if (((Amo)ammo).GetAmoDerection() == "R")
                            {
                                if (obj.Get_Y() + obj.Get_Width() / 2 >= ammo.Get_Y() && obj.Get_Y() - obj.Get_Width() / 2 <= ammo.Get_Y() && ammo.Get_X() < obj.Get_X())
                                {
                                    if (minDistance > Math.Abs(obj.Get_X() - ammo.Get_X()))
                                    {
                                        minDistance = Math.Abs(obj.Get_X() - ammo.Get_X());
                                        hitObj = obj;
                                    }
                                }
                            }
                            if (((Amo)ammo).GetAmoDerection() == "U")
                            {
                                if (obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X() && obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && ammo.Get_Y() < obj.Get_Y())
                                {
                                    if (minDistance > Math.Abs(obj.Get_Y() - ammo.Get_Y()))
                                    {
                                        minDistance = Math.Abs(obj.Get_Y() - ammo.Get_Y());
                                        hitObj = obj;
                                    }
                                }
                            }
                            if (((Amo)ammo).GetAmoDerection() == "D")
                            {
                                if (obj.Get_X() + obj.Get_Width() / 2 >= ammo.Get_X() && obj.Get_X() - obj.Get_Width() / 2 <= ammo.Get_X() && ammo.Get_Y() > obj.Get_Y())
                                {
                                    if (minDistance > Math.Abs(obj.Get_Y() - ammo.Get_Y()))
                                    {
                                        minDistance = Math.Abs(obj.Get_Y() - ammo.Get_Y());
                                        hitObj = obj;
                                    }
                                }
                            }
                                                        
                        }
                        if (hitObj is Tank)
                        {
                            if (((Tank)hitObj).Get_ObjectType() == 1)
                            {
                                player1.Hp -= ((Amo)ammo).Damage;
                            }
                            else
                            {
                                player2.Hp -= ((Amo)ammo).Damage;
                            }
                        }
                        scene.RemoveObject(ammo);
                    }
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
                    if (gunTypeFirstPlayer == 0 && player1.TrunkColdown == 0)
                    {
                        player1.TrunkColdown = 3000;
                        scene.AddObject(player1.Fire(weaponFirstPlayer[gunTypeFirstPlayer]));
                    }
                    else if (gunTypeFirstPlayer == 1)
                    {
                        scene.AddObject(player1.Fire(weaponFirstPlayer[gunTypeFirstPlayer]));
                    }
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
                    if (gunTypeSecondPlayer == 0 && player2.TrunkColdown == 0)
                    {
                        player2.TrunkColdown = 3000;
                        scene.AddObject(player2.Fire(weaponSecondPlayer[gunTypeSecondPlayer]));
                    }
                    else if (gunTypeSecondPlayer == 1)
                    {
                        scene.AddObject(player2.Fire(weaponSecondPlayer[gunTypeSecondPlayer]));
                    }
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

            CheckCollisionWithAmmo(player1, player2);

            FirstPlayerAction(player1);

            SecondPlayerAction(player2);

        }
    }
}
