﻿using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldOfTanks2.Debuffs;
using WorldOfTanks2.InteractionWithGameScene;

namespace WorldOfTanks2
{
    /// <summary>
    /// Класс проверяет нажатые клавиши и вызывает нужные события.
    /// </summary>
    public class Action
    {
        /// <summary>
        /// Игровое поле.
        /// </summary>
        private Scene scene;

        /// <summary>
        /// Класс, отвечающий за коллизию.
        /// </summary>
        private Collider collider;


        private KeyboardState keyboard1;
        private KeyboardState lastkeyboardState1;

        private KeyboardState keyboard2;
        private KeyboardState lastkeyboardState2;

        /// <summary>
        /// Создание класса для отслеживания дейсвий игроков.
        /// </summary>
        public Action(Scene scene)
        {
            this.scene = scene;
            collider = new Collider(scene);
        }

        /// <summary>
        /// Проверяет коллизию в дебафами.
        /// </summary>
        private bool CheckCollisionWithDebuff(Tank player)
        {
            bool inDebuff = false;
            foreach (DebuffObject obj in scene.GetDebuffs())
            {
                float leftEdge = player.Get_X() - player.Get_Width() / 2;
                float rightEdge = player.Get_X() + player.Get_Width() / 2;
                float topEdge = player.Get_Y() + player.Get_Width() / 2;
                float bottomEdge = player.Get_Y() - player.Get_Width() / 2;

                float leftEdgeObj = obj.X - obj.Width / 2;
                float rightEdgeObj = obj.X + obj.Width / 2;
                float topEdgeObj = obj.Y + obj.Width / 2;
                float bottomEdgeObj = obj.Y - obj.Width / 2;

                if (obj is Mist && !(leftEdge >= rightEdgeObj || rightEdge <= leftEdgeObj || topEdge <= bottomEdgeObj || bottomEdge >= topEdgeObj))
                {
                    player.InMist = true;
                    inDebuff = true;
                }
                if (obj is Mud && !(leftEdge >= rightEdgeObj || rightEdge <= leftEdgeObj || topEdge <= bottomEdgeObj || bottomEdge >= topEdgeObj))
                {
                    player.InMud = true;
                    inDebuff = true;
                }
            }
            return inDebuff;
        }

        /// <summary>
        /// Изменяет характеристики первого игрока.
        /// </summary>
        private void DebuffsFirstPlayer(Tank player1)
        {
            if (CheckCollisionWithDebuff(player1))
            {

                if (player1.InMist && (player1 is BaseTank))
                {
                    player1 = new NotShootingTank(player1);
                    scene.GetGameObjects()[0] = player1;
                }
                if (player1.InMud && (player1 is BaseTank))
                {
                    player1 = new SlowedTank(player1);
                    scene.GetGameObjects()[0] = player1;
                }
            }
            else if (!(player1 is BaseTank))
            {
                Tank tank = new BaseTank(player1.Get_X(), player1.Get_Y(), player1.Get_Width(), player1.Get_Width(), player1.Hp, player1.Direction,
                                    player1.Fuel, player1.TrunkColdown, player1.TrunkAmmunition, player1.MachinegunAmmunition, player1.GunType, 1);
                scene.GetGameObjects()[0] = tank;
            }
        }

        /// <summary>
        /// Изменяет характеристики второго игрока.
        /// </summary>
        private void DebuffsSecondPlayer(Tank player2)
        {
            if (CheckCollisionWithDebuff(player2))
            {
                if (player2.InMist && (player2 is BaseTank))
                {
                    player2 = new NotShootingTank(player2);
                    scene.GetGameObjects()[1] = player2;
                }
                if (player2.InMud && (player2 is BaseTank))
                {
                    player2 = new SlowedTank(player2);
                    scene.GetGameObjects()[1] = player2;
                }
            }
            else if (!(player2 is BaseTank))
            {
                Tank tank = new BaseTank(player2.Get_X(), player2.Get_Y(), player2.Get_Width(), player2.Get_Width(), player2.Hp, player2.Direction,
                                            player2.Fuel, player2.TrunkColdown, player2.TrunkAmmunition, player2.MachinegunAmmunition, player2.GunType, 2);

                scene.GetGameObjects()[1] = tank;
            }
        }

