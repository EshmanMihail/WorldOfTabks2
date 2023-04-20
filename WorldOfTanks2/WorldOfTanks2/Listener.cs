using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks2
{
    public class Listener
    {
        private float speed = 0.01f;

        KeyboardState lastkeyboardState;
        public void CheckKeyDown(Player player1, Player player2)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard[Key.W])
            {
                player1.Move(0, speed, "U");
            }
            if (keyboard[Key.S])
            {
                player1.Move(0, -speed, "D");
            }
            if (keyboard[Key.D])
            {
                player1.Move(speed, 0, "R");
            }
            if (keyboard[Key.A])
            {
                player1.Move(-speed, 0, "L");
            }
            if (keyboard[Key.Q] && keyboard[Key.Q] != lastkeyboardState[Key.Q])
            {
                player1.Move(0, 0, "ChangeWeapon");
            }
            if (keyboard[Key.G] && keyboard[Key.G] != lastkeyboardState[Key.G])
            {
                player1.Move(0, 0, "Shoot");
            }

            if (keyboard[Key.Up])
            {
                player2.Move(0, speed, "U");
            }
            if (keyboard[Key.Down])
            {
                player2.Move(0, -speed, "D");
            }
            if (keyboard[Key.Right])
            {
                player2.Move(speed, 0, "R");
            }
            if (keyboard[Key.Left])
            {
                player2.Move(-speed, 0, "L");
            }
            if (keyboard[Key.KeypadPlus] && keyboard[Key.KeypadPlus] != lastkeyboardState[Key.KeypadPlus])
            {
                player2.Move(0, 0, "ChangeWeapon");
            }
            if (keyboard[Key.KeypadMinus] && keyboard[Key.KeypadMinus] != lastkeyboardState[Key.KeypadMinus])
            {
                player2.Move(0, 0, "Shoot");
            }

            lastkeyboardState = keyboard;
        }
    }
}
