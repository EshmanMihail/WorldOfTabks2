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
        public void CheckKeyDown(Player player1, Player player2)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard[Key.W])
            {
                player1.Move(0, speed);
            }
            if (keyboard[Key.S])
            {
                player1.Move(0, -speed);
            }
            if (keyboard[Key.D])
            {
                player1.Move(speed, 0);
            }
            if (keyboard[Key.A])
            {
                player1.Move(-speed, 0);
            }

            if (keyboard[Key.Up])
            {
                player2.Move(0, speed);
            }
            if (keyboard[Key.Down])
            {
                player2.Move(0, -speed);
            }
            if (keyboard[Key.Right])
            {
                player2.Move(speed, 0);
            }
            if (keyboard[Key.Left])
            {
                player2.Move(-speed, 0);
            }
        }
    }
}