        /// <summary>
        /// Проверяет нажатые клавиши для первого игрока и выполняет соотвествующие дейсвия.
        /// </summary>
        private void FirstPlayerAction(Tank player1)
        {
            keyboard1 = Keyboard.GetState();

            collider.CheckCollision(player1.Get_X(), player1.Get_Y(), player1);

            if (keyboard1[Key.W])
            {
                if (!collider.CheckCollision(player1.Get_X(), player1.Get_Y() + player1.Speed, player1))
                    player1.Move("U", player1.Speed);
                else
                    player1.Direction = "U";
            }
            if (keyboard1[Key.S])
            {
                if (!collider.CheckCollision(player1.Get_X(), player1.Get_Y() - player1.Speed, player1))
                    player1.Move("D", player1.Speed);
                else
                    player1.Direction = "D";
            }
            if (keyboard1[Key.D])
            {
                if (!collider.CheckCollision(player1.Get_X() + player1.Speed, player1.Get_Y(), player1))
                    player1.Move("R", player1.Speed);
                else
                    player1.Direction = "R";
            }
            if (keyboard1[Key.A])
            {
                if (!collider.CheckCollision(player1.Get_X() - player1.Speed, player1.Get_Y(), player1))
                    player1.Move("L", player1.Speed);
                else
                    player1.Direction = "L";
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
                        if (player1.Fire() != null) scene.AddObject(player1.Fire());
                    }
                    else if (player1.GunType == 1)
                    {
                        if (player1.Fire() != null) scene.AddObject(player1.Fire());
                    }
                }
            }
            lastkeyboardState1 = keyboard1;
        }

        /// <summary>
        /// Проверяет нажатые клавиши для второго игрока и выполняет соотвествующие дейсвия.
        /// </summary>
        private void SecondPlayerAction(Tank player2)
        {
            keyboard2 = Keyboard.GetState();

            collider.CheckCollision(player2.Get_X(), player2.Get_Y(), player2);

            if (keyboard2[Key.Up])
            {
                if (!collider.CheckCollision(player2.Get_X(), player2.Get_Y() + player2.Speed, player2)) 
                    player2.Move("U", player2.Speed);
                else
                    player2.Direction = "U";
            }
            if (keyboard2[Key.Down])
            {
                if (!collider.CheckCollision(player2.Get_X(), player2.Get_Y() - player2.Speed, player2))
                    player2.Move("D", player2.Speed);
                else
                    player2.Direction = "D";
            }
            if (keyboard2[Key.Right])
            {
                if (!collider.CheckCollision(player2.Get_X() + player2.Speed, player2.Get_Y(), player2))
                    player2.Move("R", player2.Speed);
                else
                    player2.Direction = "R";
            }
            if (keyboard2[Key.Left])
            {
                if (!collider.CheckCollision(player2.Get_X() - player2.Speed, player2.Get_Y(), player2))
                    player2.Move("L", player2.Speed);
                else
                    player2.Direction = "L";
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
                        if (player2.Fire() != null) scene.AddObject(player2.Fire());
                    }
                    else if (player2.GunType == 1)
                    {
                        if (player2.Fire() != null) scene.AddObject(player2.Fire());
                    }
                }
            }
            lastkeyboardState2 = keyboard2;
        }

        /// <summary>
        /// Метод, который проверяет события связаные с игроками.
        /// </summary>
        public void CheckAction(Tank player1, Tank player2)
        {
            collider.CheckCollisionWithAmmo(player1, player2);

            DebuffsFirstPlayer(player1);

            DebuffsSecondPlayer(player2);

            FirstPlayerAction(player1);

            SecondPlayerAction(player2);

        }
    }
}
