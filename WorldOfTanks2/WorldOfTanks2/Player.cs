using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks2
{
    public class Player : GameObject
    {
        private string direction = "U";

        public string gunType = "bigPushka"; 
        private int numberToChangeGunType = 1; 


        public Player(float x, float y, float height, float width) : base(x, y, height, width)
        {

        }
        public void Move(float goX, float goY, string newAction)
        {
            if (newAction == "ChangeWeapon") ChangeGun();

            if (newAction == "Shoot") Shot();

            x += goX;
            y += goY;
            this.direction = newAction;
        }

        private void ChangeGun()
        {
            numberToChangeGunType++;
            if (numberToChangeGunType % 2 == 0) { gunType = "Pulemet"; }
            else gunType = "bigPushka";
        }

        private void Shot()
        {

        }
    }
}
