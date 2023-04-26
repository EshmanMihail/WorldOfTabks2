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
        private float TankSpeed = 0.01f;

        private int gunTypeFirstPlayer = 0;
        Weapon[] weaponFirstPlayer = { new Trunk(), new Machinegun() };

        private int gunTypeSecondPlayer = 0;
        Weapon[] weaponSecondPlayer = { new Trunk(), new Machinegun() };

        KeyboardState lastkeyboardState1;
        KeyboardState keyboard1;

        KeyboardState keyboard2;
        KeyboardState lastkeyboardState2;
        private void FirstPlayerAction(Tank player1, List<GameObject> objectsToAdd)
        {
            keyboard1 = Keyboard.GetState();

            if (keyboard1[Key.W])
                player1.Move(0, TankSpeed, "U");

            if (keyboard1[Key.S])
                player1.Move(0, -TankSpeed, "D");

            if (keyboard1[Key.D])
                player1.Move(TankSpeed, 0, "R");

            if (keyboard1[Key.A])
                player1.Move(-TankSpeed, 0, "L");

            if (keyboard1[Key.Q] && (keyboard1[Key.Q] != lastkeyboardState1[Key.Q]))
                ChangeGunFirstPlayer();

            if (keyboard1[Key.G] && (keyboard1[Key.G] != lastkeyboardState1[Key.G]))
                player1.Shoot(weaponFirstPlayer[gunTypeFirstPlayer]);

            lastkeyboardState1 = keyboard1;

        }

        public void ChangeGunFirstPlayer()
        {
            if (gunTypeFirstPlayer == 0) gunTypeFirstPlayer = 1;
            else gunTypeFirstPlayer = 0;
        }

        private void SecondPlayerAction(Tank player2, List<GameObject> objectsToAdd)
        {
            keyboard2 = Keyboard.GetState();

            if (keyboard2[Key.Up])
                player2.Move(0, TankSpeed, "U");

            if (keyboard2[Key.Down])
                player2.Move(0, -TankSpeed, "D");

            if (keyboard2[Key.Right])
                player2.Move(TankSpeed, 0, "R");

            if (keyboard2[Key.Left])
                player2.Move(-TankSpeed, 0, "L");

            if (keyboard2[Key.KeypadPlus] && keyboard2[Key.KeypadPlus] != lastkeyboardState2[Key.KeypadPlus])
                ChangeGunSecondPlayer();

            if (keyboard2[Key.KeypadMinus] && keyboard2[Key.KeypadMinus] != lastkeyboardState2[Key.KeypadMinus])
            {
                player2.Shoot(weaponSecondPlayer[gunTypeSecondPlayer]);
            }
            lastkeyboardState2 = keyboard2;
        }

        public void ChangeGunSecondPlayer()
        {
            if (gunTypeSecondPlayer == 0) gunTypeSecondPlayer = 1;
            else gunTypeSecondPlayer = 0;
        }

        public void CheckAction(Tank player1, Tank player2, List<GameObject> objectsToAdd)
        {

            FirstPlayerAction(player1, objectsToAdd);

            SecondPlayerAction(player2, objectsToAdd);

        }
    }
}
